using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestMove : MonoBehaviour
{
    public string targetTag;
    public float speed;
    public bool isSit = false;
    private bool hasOrdered = false; // 주문 여부를 확인하는 플래그 추가

    public Animator anim;
    public Vector2 waitingPosition = new Vector2(-7, -3.5f);
    public float checkInterval = 1f;

    public GameObject[] foodPrefabList; // 음식 프리팹 리스트

    private Transform target;
    private Table targetTable;
    private bool waiting = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("idle", 0);
        FindNewTarget();
    }

    void Update()
    {
        if (!isSit && !waiting)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            anim.SetInteger("walk", 1);
        }
        if (isSit && !waiting && !hasOrdered) // 주문이 아직 이루어지지 않았는지 확인
        {
            OrderFood();
            hasOrdered = true; // 주문이 이루어진 후 플래그를 true로 설정
        }
        if(waiting)
        {
            anim.SetInteger("idle", 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag && !isSit)
        {
            Table table = collision.gameObject.GetComponent<Table>();
            if (table != null && table.isEmpty)
            {
                transform.position = collision.transform.position;

                table.isEmpty = false;

                transform.SetParent(collision.transform);
                anim.SetInteger("sit", 2);

                waiting = false; // 손님이 자리에 앉으면 대기를 멈춤

                StartCoroutine(WaitForAnimationToEnd("isSit", "isOrder"));
            }
            else
            {
                FindNewTarget();
            }
        }
    }

    private IEnumerator WaitForAnimationToEnd(string currentAnimation, string nextTrigger)
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        while (stateInfo.IsName(currentAnimation) && stateInfo.normalizedTime < 1.0f)
        {
            yield return null;
            stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        }

        anim.SetInteger("order", 3);

        isSit = true;
    }

    private void FindNewTarget()
    {
        GameObject[] tables = GameObject.FindGameObjectsWithTag(targetTag);
        foreach (GameObject tableObject in tables)
        {
            Table table = tableObject.GetComponent<Table>();
            if (table != null && table.isEmpty)
            {
                target = tableObject.transform;
                targetTable = table;
                waiting = false;
                return;
            }
        }

        // 빈 테이블을 찾지 못한 경우, 대기 위치로 이동하여 대기를 시작
        StartCoroutine(WaitForEmptyTable());
    }

    private IEnumerator WaitForEmptyTable()
    {
        waiting = true;
        target = null;

        // 현재 대기 중인 GuestMove 오브젝트의 수를 확인하여 위치 조정
        int waitingGuests = GameObject.FindObjectsOfType<GuestMove>().Length;
        Vector2 adjustedWaitingPosition = new Vector2(waitingPosition.x - 0.2f * waitingGuests, waitingPosition.y);
        transform.position = adjustedWaitingPosition;

        while (waiting)
        {
            yield return new WaitForSeconds(checkInterval);
            GameObject[] tables = GameObject.FindGameObjectsWithTag(targetTag);
            foreach (GameObject tableObject in tables)
            {
                Table table = tableObject.GetComponent<Table>();
                if (table != null && table.isEmpty)
                {
                    target = tableObject.transform;
                    targetTable = table;
                    waiting = false;
                    yield break;
                }
            }
        }
    }

    void OrderFood()
    {
        // foodPrefabList에서 무작위 프리팹 선택
        int randomIndex = Random.Range(0, foodPrefabList.Length);
        GameObject selectedFoodPrefab = foodPrefabList[randomIndex];

        // 현재 위치에서 (0.7, 0.7)만큼 이동한 위치에 프리팹 생성
        Vector2 foodPosition = new Vector2(transform.position.x + 0.7f, transform.position.y + 0.7f);
        Instantiate(selectedFoodPrefab, foodPosition, Quaternion.identity);
    }
}

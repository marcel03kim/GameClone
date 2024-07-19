using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestMove : MonoBehaviour
{
    public string targetTag;
    public float speed;
    public Animator anim;
    public Vector2 waitingPosition = new Vector2(-7, -3.5f);
    public float checkInterval = 1f;
    public GameObject orderedFood; // 주문한 음식 프리팹의 참조 추가
    public GuestManager guestManager; // GuestManager 참조 추가

    private Transform target;
    private Table targetTable;

    public enum State
    {
        Walking,
        Sitting,
        Ordering,
        hasOrder,
        Waiting
    }

    public State currentState = State.Walking;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("idle", 0);
        currentState = State.Walking; // 초기 상태를 Walking으로 설정
        FindNewTarget();
    }


    void Update()
    {
        switch (currentState)
        {
            case State.Walking:
                if (target != null)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    anim.SetInteger("walk", 1);
                }
                break;
            case State.Sitting:
                // 손님이 자리에 앉아있을 때의 동작
                break;
            case State.hasOrder:
                // 손님이 자리에 앉아있을 때의 동작
                break;
            case State.Ordering:
                if (orderedFood == null)
                {
                    guestManager.OrderFood(this);
                }
                break;
            case State.Waiting:
                anim.SetInteger("idle", 0);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag && currentState == State.Walking)
        {
            Table table = collision.gameObject.GetComponent<Table>();
            if (table != null && table.isEmpty)
            {
                transform.position = collision.transform.position;

                table.isEmpty = false;

                transform.SetParent(collision.transform);
                anim.SetInteger("sit", 2);

                currentState = State.Sitting;
                StartCoroutine(WaitForAnimationToEnd("isSit", State.Ordering));
            }
            else
            {
                FindNewTarget();
            }
        }

        if (currentState == State.Ordering && collision.gameObject.tag == "주모")
        {
            Destroy(orderedFood); // 주문한 음식 프리팹을 삭제
            currentState = State.Sitting; // 주문 상태를 Sitting으로 설정
        }
    }

    private IEnumerator WaitForAnimationToEnd(string currentAnimation, State nextState)
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        while (stateInfo.IsName(currentAnimation) && stateInfo.normalizedTime < 1.0f)
        {
            yield return null;
            stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        }

        anim.SetInteger("order", 3);
        currentState = nextState;
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
                currentState = State.Walking;
                return;
            }
        }

        // 빈 테이블을 찾지 못한 경우, 대기 위치로 이동하여 대기를 시작
        StartCoroutine(WaitForEmptyTable());
    }

    private IEnumerator WaitForEmptyTable()
    {
        currentState = State.Waiting;
        target = null;

        // 현재 대기 중인 GuestMove 오브젝트의 수를 확인하여 위치 조정
        int waitingGuests = GameObject.FindObjectsOfType<GuestMove>().Length;
        Vector2 adjustedWaitingPosition = new Vector2(waitingPosition.x - 0.2f * waitingGuests, waitingPosition.y);
        transform.position = adjustedWaitingPosition;

        while (currentState == State.Waiting)
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
                    currentState = State.Walking;
                    yield break;
                }
            }
        }
    }
}

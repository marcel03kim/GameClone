using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestMove : MonoBehaviour
{
    public string targetTag;
    public float speed;
    public bool isSit = false;
    private bool hasOrdered = false; // �ֹ� ���θ� Ȯ���ϴ� �÷��� �߰�

    public Animator anim;
    public Vector2 waitingPosition = new Vector2(-7, -3.5f);
    public float checkInterval = 1f;

    public GameObject[] foodPrefabList; // ���� ������ ����Ʈ

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
        if (isSit && !waiting && !hasOrdered) // �ֹ��� ���� �̷������ �ʾҴ��� Ȯ��
        {
            OrderFood();
            hasOrdered = true; // �ֹ��� �̷���� �� �÷��׸� true�� ����
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

                waiting = false; // �մ��� �ڸ��� ������ ��⸦ ����

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

        // �� ���̺��� ã�� ���� ���, ��� ��ġ�� �̵��Ͽ� ��⸦ ����
        StartCoroutine(WaitForEmptyTable());
    }

    private IEnumerator WaitForEmptyTable()
    {
        waiting = true;
        target = null;

        // ���� ��� ���� GuestMove ������Ʈ�� ���� Ȯ���Ͽ� ��ġ ����
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
        // foodPrefabList���� ������ ������ ����
        int randomIndex = Random.Range(0, foodPrefabList.Length);
        GameObject selectedFoodPrefab = foodPrefabList[randomIndex];

        // ���� ��ġ���� (0.7, 0.7)��ŭ �̵��� ��ġ�� ������ ����
        Vector2 foodPosition = new Vector2(transform.position.x + 0.7f, transform.position.y + 0.7f);
        Instantiate(selectedFoodPrefab, foodPosition, Quaternion.identity);
    }
}

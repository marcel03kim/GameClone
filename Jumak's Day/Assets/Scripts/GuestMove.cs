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
    public GameObject orderedFood; // �ֹ��� ���� �������� ���� �߰�
    public GuestManager guestManager; // GuestManager ���� �߰�

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
        currentState = State.Walking; // �ʱ� ���¸� Walking���� ����
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
                // �մ��� �ڸ��� �ɾ����� ���� ����
                break;
            case State.hasOrder:
                // �մ��� �ڸ��� �ɾ����� ���� ����
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

        if (currentState == State.Ordering && collision.gameObject.tag == "�ָ�")
        {
            Destroy(orderedFood); // �ֹ��� ���� �������� ����
            currentState = State.Sitting; // �ֹ� ���¸� Sitting���� ����
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

        // �� ���̺��� ã�� ���� ���, ��� ��ġ�� �̵��Ͽ� ��⸦ ����
        StartCoroutine(WaitForEmptyTable());
    }

    private IEnumerator WaitForEmptyTable()
    {
        currentState = State.Waiting;
        target = null;

        // ���� ��� ���� GuestMove ������Ʈ�� ���� Ȯ���Ͽ� ��ġ ����
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

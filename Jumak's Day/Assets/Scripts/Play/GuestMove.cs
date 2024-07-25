using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestMove : MonoBehaviour
{
    public string targetTag;
    public float speed;
    public Animator anim;
    public Vector2 waitingPosition = new Vector2(-6, -3.5f);
    public float checkInterval = 1f;
    public GameObject orderedFood;
    public GuestManager guestManager;
    public string exitTag = "Exit";  // Exit 태그를 설정합니다.
    public bool hasOrder = false;  // hasOrder 상태를 불리언 변수로 설정

    private Transform target;
    private Table targetTable;

    public enum State
    {
        Walking,
        Sitting,
        Ordering,
        eating,
        drinking,
        idle,
        standing,
        Waiting
    }

    public State currentState = State.Walking;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentState = State.idle;
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
                    anim.SetInteger("anim", 1);
                }
                break;
            case State.Sitting:
                anim.SetInteger("anim", 2);
                StartCoroutine(WaitForAnimationToEnd(2, 3, State.Ordering));
                Debug.Log(gameObject.name + 2);
                break;
            case State.idle:
                anim.SetInteger("anim", 0);
                break;
            case State.drinking:
                anim.SetInteger("anim", 5);
                break;
            case State.eating:
                anim.SetInteger("anim", 4);
                break;
            case State.standing:
                anim.SetInteger("anim", 6);
                StartCoroutine(WaitForAnimationToEnd(6, 1, State.Walking));
                break;
            case State.Ordering:
                if (!hasOrder)  // 주문이 아직 처리되지 않은 경우에만
                {
                    anim.SetInteger("anim", 3);
                    if (guestManager != null)
                    {
                        guestManager.OrderFood(this);
                        hasOrder = true;  // 주문 처리 완료 표시
                    }
                    else
                    {
                        Debug.LogError("guestManager is not assigned!");
                    }
                }
                break;
            case State.Waiting:
                anim.SetInteger("anim", 0);
                break;
        }

        if (hasOrder && orderedFood != null && orderedFood.transform.parent == transform)
        {
            StartCoroutine(ConsumeOrderedFood());
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
                anim.SetInteger("anim", 2);

                currentState = State.Sitting;
            }
            else
            {
                FindNewTarget();
            }
        }

        if (currentState == State.Ordering && collision.gameObject.tag == "주모")
        {
            Destroy(orderedFood);
            hasOrder = true;
            if (orderedFood.tag == "drink")
            {
                currentState = State.drinking;
                anim.SetInteger("anim", 5);
            }
            else if (orderedFood.tag == "food")
            {
                currentState = State.eating;
                anim.SetInteger("anim", 4);
            }
            StartCoroutine(ConsumeOrderedFood());
        }

        if (currentState == State.Walking && collision.gameObject.tag == exitTag)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator ConsumeOrderedFood()
    {
        yield return new WaitForSeconds(3f);
        if (orderedFood != null && orderedFood.transform.parent == transform)
        {
            Destroy(orderedFood);
            hasOrder = false;
            currentState = State.standing;
        }
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

        StartCoroutine(WaitForEmptyTable());
    }

    private IEnumerator WaitForEmptyTable()
    {
        currentState = State.Waiting;
        target = null;

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

    private void FindExit()
    {
        GameObject exit = GameObject.FindGameObjectWithTag(exitTag);
        if (exit != null)
        {
            target = exit.transform;
        }
        else
        {
            Debug.LogError("Exit object not found!");
        }
    }

    private IEnumerator WaitForAnimationToEnd(int currentAnimValue, int nextAnimValue, State nextState)
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        while (anim.GetInteger("anim") == currentAnimValue && stateInfo.normalizedTime < 1.0f)
        {
            yield return null;
            stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        }

        anim.SetInteger("anim", nextAnimValue);
        currentState = nextState;

        if (nextState == State.Walking && nextAnimValue == 1)
        {
            FindExit();
        }
    }
}

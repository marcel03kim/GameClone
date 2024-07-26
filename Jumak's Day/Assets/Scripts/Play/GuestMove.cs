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
    public string exitTag = "Exit";
    public bool hasOrder = false;

    private Transform target;
    private Table targetTable;
    public float crossFadeDuration = 0.2f; // 크로스페이드 지속 시간

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
                    anim.CrossFade("WalkingAnimation", crossFadeDuration);
                }
                break;
            case State.Sitting:
                anim.CrossFade("SittingAnimation", crossFadeDuration);
                StartCoroutine(WaitForAnimationToEnd(2, 3, State.Ordering));
                break;
            case State.idle:
                anim.CrossFade("IdleAnimation", crossFadeDuration);
                break;
            case State.drinking:
                anim.CrossFade("DrinkingAnimation", crossFadeDuration);
                break;
            case State.eating:
                anim.CrossFade("EatingAnimation", crossFadeDuration);
                break;
            case State.standing:
                anim.CrossFade("StandingAnimation", crossFadeDuration);
                StartCoroutine(WaitForAnimationToEnd(6, 1, State.Walking));
                break;
            case State.Ordering:
                if (!hasOrder)
                {
                    anim.CrossFade("OrderingAnimation", crossFadeDuration);
                    if (guestManager != null)
                    {
                        guestManager.OrderFood(this);
                        hasOrder = true;
                    }
                    else
                    {
                        Debug.LogError("guestManager is not assigned!");
                    }
                }
                break;
            case State.Waiting:
                anim.CrossFade("WaitingAnimation", crossFadeDuration);
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
                anim.CrossFade("SittingAnimation", crossFadeDuration);
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
                anim.CrossFade("DrinkingAnimation", crossFadeDuration);
            }
            else if (orderedFood.tag == "food")
            {
                currentState = State.eating;
                anim.CrossFade("EatingAnimation", crossFadeDuration);
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
            anim.CrossFade("StandingAnimation", crossFadeDuration);
            // 코인 프리팹을 생성하려면 추가 로직을 여기에 넣을 수 있습니다.
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
                break;
            }
        }

        if (target == null)
        {
            target = new GameObject("RandomTarget").transform;
            target.position = waitingPosition;
        }
    }

    private IEnumerator WaitForAnimationToEnd(float waitTime, float fadeTime, State newState)
    {
        yield return new WaitForSeconds(waitTime);
        anim.CrossFade("IdleAnimation", fadeTime);
        currentState = newState;
    }
}

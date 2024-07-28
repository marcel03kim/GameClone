using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestMove : MonoBehaviour
{
    public float speed = 2.0f;
    public Animator anim;
    public Vector2 waitingPosition = new Vector2(-6, -3.5f);
    public float checkInterval = 1f;
    public GameObject orderedFood;
    public GuestManager guestManager;
    public GameObject coinPrefab;

    public Transform target;
    private Rigidbody2D rb;
    public float crossFadeDuration = 0.2f;

    public enum State
    {
        Idle = 0,
        Move = 1,
        Order = 2,
        Sit = 3,
        Eat = 4,
        Exit = 5,
        Wait = 6
    }

    public State currentState = State.Move;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();  // Rigidbody2D 컴포넌트 가져오기
        currentState = State.Move;
        FindNewTarget();
        UpdateAnimator();
    }


    void Update()
    {
        switch (currentState)
        {
            case State.Move:
                Move();
                break;
            case State.Idle:
                speed = 0;
                break;
            case State.Sit:
                break;
            case State.Eat:
                Eat();
                break;
            case State.Order:
                Order();
                break;
            case State.Wait:
                Wait();
                break;
            case State.Exit:
                Exit();
                break;
        }

        if (orderedFood != null && orderedFood.transform.parent == transform)
        {
            StartCoroutine(ConsumeOrderedFood());
        }

        UpdateAnimator();
    }

    void FixedUpdate()
    {
        if (currentState == State.Move)
        {
            Move();
        }
    }


    void Move()
    {
        if (target != null)
        {
            Vector2 newPosition = target.transform.position - rb.transform.position;
            transform.Translate(newPosition * Time.fixedDeltaTime);
            //rb.velocity = newPosition;
            //Vector2 newPosition = Vector2.MoveTowards(rb.position, target.position, speed * Time.fixedDeltaTime);
            //rb.MovePosition(newPosition);

            Debug.Log("무브 호출");
        }
    }


    void Order()
    {
        if (guestManager != null)
        {
            guestManager.OrderFood(this);
            currentState = State.Sit;
            Debug.Log("Order called"); // 디버그 로그 추가
        }
        else
        {
            Debug.LogError("guestManager is not assigned!");
        }
    }

    void Wait()
    {
        transform.position = Vector2.MoveTowards(transform.position, waitingPosition, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waitingPosition) < 0.01f)
        {
            speed = 0f;
            FindNewTarget();
        }
    }

    void Eat()
    {
        StartCoroutine(ConsumeOrderedFood());
    }

    void Exit()
    {
        GameObject exitObject = GameObject.FindGameObjectWithTag("Exit");
        if (exitObject != null)
        {
            target = exitObject.transform;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D called with: " + collision.gameObject.tag); // 디버그 로그 추가

        if (collision.gameObject.tag == "Table" && currentState == State.Move)
        {
            Table table = collision.gameObject.GetComponent<Table>();
            if (table != null && table.state == Table.TableState.Empty)
            {
                Debug.Log("Table found and empty"); // 디버그 로그 추가

                transform.position = collision.transform.position;
                table.state = Table.TableState.Full;
                transform.SetParent(collision.transform);
                currentState = State.Order;
            }
            else
            {
                currentState = State.Wait;
            }
        }

        if (currentState == State.Order && collision.gameObject.tag == "주모")
        {
            Debug.Log("주모 found and in Order state"); // 디버그 로그 추가

            Destroy(orderedFood);
            currentState = State.Eat;
        }

        if (currentState == State.Exit && collision.gameObject.tag == "Exit")
        {
            Debug.Log("Exit found and in Exit state"); // 디버그 로그 추가

            Destroy(gameObject);
        }

        UpdateAnimator();
    }

    private IEnumerator ConsumeOrderedFood()
    {
        yield return new WaitForSeconds(3f);
        if (orderedFood != null && orderedFood.transform.parent == transform)
        {
            currentState = State.Exit;
            orderedFood.GetComponent<Item>().price = coinPrefab.GetComponent<Coin>().Cpoint;
            orderedFood.GetComponent<Item>().Honor = coinPrefab.GetComponent<Coin>().Hpoint;
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
            Destroy(orderedFood);
        }
        UpdateAnimator();
    }

    private void FindNewTarget()
    {
        GameObject[] tables = GameObject.FindGameObjectsWithTag("Table");
        float closestDistance = Mathf.Infinity;
        GameObject closestTable = null;

        foreach (GameObject tableObject in tables)
        {
            Table table = tableObject.GetComponent<Table>();
            if (table != null && table.state == Table.TableState.Empty)
            {
                float distance = Vector2.Distance(transform.position, tableObject.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTable = tableObject;
                }
            }
        }

        if (closestTable != null)
        {
            target = closestTable.transform;
            currentState = State.Move;
            Debug.Log("New target found: " + target.position); // 디버그 로그 추가
        }
        else
        {
            target.position = waitingPosition;
            currentState = State.Wait;
        }

        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        anim.SetInteger("State", (int)currentState);
    }
}

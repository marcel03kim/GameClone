using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestMove : MonoBehaviour
{
    public float speed;
    public Animator anim;
    public Vector2 waitingPosition = new Vector2(-6, -3.5f);
    public float checkInterval = 1f;
    public GameObject orderedFood;
    public GuestManager guestManager;
    public GameObject coinPrefab;

    private bool hasOrder;
    private Transform target;
    private Transform initialTarget;
    private Rigidbody2D rb;

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
        rb = GetComponent<Rigidbody2D>();
        FindNewTarget();
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                speed = 0;
                anim.SetInteger("anim", 0);
                break;
            case State.Sit:
                anim.SetInteger("anim", 3);
                break;
            case State.Eat:
                StartCoroutine(ConsumeOrderedFood());
                break;
            case State.Order:
                if (!hasOrder)
                {
                    Order();
                }
                break;
            case State.Wait:
                Wait();
                break;
            case State.Exit:
                StartCoroutine(Exit());
                break;
        }

        if (orderedFood != null && orderedFood.GetComponent<Item>().currentState == Item.State.Ate)
        {
            currentState = State.Eat;
        }
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
            Vector2 newPosition = Vector2.MoveTowards(rb.position, target.position, speed * Time.fixedDeltaTime);
            if (target.position.x > rb.position.x)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            rb.MovePosition(newPosition);
            anim.SetInteger("anim", 1);

            if (Vector2.Distance(rb.position, target.position) < 0.1f)
            {
                if (currentState == State.Move)
                {
                    currentState = State.Order;
                    target = null;
                }
            }
        }
    }

    void Order()
    {
        if (guestManager != null)
        {
            guestManager.OrderFood(this);
            anim.SetInteger("anim", 2);
            hasOrder = true;
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

    private IEnumerator Exit()
    {
        GameObject exitObject = GameObject.FindGameObjectWithTag("Exit");
        if (exitObject != null)
        {
            target = exitObject.transform;
            anim.SetInteger("anim", 6);

            yield return new WaitForSeconds(2.5f);

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.SetParent(null);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Table" && currentState == State.Move)
        {
            Table table = collision.gameObject.GetComponent<Table>();
            if (table != null && table.state == Table.TableState.Empty)
            {
                transform.position = collision.transform.position;
                table.state = Table.TableState.Full;
                transform.SetParent(collision.transform);
                currentState = State.Order;
            }
        }
        if (collision.gameObject.tag == "Table" && currentState == State.Move)
        {
            Table table = collision.gameObject.GetComponent<Table>();
            if (table != null && table.state == Table.TableState.Full)
            {
                FindNewTarget();
            }
        }

        if (currentState == State.Order && collision.gameObject.tag == "주모")
        {
            currentState = State.Sit;
        }

        if (currentState == State.Exit && collision.gameObject.tag == "Exit")
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator ConsumeOrderedFood()
    {
        if (orderedFood.gameObject.tag == "food")
        {
            anim.SetInteger("anim", 4);
        }
        if (orderedFood.gameObject.tag == "Alc")
        {
            anim.SetInteger("anim", 3);
        }

        yield return new WaitForSeconds(5f);
        if (orderedFood != null && orderedFood.transform.parent == transform)
        {
            coinPrefab.GetComponent<Coin>().Cpoint = orderedFood.GetComponent<Item>().price;
            coinPrefab.GetComponent<Coin>().Hpoint = orderedFood.GetComponent<Item>().Honor;
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
            Destroy(orderedFood);
            currentState = State.Exit;
        }
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
            initialTarget = closestTable.transform;
            currentState = State.Move;
        }
        else
        {
            gameObject.transform.position = waitingPosition;
            currentState = State.Idle;
        }
    }
}

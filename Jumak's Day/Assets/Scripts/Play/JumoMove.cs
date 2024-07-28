using System.Collections;
using UnityEngine;

public class JumoMove : MonoBehaviour
{
    public float speed = 3f;
    private Vector3 targetPosition;
    public Animator anim;
    public enum State
    {
        idle,
        Moving,
        order
    }

    public State currentState = State.idle;

    private void Start()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (currentState != State.order) 
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.z = 0;
                currentState = State.Moving;
            }
        }

        switch (currentState)
        {
            case State.idle:
                anim.SetInteger("anim", 0);
                break;
            case State.Moving:
                Move();
                break;
            case State.order:
                StartCoroutine(Order());
                break;
        }
    }

    void Move()
    {
        anim.SetInteger("anim", 1);

        if (Vector3.Distance(transform.position, targetPosition) > 0.1f) 
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            currentState = State.idle; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GuestMove guestMove = collision.gameObject.GetComponent<GuestMove>();
            if (guestMove != null && guestMove.currentState == GuestMove.State.Order)
            {
                guestMove.currentState = GuestMove.State.Sit;
                currentState = State.order;
                if (guestMove.orderedFood != null)
                {
                    guestMove.orderedFood.GetComponent<Item>().currentState = Item.State.Cooked;
                }
            }
        }
    }

    private IEnumerator Order()
    {
        anim.SetInteger("anim", 2);

        yield return new WaitForSeconds(2.5f);
        currentState = State.idle;
    }
}

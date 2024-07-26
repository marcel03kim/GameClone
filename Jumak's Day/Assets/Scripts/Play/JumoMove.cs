using System.Collections;
using UnityEngine;

public class JumoMove : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool canMove = true; // �̵� ���� ���θ� ��Ÿ���� ����
    public float crossFadeDuration = 0.2f; // ũ�ν����̵� ���� �ð�

    public enum State
    {
        idle,
        Moving,
        order
    }

    public State currentState = State.idle;
    public Animator animator; // �ִϸ����� ������Ʈ ����

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        // `order` ������ ���� �̵��� ���� ����
        if (currentState == State.order)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && canMove)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;
            isMoving = true;
            currentState = State.Moving;
            UpdateAnimator();
        }

        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                currentState = State.idle;
                UpdateAnimator();
            }
        }

        switch (currentState)
        {
            case State.idle:
                // Idle ���¿����� �ƹ��͵� ���� ����
                break;
            case State.Moving:
                if (target != null)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, target.position) < 0.1f)
                    {
                        currentState = State.order; // ��ǥ�� �����ϸ� order ���·� ��ȯ
                        UpdateAnimator();
                        StartCoroutine(WaitForOrderState());
                    }
                }
                break;
            case State.order:
                // order ���¿����� � ������ ���� �߰�
                // ��: �մ԰� ��ȣ�ۿ�
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GuestMove guestMove = collision.GetComponent<GuestMove>();
        if (guestMove != null && guestMove.currentState == GuestMove.State.Ordering)
        {
            currentState = State.order;
            canMove = false; // order ������ ���� �̵��� �� ������ ����
            UpdateAnimator(); // �ִϸ��̼� Ʈ���� ������Ʈ
            guestMove.currentState = GuestMove.State.Ordering;
            StartCoroutine(WaitForOrderState());
        }
    }

    private IEnumerator WaitForOrderState()
    {
        yield return new WaitForSeconds(3f); // 3�� ���
        currentState = State.idle;
        canMove = true; // �̵� ���� ���·� ����
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        if (animator == null) return;

        switch (currentState)
        {
            case State.idle:
                animator.CrossFade("IdleAnimation", crossFadeDuration);
                break;
            case State.Moving:
                animator.CrossFade("MovingAnimation", crossFadeDuration);
                break;
            case State.order:
                animator.CrossFade("OrderAnimation", crossFadeDuration);
                break;
        }
    }
}

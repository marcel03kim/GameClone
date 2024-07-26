using System.Collections;
using UnityEngine;

public class JumoMove : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool canMove = true; // 이동 가능 여부를 나타내는 변수
    public float crossFadeDuration = 0.2f; // 크로스페이드 지속 시간

    public enum State
    {
        idle,
        Moving,
        order
    }

    public State currentState = State.idle;
    public Animator animator; // 애니메이터 컴포넌트 참조

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        // `order` 상태일 때는 이동을 하지 않음
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
                // Idle 상태에서는 아무것도 하지 않음
                break;
            case State.Moving:
                if (target != null)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, target.position) < 0.1f)
                    {
                        currentState = State.order; // 목표에 도달하면 order 상태로 전환
                        UpdateAnimator();
                        StartCoroutine(WaitForOrderState());
                    }
                }
                break;
            case State.order:
                // order 상태에서는 어떤 동작을 할지 추가
                // 예: 손님과 상호작용
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GuestMove guestMove = collision.GetComponent<GuestMove>();
        if (guestMove != null && guestMove.currentState == GuestMove.State.Ordering)
        {
            currentState = State.order;
            canMove = false; // order 상태일 때는 이동할 수 없도록 설정
            UpdateAnimator(); // 애니메이션 트리거 업데이트
            guestMove.currentState = GuestMove.State.Ordering;
            StartCoroutine(WaitForOrderState());
        }
    }

    private IEnumerator WaitForOrderState()
    {
        yield return new WaitForSeconds(3f); // 3초 대기
        currentState = State.idle;
        canMove = true; // 이동 가능 상태로 복원
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumoMove : MonoBehaviour
{
    public float speed = 3f;

    private Transform target;

    public enum State
    {
        idle,
        Moving,
        order
    }

    public State currentState = State.idle;

    void Start()
    {
        StartCoroutine(CheckForOrderingGuests());
    }

    void Update()
    {
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
                    }
                }
                break;
            case State.order:
                // order 상태에서는 어떤 동작을 할지 추가
                // 예: 손님과 상호작용
                break;
        }
    }

    private IEnumerator CheckForOrderingGuests()
    {
        while (true)
        {
            FindClosestOrderingGuest();
            yield return new WaitForSeconds(1f); // 1초마다 확인
        }
    }

    private void FindClosestOrderingGuest()
    {
        GuestMove[] guests = GameObject.FindObjectsOfType<GuestMove>();
        float closestDistance = Mathf.Infinity;
        GuestMove closestGuest = null;

        foreach (GuestMove guest in guests)
        {
            if (guest.hasOrder && guest.currentState == GuestMove.State.Ordering) // hasOrder 상태가 true이고 Ordering 상태인 손님만 고려
            {
                float distance = Vector2.Distance(transform.position, guest.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestGuest = guest;
                }
            }
        }

        if (closestGuest != null)
        {
            target = closestGuest.transform;
            currentState = State.Moving; // 가장 가까운 손님이 있으면 Moving 상태로 전환
        }
        else
        {
            target = null;
            currentState = State.idle; // 가까운 손님이 없으면 Idle 상태로 유지
        }
    }
}

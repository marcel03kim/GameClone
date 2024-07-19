using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumoMove : MonoBehaviour
{
    public float speed = 3f;

    private Transform target;

    public enum State
    {
        Idle,
        Moving
    }

    public State currentState = State.Idle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckForOrderingGuests());
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Moving:
                if (target != null)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }
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
            if (guest.currentState == GuestMove.State.Ordering) // 상태를 확인하여 Ordering 상태의 손님만 고려
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
            currentState = State.Idle; // 가까운 손님이 없으면 Idle 상태로 유지
        }
    }
}

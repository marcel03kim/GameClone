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
                // Idle ���¿����� �ƹ��͵� ���� ����
                break;
            case State.Moving:
                if (target != null)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, target.position) < 0.1f)
                    {
                        currentState = State.order; // ��ǥ�� �����ϸ� order ���·� ��ȯ
                    }
                }
                break;
            case State.order:
                // order ���¿����� � ������ ���� �߰�
                // ��: �մ԰� ��ȣ�ۿ�
                break;
        }
    }

    private IEnumerator CheckForOrderingGuests()
    {
        while (true)
        {
            FindClosestOrderingGuest();
            yield return new WaitForSeconds(1f); // 1�ʸ��� Ȯ��
        }
    }

    private void FindClosestOrderingGuest()
    {
        GuestMove[] guests = GameObject.FindObjectsOfType<GuestMove>();
        float closestDistance = Mathf.Infinity;
        GuestMove closestGuest = null;

        foreach (GuestMove guest in guests)
        {
            if (guest.hasOrder && guest.currentState == GuestMove.State.Ordering) // hasOrder ���°� true�̰� Ordering ������ �մԸ� ���
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
            currentState = State.Moving; // ���� ����� �մ��� ������ Moving ���·� ��ȯ
        }
        else
        {
            target = null;
            currentState = State.idle; // ����� �մ��� ������ Idle ���·� ����
        }
    }
}

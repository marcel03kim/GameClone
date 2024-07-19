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
            if (guest.currentState == GuestMove.State.Ordering) // ���¸� Ȯ���Ͽ� Ordering ������ �մԸ� ���
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
            currentState = State.Idle; // ����� �մ��� ������ Idle ���·� ����
        }
    }
}

using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    public int id;
    public int price;
    public int Honor;
    public float cookTime;
    public enum State { Ordered, Cooked, Ate }
    public State currentState;

    public Transform parentTransform;
    public Slot[] slots; // �� �迭�� �ν����Ϳ��� ������ �ʿ䰡 ����

    private void Start()
    {
        // ���� �ʱ�ȭ
        currentState = State.Ordered;

        // ������ �Ӽ� ����
        switch (id)
        {
            case 100:
            case 101:
            case 102:
            case 103:
            case 104:
            case 105:
                cookTime = 3.0f;
                price = 1000;
                Honor = 15;
                break;
            case 106:
            case 107:
            case 108:
            case 109:
            case 110:
                cookTime = 5.0f;
                price = 3000;
                Honor = 30;
                break;
            default:
                cookTime = 5.0f; // �⺻�� ����
                break;
        }

        // ���� �ڵ� ã��
        FindSlots();
    }

    void Update()
    {
        if (gameObject.tag == "food" || gameObject.tag == "alc")
        {
            switch (currentState)
            {
                case State.Ordered:
                    foodOrder();
                    break;
                case State.Cooked:
                    StartCoroutine(CookItem());
                    break;
                case State.Ate:
                    Ate();
                    break;
            }
        }
    }

    void foodOrder()
    {
        transform.position = parentTransform.position + new Vector3(0.7f, 0.7f, 0);
    }

    void cooking()
    {
        bool slotFound = false;

        foreach (Slot slot in slots)
        {
            if (slot.currentState == Slot.SlotState.Empty)
            {
                slot.currentState = Slot.SlotState.Full;
                transform.position = slot.transform.position;
                slotFound = true;
                break;
            }
        }

        if (!slotFound)
        {
            transform.position = new Vector3(14, 7, 0); // �⺻ ��ġ�� �̵�
        }
    }

    private IEnumerator CookItem()
    {
        cooking(); // �丮�� ���� ��ġ�� �̵�

        yield return new WaitForSeconds(cookTime);

        currentState = State.Ate; // �丮 �Ϸ� �� ���� ����
    }

    void Ate()
    {
        transform.position = parentTransform.position - new Vector3(0, 0.5f, 0);
        gameObject.GetComponentInParent<GuestMove>().currentState = GuestMove.State.Eat;
    }

    private void FindSlots()
    {
        // ������ �ڵ����� ã��. ���⼭ "Slot" �±׸� ����Ͽ� ������ ã�� �� �ֽ��ϴ�.
        slots = GameObject.FindObjectsOfType<Slot>();
    }
}

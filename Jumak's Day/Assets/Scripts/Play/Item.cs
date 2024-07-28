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
    public Slot[] slots; // 이 배열을 인스펙터에서 설정할 필요가 없음

    private void Start()
    {
        // 상태 초기화
        currentState = State.Ordered;

        // 아이템 속성 설정
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
                cookTime = 5.0f; // 기본값 설정
                break;
        }

        // 슬롯 자동 찾기
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
            transform.position = new Vector3(14, 7, 0); // 기본 위치로 이동
        }
    }

    private IEnumerator CookItem()
    {
        cooking(); // 요리를 위한 위치로 이동

        yield return new WaitForSeconds(cookTime);

        currentState = State.Ate; // 요리 완료 후 상태 변경
    }

    void Ate()
    {
        transform.position = parentTransform.position - new Vector3(0, 0.5f, 0);
        gameObject.GetComponentInParent<GuestMove>().currentState = GuestMove.State.Eat;
    }

    private void FindSlots()
    {
        // 슬롯을 자동으로 찾기. 여기서 "Slot" 태그를 사용하여 슬롯을 찾을 수 있습니다.
        slots = GameObject.FindObjectsOfType<Slot>();
    }
}

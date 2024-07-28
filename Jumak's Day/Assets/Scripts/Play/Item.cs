using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public int price;
    public int Honor;
    public enum State { Ordered, Cooked, Ate }
    public State currentState;

    public Transform parentTransform;

    void Update()
    {
        if(gameObject.tag == "food" ||  gameObject.tag == "alc")
        {
            switch (currentState)
            {
                case State.Ordered:
                    transform.position = parentTransform.position + new Vector3(0.7f, 0.7f, 0);
                    break;
                case State.Cooked:
                    // 요리 상태 로직
                    break;
                case State.Ate:
                    transform.position = parentTransform.position - new Vector3(0, 0.5f, 0);
                    break;
            }
        }
    }
}

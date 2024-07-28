using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMove : MonoBehaviour
{
    public float speed = 3f;
    private EventManager eventManager;

    // Start is called before the first frame update
    void Start()
    {
        // EventManager 컴포넌트를 찾아 저장합니다.
        eventManager = FindObjectOfType<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Table")
        {
            eventManager.EventStart(0);
        }
    }
}

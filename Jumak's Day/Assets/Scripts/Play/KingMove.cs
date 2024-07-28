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
        // EventManager ������Ʈ�� ã�� �����մϴ�.
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

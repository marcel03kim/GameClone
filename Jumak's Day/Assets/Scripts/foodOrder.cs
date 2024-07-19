using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class foodOrder : MonoBehaviour
{
    public float cookTime;
    public bool isCookEnd;
    public Image cookingImage;
    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

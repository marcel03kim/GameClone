using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public GameObject[] EndingImages;
    private int currentImage;
    private float imageTime;

    // Start is called before the first frame update
    void Start()
    {
        EndingImages[0].SetActive(true);
        currentImage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        imageTime += Time.deltaTime;

        if(imageTime > 1.5f || Input.GetMouseButtonDown(0))
        {
            EndingImages[currentImage + 1].SetActive(true);
            imageTime = 0;
        }


    }
}

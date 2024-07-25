using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera.transform.position = new Vector3(0, 0, -10);
    }

    public void rightMove()
    {
        Camera.transform.position += new Vector3(19, 0, 0);
    }

    public void leftMove()
    {
        Camera.transform.position += new Vector3(-19, 0, 0);
    }
}

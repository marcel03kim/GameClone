using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Cpoint;
    public int Hpoint;

    private void OnMouseDown()
    {
        Destroy(gameObject);
        GameManager.Instance.coin += Cpoint;
        GameManager.Instance.honor += Hpoint;
    }
}

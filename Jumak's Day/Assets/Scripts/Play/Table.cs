using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public enum TableState
    {
        Empty,
        Full
    }

    public TableState state = TableState.Empty;

    private void Update()
    {
        if (transform.childCount == 0)
        {
            state = TableState.Empty;
        }
        else
        {
            state = TableState.Full;
        }
    }
}

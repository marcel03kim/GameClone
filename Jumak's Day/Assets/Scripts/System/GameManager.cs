using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> prefabArray; // �������� ������ ����Ʈ

    // �������� ����Ʈ�� �߰��ϴ� �޼���
    public void AddPrefab(GameObject prefab)
    {
        prefabArray.Add(prefab);
        Debug.Log(prefab.name + " has been added to the array.");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

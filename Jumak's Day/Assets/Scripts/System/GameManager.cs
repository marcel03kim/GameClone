using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> prefabArray; // 프리팹을 저장할 리스트

    // 프리팹을 리스트에 추가하는 메서드
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

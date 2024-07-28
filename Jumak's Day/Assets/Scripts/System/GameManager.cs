using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static GameManager Instance;

    // 프리팹을 저장할 리스트
    public List<GameObject> prefabArray = new List<GameObject>();

    public int coin; 
    public int honor;

    public Text coinText;
    public Text honorText;

    private void Awake()
    {
        // 싱글톤 패턴 구현
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 프리팹을 리스트에 추가하는 메서드
    public void AddPrefab(GameObject prefab)
    {
        if (prefabArray != null)
        {
            prefabArray.Add(prefab);
            Debug.Log(prefab.name + " has been added to the array.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 사운드 매니저 인스턴스가 존재하는지 확인 후 사운드 재생
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlaySound("Bgm");
        }
    }

    private void Update()
    {
        coinText.text = ": " + coin;
        honorText.text = ": " + honor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ�
    public static GameManager Instance;

    // �������� ������ ����Ʈ
    public List<GameObject> prefabArray = new List<GameObject>();

    public int coin; 
    public int honor;

    public Text coinText;
    public Text honorText;

    private void Awake()
    {
        // �̱��� ���� ����
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

    // �������� ����Ʈ�� �߰��ϴ� �޼���
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
        // ���� �Ŵ��� �ν��Ͻ��� �����ϴ��� Ȯ�� �� ���� ���
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

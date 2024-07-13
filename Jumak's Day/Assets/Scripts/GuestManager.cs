using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestManager : MonoBehaviour
{
    public GameObject[] guestPrefabList; // �Խ�Ʈ ������ ����Ʈ
    public Transform guestSpawnPos;
    public float speed = 1.0f;
    public float spawnInterval = 3.0f;

    void Start()
    {
        InvokeRepeating("SpawnGuest", 0f, spawnInterval);
    }

    void SpawnGuest()
    {
        // ���� �������ϰ� �ִ� GuestMove ������Ʈ�� ���� ������Ʈ�� ���� Ȯ��
        int waitingGuests = FindObjectsOfType<GuestMove>().Length;
        if (waitingGuests >= 15)
        {
            return; // �������ϰ� �ִ� �������� 15�� �̻��̸� SpawnGuest�� �������� ����
        }

        // �������� �Խ�Ʈ ������ ����
        int randomIndex = Random.Range(0, guestPrefabList.Length);
        GameObject randomGuestPrefab = guestPrefabList[randomIndex];

        // �������� ���õ� �Խ�Ʈ �������� ����
        GameObject spawnedGuest = Instantiate(randomGuestPrefab, guestSpawnPos.position, Quaternion.identity);

        GuestMove guestMove = spawnedGuest.GetComponent<GuestMove>();
        guestMove.targetTag = "Table";
        guestMove.speed = speed;
    }
}

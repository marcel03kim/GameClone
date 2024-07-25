using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestManager : MonoBehaviour
{
    public GameObject[] guestPrefabList; // �Խ�Ʈ ������ ����Ʈ
    public GameObject[] foodPrefabList; // ���� ������ ����Ʈ
    public Transform guestSpawnPos;
    public float speed = 1.0f;
    public float spawnInterval = 3.0f;
    public int counta;

    void Start()
    {
        InvokeRepeating("SpawnGuest", 0f, spawnInterval);
    }

    void SpawnGuest()
    {
        if(counta > 1)
            return;
        //// ���� �������ϰ� �ִ� GuestMove ������Ʈ�� ���� ������Ʈ�� ���� Ȯ��
        //int waitingGuests = FindObjectsOfType<GuestMove>().Length;
        //if (waitingGuests >= 15)
        //{
        //    return; // �������ϰ� �ִ� �������� 15�� �̻��̸� SpawnGuest�� �������� ����
        //}

        // �������� �Խ�Ʈ ������ ����
        int randomIndex = Random.Range(0, guestPrefabList.Length);
        GameObject randomGuestPrefab = guestPrefabList[randomIndex];

        // �������� ���õ� �Խ�Ʈ �������� ����
        GameObject spawnedGuest = Instantiate(randomGuestPrefab, guestSpawnPos.position, Quaternion.identity);

        GuestMove guestMove = spawnedGuest.GetComponent<GuestMove>();
        guestMove.targetTag = "Table";
        guestMove.speed = speed;
        guestMove.guestManager = this; // GuestManager ���� ����
        counta++;
    }

    public void OrderFood(GuestMove guest)
    {
        // foodPrefabList���� ������ ������ ����
        int randomIndex = Random.Range(0, foodPrefabList.Length);
        GameObject selectedFoodPrefab = foodPrefabList[randomIndex];

        // ���� ��ġ���� (0.7, 0.7)��ŭ �̵��� ��ġ�� ������ ����
        Vector2 foodPosition = new Vector2(guest.transform.position.x + 0.7f, guest.transform.position.y + 0.7f);
        GameObject orderedFood = Instantiate(selectedFoodPrefab, foodPosition, Quaternion.identity);

        // ������ �������� �ڽ����� ����
        orderedFood.transform.SetParent(guest.transform);

        // GuestMove ��ũ��Ʈ�� ������ ���� �������� ���� ����
        guest.orderedFood = orderedFood;
    }
}

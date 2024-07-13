using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestManager : MonoBehaviour
{
    public GameObject[] guestPrefabList; // 게스트 프리팹 리스트
    public Transform guestSpawnPos;
    public float speed = 1.0f;
    public float spawnInterval = 3.0f;

    void Start()
    {
        InvokeRepeating("SpawnGuest", 0f, spawnInterval);
    }

    void SpawnGuest()
    {
        // 현재 웨이팅하고 있는 GuestMove 컴포넌트를 가진 오브젝트의 수를 확인
        int waitingGuests = FindObjectsOfType<GuestMove>().Length;
        if (waitingGuests >= 15)
        {
            return; // 웨이팅하고 있는 프리팹이 15개 이상이면 SpawnGuest를 실행하지 않음
        }

        // 무작위로 게스트 프리팹 선택
        int randomIndex = Random.Range(0, guestPrefabList.Length);
        GameObject randomGuestPrefab = guestPrefabList[randomIndex];

        // 무작위로 선택된 게스트 프리팹을 생성
        GameObject spawnedGuest = Instantiate(randomGuestPrefab, guestSpawnPos.position, Quaternion.identity);

        GuestMove guestMove = spawnedGuest.GetComponent<GuestMove>();
        guestMove.targetTag = "Table";
        guestMove.speed = speed;
    }
}

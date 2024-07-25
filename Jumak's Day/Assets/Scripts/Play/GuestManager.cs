using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestManager : MonoBehaviour
{
    public GameObject[] guestPrefabList; // 게스트 프리팹 리스트
    public GameObject[] foodPrefabList; // 음식 프리팹 리스트
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
        //// 현재 웨이팅하고 있는 GuestMove 컴포넌트를 가진 오브젝트의 수를 확인
        //int waitingGuests = FindObjectsOfType<GuestMove>().Length;
        //if (waitingGuests >= 15)
        //{
        //    return; // 웨이팅하고 있는 프리팹이 15개 이상이면 SpawnGuest를 실행하지 않음
        //}

        // 무작위로 게스트 프리팹 선택
        int randomIndex = Random.Range(0, guestPrefabList.Length);
        GameObject randomGuestPrefab = guestPrefabList[randomIndex];

        // 무작위로 선택된 게스트 프리팹을 생성
        GameObject spawnedGuest = Instantiate(randomGuestPrefab, guestSpawnPos.position, Quaternion.identity);

        GuestMove guestMove = spawnedGuest.GetComponent<GuestMove>();
        guestMove.targetTag = "Table";
        guestMove.speed = speed;
        guestMove.guestManager = this; // GuestManager 참조 설정
        counta++;
    }

    public void OrderFood(GuestMove guest)
    {
        // foodPrefabList에서 무작위 프리팹 선택
        int randomIndex = Random.Range(0, foodPrefabList.Length);
        GameObject selectedFoodPrefab = foodPrefabList[randomIndex];

        // 현재 위치에서 (0.7, 0.7)만큼 이동한 위치에 프리팹 생성
        Vector2 foodPosition = new Vector2(guest.transform.position.x + 0.7f, guest.transform.position.y + 0.7f);
        GameObject orderedFood = Instantiate(selectedFoodPrefab, foodPosition, Quaternion.identity);

        // 생성된 프리팹을 자식으로 설정
        orderedFood.transform.SetParent(guest.transform);

        // GuestMove 스크립트에 생성된 음식 프리팹의 참조 설정
        guest.orderedFood = orderedFood;
    }
}

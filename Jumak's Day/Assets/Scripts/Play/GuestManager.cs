using System.Collections.Generic;
using UnityEngine;

public class GuestManager : MonoBehaviour
{
    public GameObject[] guestPrefabList;
    public GameObject[] foodPrefabList;
    public Transform guestSpawnPos;
    public float speed = 1.5f;
    public float spawnInterval = 3.0f;

    public Transform[] cookingSlots;

    void Start()
    {
        InvokeRepeating("SpawnGuest", 0f, spawnInterval);
    }


    void SpawnGuest()
    {
        int randomIndex = Random.Range(0, guestPrefabList.Length);
        GameObject randomGuestPrefab = guestPrefabList[randomIndex];
        GameObject spawnedGuest = Instantiate(randomGuestPrefab, guestSpawnPos.position, Quaternion.identity);

        GuestMove guestMove = spawnedGuest.GetComponent<GuestMove>();
        guestMove.speed = speed;
        guestMove.guestManager = this;
    }

    public void OrderFood(GuestMove guest)
    {
        int randomIndex = Random.Range(0, foodPrefabList.Length);
        GameObject selectedFoodPrefab = foodPrefabList[randomIndex];

        Vector2 foodPosition = new Vector2(guest.transform.position.x + 0.7f, guest.transform.position.y + 0.7f);
        GameObject orderedFood = Instantiate(selectedFoodPrefab, foodPosition, Quaternion.identity);

        guest.orderedFood = orderedFood;
        orderedFood.transform.SetParent(guest.transform);

        Item item = orderedFood.GetComponent<Item>();
        item.currentState = Item.State.Ordered;

        // parentTransform วาด็
        item.parentTransform = guest.transform;
    }

}

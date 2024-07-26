using System.Collections.Generic;
using UnityEngine;

public class GuestManager : MonoBehaviour
{
    public GameObject[] guestPrefabList;
    public GameObject[] foodPrefabList;
    public Transform guestSpawnPos;
    public float speed = 1.0f;
    public float spawnInterval = 3.0f;
    public int counta;

    public Transform[] cookingSlots;

    void Start()
    {
        InvokeRepeating("SpawnGuest", 0f, spawnInterval);
    }

    void SpawnGuest()
    {
        if (counta > 1)
            return;

        int randomIndex = Random.Range(0, guestPrefabList.Length);
        GameObject randomGuestPrefab = guestPrefabList[randomIndex];
        GameObject spawnedGuest = Instantiate(randomGuestPrefab, guestSpawnPos.position, Quaternion.identity);

        GuestMove guestMove = spawnedGuest.GetComponent<GuestMove>();
        guestMove.targetTag = "Table";
        guestMove.speed = speed;
        guestMove.guestManager = this;
        counta++;
    }

    public void OrderFood(GuestMove guest)
    {
        int randomIndex = Random.Range(0, foodPrefabList.Length);
        GameObject selectedFoodPrefab = foodPrefabList[randomIndex];

        Vector2 foodPosition = new Vector2(guest.transform.position.x + 0.7f, guest.transform.position.y + 0.7f);
        GameObject orderedFood = Instantiate(selectedFoodPrefab, foodPosition, Quaternion.identity);

        orderedFood.transform.SetParent(guest.transform);
        guest.orderedFood = orderedFood;

        Item item = orderedFood.GetComponent<Item>();
        item.parentTransform = guest.transform;
        item.currentState = Item.State.Ordered;
    }

    public void CookFood()
    {
        foreach (Transform slot in cookingSlots)
        {
            if (slot.childCount == 0)
            {
                GameObject foodToCook = FindNextOrderedFood();
                if (foodToCook != null)
                {
                    foodToCook.transform.SetParent(slot);
                    foodToCook.transform.position = slot.position;
                    Item item = foodToCook.GetComponent<Item>();
                    item.currentState = Item.State.Cooked;
                }
            }
        }
    }

    GameObject FindNextOrderedFood()
    {
        foreach (GameObject food in foodPrefabList)
        {
            Item item = food.GetComponent<Item>();
            if (item.currentState == Item.State.Ordered)
            {
                return food;
            }
        }
        return null;
    }
}

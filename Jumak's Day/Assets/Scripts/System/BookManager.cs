using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookManager : MonoBehaviour
{
    public Text nameText;
    public Text descText;

    private ItemList itemList;

    // Start is called before the first frame update
    void Start()
    {
        itemList = FindObjectOfType<ItemList>();

        if (itemList == null)
        {
            Debug.LogError("ItemList not found in the scene. Ensure there is an ItemList object.");
            return;
        }
    }

    // 아이템 인덱스를 받아서 도감 정보를 업데이트하는 메서드
    public void UpdateItemDetails(int index)
    {
        if (itemList == null)
        {
            Debug.LogError("ItemList is null. Unable to update item details.");
            return;
        }

        ItemData itemData = itemList.GetItemData(index);

        if (itemData != null)
        {
            nameText.text = itemData.Name;
            descText.text = itemData.Description;
        }
        else
        {
            nameText.text = "쉿! 비밀이얌";
            descText.text = "게임을 플레이하여 열어보세요";
        }
    }
}

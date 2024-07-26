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

    // ������ �ε����� �޾Ƽ� ���� ������ ������Ʈ�ϴ� �޼���
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
            nameText.text = "��! ����̾�";
            descText.text = "������ �÷����Ͽ� �������";
        }
    }
}

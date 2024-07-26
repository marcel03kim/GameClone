using UnityEngine;
using UnityEngine.UI;

public class BookManager : MonoBehaviour
{
    public Text[] nameText;
    public Text[] descText;
    public Image[] itemImage;
    public Sprite noneSprite;

    private ItemList itemList;

    void Start()
    {
        itemList = FindObjectOfType<ItemList>();

        if (itemList == null)
        {
            Debug.LogError("ItemList가 씬에 없습니다. ItemList 오브젝트가 있는지 확인하세요.");
            return;
        }
    }

    public void UpdateItemDetails(int index)
    {
        if (itemList == null)
        {
            Debug.LogError("ItemList가 null입니다. 아이템 세부정보를 업데이트할 수 없습니다.");
            return;
        }

        // 모든 텍스트와 이미지 초기화
        foreach (var text in nameText)
        {
            if (text.gameObject.activeSelf)
            {
                text.text = "";
            }
        }

        foreach (var text in descText)
        {
            if (text.gameObject.activeSelf)
            {
                text.text = "";
            }
        }

        foreach (var image in itemImage)
        {
            if (image.gameObject.activeSelf)
            {
                image.sprite = noneSprite;
            }
        }

        ItemData itemData = itemList.GetItemData(index);

        if (index >= 0 && index <= 7 || index >= 100 && index <= 107)
        {
            for (int i = 0; i < nameText.Length; i++)
            {
                if (nameText[i].gameObject.activeSelf)
                {
                    nameText[i].text = itemData.Name;
                    break;
                }
            }

            for (int i = 0; i < descText.Length; i++)
            {
                if (descText[i].gameObject.activeSelf)
                {
                    descText[i].text = itemData.Description;
                    break;
                }
            }

            for (int i = 0; i < itemImage.Length; i++)
            {
                if (itemImage[i].gameObject.activeSelf)
                {
                    itemImage[i].sprite = itemData.Icon;
                    break;
                }
            }
        }
        else if (index >= 8 && index < 100 || index >= 108)
        {
            for (int i = 0; i < nameText.Length; i++)
            {
                if (nameText[i].gameObject.activeSelf)
                {
                    nameText[i].text = "쉿! 비밀이얌";
                    break;
                }
            }

            for (int i = 0; i < descText.Length; i++)
            {
                if (descText[i].gameObject.activeSelf)
                {
                    descText[i].text = "게임을 플레이하여 열어보세요";
                    break;
                }
            }

            for (int i = 0; i < itemImage.Length; i++)
            {
                if (itemImage[i].gameObject.activeSelf)
                {
                    itemImage[i].sprite = noneSprite;
                    break;
                }
            }
        }
    }
}

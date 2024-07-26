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
            Debug.LogError("ItemList�� ���� �����ϴ�. ItemList ������Ʈ�� �ִ��� Ȯ���ϼ���.");
            return;
        }
    }

    public void UpdateItemDetails(int index)
    {
        if (itemList == null)
        {
            Debug.LogError("ItemList�� null�Դϴ�. ������ ���������� ������Ʈ�� �� �����ϴ�.");
            return;
        }

        // ��� �ؽ�Ʈ�� �̹��� �ʱ�ȭ
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
                    nameText[i].text = "��! ����̾�";
                    break;
                }
            }

            for (int i = 0; i < descText.Length; i++)
            {
                if (descText[i].gameObject.activeSelf)
                {
                    descText[i].text = "������ �÷����Ͽ� �������";
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject setting;
    public GameObject food;
    public GameObject mission;
    public GameObject upgrade;

    public Button[] buttons;
    public Sprite purchaseSprite;
    public Sprite soldSprite;

    private void Start()
    {
        // ��ư Ŭ�� �̺�Ʈ �߰�
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }

        // ��� ��ư�� ��������Ʈ �ʱ�ȭ
        SetAllButtonsToPurchaseSprite();
    }

    private void SetAllButtonsToPurchaseSprite()
    {
        foreach (Button button in buttons)
        {
            // ��ư�� �̹��� ������Ʈ ��������
            Image buttonImage = button.GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.sprite = purchaseSprite;
            }
        }
    }

    private void OnButtonClick(Button clickedButton)
    {
        Image buttonImage = clickedButton.GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = soldSprite;
        }
    }
}

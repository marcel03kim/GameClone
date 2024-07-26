using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameManager GM; // GameManager ��ũ��Ʈ�� ����
    public GameObject[] prefabToAdd; // �߰��� ������
    public BookManager bookManager; // BookManager ��ũ��Ʈ�� ����

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
            // ��ư�� ID�� �����Ͽ� �� ��ư�� ����
            int buttonIndex = Array.IndexOf(buttons, button);
            button.onClick.AddListener(() => OnButtonClick(buttonIndex));
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

    private void OnButtonClick(int buttonIndex)
    {
        if (GM != null && prefabToAdd != null && buttonIndex < prefabToAdd.Length)
        {
            // ��ư �ε����� �ش��ϴ� ������ ��������
            GameObject selectedPrefab = prefabToAdd[buttonIndex];
            if (selectedPrefab != null)
            {
                Item item = selectedPrefab.GetComponent<Item>();
                if (item != null)
                {
                    // �����տ��� �ε��� ��ȣ�� �����ͼ� GameManager�� �߰�
                    int itemIndex = item.id;
                    GM.AddPrefab(selectedPrefab);

                    // BookManager�� ���� ������ ������ ������Ʈ
                    if (bookManager != null)
                    {
                        bookManager.UpdateItemDetails(itemIndex);
                    }
                    else
                    {
                        Debug.LogError("BookManager is not assigned.");
                    }

                    // ��ư �̹��� ������Ʈ
                    UpdateButtonSprite(buttonIndex);
                }
                else
                {
                    Debug.LogError("Item component is missing on the selected prefab.");
                }
            }
            else
            {
                Debug.LogError("Selected prefab is null.");
            }
        }
        else
        {
            Debug.LogError("GameManager or prefabToAdd is not assigned, or buttonIndex is out of range.");
        }
    }

    private void UpdateButtonSprite(int buttonIndex)
    {
        if (buttonIndex >= 0 && buttonIndex < buttons.Length)
        {
            Image buttonImage = buttons[buttonIndex].GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.sprite = soldSprite;
            }
        }
        else
        {
            Debug.LogError("Button index is out of range.");
        }
    }
}

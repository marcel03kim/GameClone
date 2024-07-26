using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameManager GM; // GameManager 스크립트를 참조
    public GameObject[] prefabToAdd; // 추가할 프리팹
    public BookManager bookManager; // BookManager 스크립트를 참조

    public GameObject menu;
    public GameObject setting;
    public GameObject food;
    public GameObject FoodDic;
    public GameObject GuestDic;
    public GameObject GDic;
    public GameObject FDic;
    public GameObject upgrade;

    public Button[] buttons;
    public Sprite purchaseSprite;
    public Sprite soldSprite;

    private void Start()
    {
        // 버튼 클릭 이벤트 추가
        foreach (Button button in buttons)
        {
            // 버튼에 ID를 설정하여 각 버튼을 구분
            int buttonIndex = Array.IndexOf(buttons, button);
            button.onClick.AddListener(() => OnButtonClick(buttonIndex));
        }

        // 모든 버튼의 스프라이트 초기화
        SetAllButtonsToPurchaseSprite();
    }
    public void SetActivePanel(string panelName)
    {
        // 모든 패널을 비활성화
        food.SetActive(false);
        FoodDic.SetActive(false);
        GuestDic.SetActive(false);
        GDic.SetActive(false);
        FDic.SetActive(false);
        upgrade.SetActive(false);
        menu.SetActive(false);
        setting.SetActive(false);

        // 전달받은 패널 이름에 따라 해당 패널을 활성화
        switch (panelName)
        {
            case "Menu":
                menu.SetActive(true);
                break;
            case "Food":
                food.SetActive(true);
                break;
            case "FD":
                GuestDic.SetActive(true);
                FoodDic.SetActive(true);
                break;
            case "GD":
                GuestDic.SetActive(true);
                break;
            case "GDic":
                GDic.SetActive(true);
                GuestDic.SetActive(true);
                break;
            case "FDic":
                FDic.SetActive(true);
                FoodDic.SetActive(true);
                break;
            case "Upgrade":
                upgrade.SetActive(true);
                break;
            case "Setting":
                setting.SetActive(true);
                break;
            default:
                Debug.LogError("Invalid panel name.");
                break;
        }
    }
    private void SetAllButtonsToPurchaseSprite()
    {
        foreach (Button button in buttons)
        {
            // 버튼의 이미지 컴포넌트 가져오기
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
            // 버튼 인덱스에 해당하는 프리팹 가져오기
            GameObject selectedPrefab = prefabToAdd[buttonIndex];
            if (selectedPrefab != null)
            {
                Item item = selectedPrefab.GetComponent<Item>();
                if (item != null)
                {
                    // 프리팹에서 인덱스 번호를 가져와서 GameManager에 추가
                    int itemIndex = item.id;
                    GM.AddPrefab(selectedPrefab);

                    // BookManager를 통해 아이템 정보를 업데이트
                    if (bookManager != null)
                    {
                        bookManager.UpdateItemDetails(itemIndex);
                    }
                    else
                    {
                        Debug.LogError("BookManager is not assigned.");
                    }

                    // 버튼 이미지 업데이트
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

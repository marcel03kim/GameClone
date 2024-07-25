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
        // 버튼 클릭 이벤트 추가
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }

        // 모든 버튼의 스프라이트 초기화
        SetAllButtonsToPurchaseSprite();
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

    private void OnButtonClick(Button clickedButton)
    {
        Image buttonImage = clickedButton.GetComponent<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = soldSprite;
        }
    }
}

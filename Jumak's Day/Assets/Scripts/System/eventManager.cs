using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public GameObject EventCanvas;
    public Text eventText;
    public int textNum;
    public Button[] buttons;
    public Text[] buttonText;

    public Image King;
    public Image Japan;
    public Image Gisaeng;
    public Image Yang;
    public Image KKa;
    public Image Jevi;
    public Image Jumo;

    public int Cpoint;
    public int Hpoint;

    private EventData eventData;

    private void Awake()
    {
        if (King != null) King.gameObject.SetActive(false);
        if (Japan != null) Japan.gameObject.SetActive(false);
        if (Yang != null) Yang.gameObject.SetActive(false);
        if (Gisaeng != null) Gisaeng.gameObject.SetActive(false);
        if (KKa != null) KKa.gameObject.SetActive(false);
        if (Jevi != null) Jevi.gameObject.SetActive(false);
        if (Jumo != null) Jumo.gameObject.SetActive(true);

        buttons[1].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(false);
        buttons[3].gameObject.SetActive(false);

        // Find or create the EventData instance
        eventData = FindObjectOfType<EventData>();
        if (eventData == null)
        {
            Debug.LogError("EventData instance not found!");
        }

        // Add button listeners
        if (buttons.Length > 0)
        {
            buttons[0].onClick.AddListener(OnButton0Click);
        }
    }

    void Start()
    {
        Time.timeScale = 0f;
    }

    public void EventStart(int eventId)
    {
        if (King != null) King.gameObject.SetActive(false);
        if (Japan != null) Japan.gameObject.SetActive(false);
        if (Yang != null) Yang.gameObject.SetActive(false);
        if (Gisaeng != null) Gisaeng.gameObject.SetActive(false);
        if (KKa != null) KKa.gameObject.SetActive(false);
        if (Jevi != null) Jevi.gameObject.SetActive(false);
        if (Jumo != null) Jumo.gameObject.SetActive(true);

        switch (eventId)
        {
            case 0:
                KingEvent();
                break;
            case 1:
                JEvent();
                break;
            case 2:
                KKaEvent();
                break;
            case 3:
                JeviEvent();
                break;
            case 4:
                GisaengEvent();
                break;
            case 5:
                HiddenJEvent();
                break;
            default:
                break;
        }
    }

    void KingEvent()
    {
        if (King != null) King.gameObject.SetActive(true);
        if (Jumo != null) Jumo.gameObject.SetActive(true);

        textNum = 0;
        DisplayEventText(textNum);

        // Add a check to update textNum and display buttons after the initial event text
        buttons[0].onClick.RemoveAllListeners(); // Remove previous listeners
        buttons[0].onClick.AddListener(() =>
        {
            textNum++;
            DisplayEventText(textNum);

            if (textNum > 2)
            {
                eventText.text = "���� �մ��� ��������� �Ѵ� ��� �ұ�?";

                buttons[1].gameObject.SetActive(true);
                buttons[2].gameObject.SetActive(true);

                buttonText[0].text = "�մ��� ���Ѵ´�";
                buttonText[1].text = "���� ��Ź�� �����Ѵ�";

                buttons[1].onClick.RemoveAllListeners();
                buttons[1].onClick.AddListener(() => EventEnd(5000, -30));

                buttons[2].onClick.RemoveAllListeners();
                buttons[2].onClick.AddListener(() => EventEnd(0, 200));
            }
        });
    }

    void JEvent()
    {
        if (Japan != null) Japan.gameObject.SetActive(true);
        if (Jumo != null) Jumo.gameObject.SetActive(true);

        textNum = 11;
        DisplayEventText(textNum);

        // Add a check to update textNum and display buttons after the initial event text
        buttons[0].onClick.RemoveAllListeners(); // Remove previous listeners
        buttons[0].onClick.AddListener(() =>
        {
            textNum++;
            DisplayEventText(textNum);

            if (textNum > 15)
            {
                eventText.text = "������ ��¥�� ���������? ��¼��?";

                buttons[1].gameObject.SetActive(true);
                buttons[2].gameObject.SetActive(true);
                buttons[3].gameObject.SetActive(true);

                buttonText[0].text = "������ �����ش�";
                buttonText[1].text = "�����Ѵ�";
                buttonText[2].text = "�ο��(?)";

                buttons[1].onClick.RemoveAllListeners();
                buttons[1].onClick.AddListener(() => EventEnd(0, -50));

                buttons[2].onClick.RemoveAllListeners();
                buttons[2].onClick.AddListener(() => EventEnd(-1000, 50));

                buttons[3].onClick.RemoveAllListeners();
                buttons[3].onClick.AddListener(() => HiddenJEvent());
            }
        });
    }

    void HiddenJEvent()
    {
        if (Japan != null) Japan.gameObject.SetActive(true);
        if (Jumo != null) Jumo.gameObject.SetActive(true);

        buttons[1].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(false);
        buttons[3].gameObject.SetActive(false);

        textNum = 16;
        DisplayEventText(textNum);

        buttons[0].onClick.RemoveAllListeners(); // Remove previous listeners
        buttons[0].onClick.AddListener(() =>
        {
            textNum++;
            DisplayEventText(textNum);

            if (textNum > 19)
            {
                EventEnd(1000, 500);
            }
        });
    }

    void KKaEvent()
    {
        if (KKa != null) KKa.gameObject.SetActive(true);
        if (Jumo != null) Jumo.gameObject.SetActive(true);

        textNum = 7;
        DisplayEventText(textNum);

        // Add a check to update textNum and display buttons after the initial event text
        buttons[0].onClick.RemoveAllListeners(); // Remove previous listeners
        buttons[0].onClick.AddListener(() =>
        {
            textNum++;
            DisplayEventText(textNum);

            if (textNum > 10)
            {
                EventEnd(-1000, -50);
            }
        });
    }

    void JeviEvent()
    {
        if (Jevi != null) Jevi.gameObject.SetActive(true);
        if (Jumo != null) Jumo.gameObject.SetActive(true);

        textNum = 3;
        DisplayEventText(textNum);

        // Add a check to update textNum and display buttons after the initial event text
        buttons[0].onClick.RemoveAllListeners(); // Remove previous listeners
        buttons[0].onClick.AddListener(() =>
        {
            textNum++;
            DisplayEventText(textNum);

            if (textNum > 6)
            {
                eventText.text = "��ģ ���� �ҽ��ϴ�. ��� �ұ�?";
                buttons[1].gameObject.SetActive(true);
                buttons[2].gameObject.SetActive(true);

                buttonText[0].text = "���� ġ�����ش�";
                buttonText[1].text = "�����Ѵ�";

                buttons[1].onClick.RemoveAllListeners();
                buttons[1].onClick.AddListener(() => EventEnd(-1000, -50));

                buttons[2].onClick.RemoveAllListeners();
                buttons[2].onClick.AddListener(() => EventEnd(-1000, -50));
            }
        });
    }

    void GisaengEvent()
    {
        if (Gisaeng != null) Gisaeng.gameObject.SetActive(true);
        if (Yang != null) Yang.gameObject.SetActive(true);
        if (Jumo != null) Jumo.gameObject.SetActive(true);

        textNum = 20;
        DisplayEventText(textNum);

        // Add a check to update textNum and display buttons after the initial event text
        buttons[0].onClick.RemoveAllListeners(); // Remove previous listeners
        buttons[0].onClick.AddListener(() =>
        {
            textNum++;
            DisplayEventText(textNum);

            if (textNum > 26)
            {
                EventEnd(0, 200);
            }
        });
    }

    void DisplayEventText(int index)
    {
        EventText eventTextData = eventData.GetTextData(index);
        if (eventText != null)
        {
            eventText.text = eventTextData.Text;
        }
        else
        {
            Debug.LogError("EventText UI component is not assigned!");
        }
    }
    // Method to handle button click
    void OnButton0Click()
    {
        textNum++;
        DisplayEventText(textNum);
    }

    void EventEnd(int Cpoint, int Hpoint)
    {
        Time.timeScale = 1.0f;
        EventCanvas.SetActive(false);
        GameManager.Instance.coin += Cpoint;
        GameManager.Instance.honor += Hpoint;
    }
}

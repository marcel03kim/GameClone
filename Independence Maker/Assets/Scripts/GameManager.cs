using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int health;
    public int intellect;
    public int korea;
    public int honor;
    public int luck;
    public int money;

    public Text healthText;
    public Text IntellectText;
    public Text koreaText;
    public Text honorText;
    public Text luckText;
    public Text moneyText;

    public void Update()
    {
        healthText.text = "�� :" + health;
        IntellectText.text = "���� :" + intellect;
        moneyText.text = "��� :" + money;
        koreaText.text = "�ֱ��� :" + korea;
        honorText.text = "�� :" + honor;
        luckText.text = "�� :" + luck;
    }
    public void AddValues(int v1, int v2, int v3, int v4, int v5, int v6)
    {
        health += v1;
        intellect += v2;
        korea += v3;
        honor += v4;
        luck += v5;
        money += v6;
    }
}

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
        healthText.text = "힘 :" + health;
        IntellectText.text = "지능 :" + intellect;
        moneyText.text = "재산 :" + money;
        koreaText.text = "애국심 :" + korea;
        honorText.text = "명예 :" + honor;
        luckText.text = "운 :" + luck;
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

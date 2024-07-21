using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatButton : MonoBehaviour
{
    public int health1;
    public int Intellect1;
    public int korea1;
    public int honor1;
    public int luck1;
    public int money1;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }

        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Button component not found on this GameObject.");
        }
    }

    private void OnButtonClick()
    {
        if (gameManager != null)
        {
            gameManager.AddValues(health1, Intellect1, korea1, honor1, luck1, money1);
        }
    }
}

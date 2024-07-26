using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public Text mainText;
    public Animator anim;

    private float Aduration = 2.0f; // ���İ� 1�� ���� ���� �ð�
    private float Bduration = 0.5f; // ���İ� 0���� 1�� ���ϴ� �ð�
    private float Cduration = 0.5f; // ���İ� 1���� 0���� ���ϴ� �ð�

    private void Start()
    {
        anim = GetComponent<Animator>();
        if (anim != null)
        {
            anim.Play("YourAnimationClipName");
        }
        else
        {
            Debug.LogError("Animator component is not assigned.");
        }

        if (mainText != null)
        {
            StartCoroutine(Fade());
        }
        else
        {
            Debug.LogError("Text component is not assigned.");
        }
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            Loading.LoadScene("GameScene");
        }
    }
    private IEnumerator Fade()
    {
        while (true)
        {
            // ���İ��� 0���� 1�� ����
            yield return StartCoroutine(FadeTo(1.0f, Bduration));
            // ���İ� 1�� ���� ����
            yield return new WaitForSeconds(Aduration);
            // ���İ��� 1���� 0���� ����
            yield return StartCoroutine(FadeTo(0.0f, Cduration));
        }
    }

    private IEnumerator FadeTo(float targetAlpha, float duration)
    {
        float startAlpha = mainText.color.a;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
            Color newColor = new Color(mainText.color.r, mainText.color.g, mainText.color.b, newAlpha);
            mainText.color = newColor;
            yield return null;
        }

        Color finalColor = new Color(mainText.color.r, mainText.color.g, mainText.color.b, targetAlpha);
        mainText.color = finalColor;
    }
}

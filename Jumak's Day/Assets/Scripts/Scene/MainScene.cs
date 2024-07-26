using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public Text mainText;
    public Animator anim;

    private float Aduration = 2.0f; // 알파값 1인 상태 유지 시간
    private float Bduration = 0.5f; // 알파값 0에서 1로 변하는 시간
    private float Cduration = 0.5f; // 알파값 1에서 0으로 변하는 시간

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
            // 알파값을 0에서 1로 변경
            yield return StartCoroutine(FadeTo(1.0f, Bduration));
            // 알파값 1인 상태 유지
            yield return new WaitForSeconds(Aduration);
            // 알파값을 1에서 0으로 변경
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

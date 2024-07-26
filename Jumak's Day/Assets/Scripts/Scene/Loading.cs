using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                             //UI 이미지에 접근하기 위한 코드
using UnityEngine.SceneManagement;                //Scene에 접근하기 위한 코드

public class Loading : MonoBehaviour
{
    public static string nextScene;             //다음에 불러 올 Scene을 위한 코드
    public Text tipText;

    private List<string> textList = new List<string>
    {
        "Tip! 날짜가 바뀌면 특별한 누군가를 만나게 될지도?",
        "Tip! 시간이 지나면 밤이 됩니다",
        "Tip! 왜놈을 조심하세요",
        "Tip! 상점에서 더 다양한 음식의 조리법을 구매할 수 있습니다",
        "Tip! 상점에서 주막을 업그레이드 할 수 있어요",
        "Tip! 더 많은 손님을 맞이해 도감을 채워보세요",
        "Tip! 메뉴엔 다양한 기능이 존재합니다"
    };

    [SerializeField] Image progressBar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene());
        if (tipText != null)
        {
            tipText.text = textList[Random.Range(0, textList.Count)];
        }
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
        Debug.Log(sceneName);
    }

    IEnumerator LoadScene()
    {
        yield return null;                           //LoadingScene을 불러오기 위한 코드
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;                    //Scene 전환 코드
        float timer = 0.0f;
        float fillSpeed = 0.5f;

        while (!op.isDone)                              //ProgressBar 관련 코드
        {
            yield return null;
            timer += Time.deltaTime;

            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer * fillSpeed);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer * fillSpeed);
                if (progressBar.fillAmount == 1.0f)
                {
                    yield return new WaitForSeconds(2.0f);    // 2초 동안 페이크 로딩
                    op.allowSceneActivation = true;          // 2초가 끝나면 Scene 전환
                    break;
                }
            }
        }
    }

}
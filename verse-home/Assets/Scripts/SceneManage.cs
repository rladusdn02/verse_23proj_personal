using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System.Runtime.CompilerServices;
using TMPro;

public class SceneManage : MonoBehaviour
{
    public CanvasGroup Fade_img;           // 페이드 이미지를 가리키는 캔버스 그룹
    public GameObject Loading;             // 로딩 UI를 가리키는 게임 오브젝트
    public TMP_Text Loading_text;           // 로딩 텍스트를 가리키는 TMP_Text
    float fadeDuration = 2;                // 페이드되는 시간

    public static SceneManage Instance
    {
        get
        {
            return instance;
        }
    }
    private static SceneManage instance;

    void Start()
    {
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;  // 씬 로딩 완료 이벤트에 OnSceneLoaded 메서드 추가
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  // 씬 로딩 완료 이벤트에서 OnSceneLoaded 메서드 제거
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Fade_img.DOFade(0, fadeDuration)
            .OnStart(() =>
            {
                Loading.SetActive(false);
            })
            .OnComplete(() =>
            {
                Fade_img.blocksRaycasts = false;
            });
    }

    public void ChangeScene(string sceneName)   // 씬을 변경하는 메서드, 씬 이름을 받아옴
    {
        Fade_img.DOFade(1, fadeDuration)
            .OnStart(() =>
            {
                Fade_img.blocksRaycasts = true; // 페이드 이미지 블록레이캐스트 활성화
            })
            .OnComplete(() =>
            {
                // 페이드 아웃 완료 후 Scene Load 메서드 호출
                StartCoroutine("LoadScene", sceneName); // Scene Load 코루틴 실행
            });
    }

    IEnumerator LoadScene(string sceneName)
    {
        Loading.SetActive(true);    // 로딩 UI를 활성화
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false; // 씬 전환을 막음

        float past_time = 0;
        float percentage = 0;

        while (!(async.isDone))
        {
            yield return null;

            past_time += Time.deltaTime;

            if (percentage >= 90)
            {
                percentage = Mathf.Lerp(percentage, 100, past_time);

                if (percentage == 100)
                {
                    async.allowSceneActivation = true;  // Scene 전환 허용
                }
            }
            else
            {
                percentage = Mathf.Lerp(percentage, async.progress * 100f, past_time);
                if (percentage >= 90) past_time = 0;
            }
            Loading_text.text = percentage.ToString("0") + "%"; // 로딩 텍스트 갱신
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading_anime_main : MonoBehaviour
{
    [SerializeField]
    Image Bar;
    [SerializeField]
    Button startButton;
    AsyncOperation op;
    AsyncOperation op2;

    void Start()
    {
        StartCoroutine(LoadSceneProcess());
        PlayerPrefs.DeleteAll();
    }
    IEnumerator LoadSceneProcess()
    {
        op = SceneManager.LoadSceneAsync("Cutscene&animation");
        op2 = SceneManager.LoadSceneAsync("MainScene");
        op.allowSceneActivation = false;
        op2.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone && !op2.isDone)
        {
            yield return new WaitForSecondsRealtime(0.01f);

            if (op.progress < 0.1f && op2.progress < 0.1f)
            {
                Bar.fillAmount = (op.progress + op2.progress) *1/200;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                Bar.fillAmount = Mathf.Lerp(0.1f, 1f, timer);
                if (Bar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    op2.allowSceneActivation = false;
                    yield break;
                }
            }
        }
    }
    public void go_main()
    {
        _AudioManager.instance.PlaySfx(_AudioManager.Sfx.∫Û∆ƒ¿œ);
        op2.allowSceneActivation = true;
        op.allowSceneActivation = false;
    }
}

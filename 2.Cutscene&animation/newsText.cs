using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class newsText : MonoBehaviour
{
    [SerializeField]
    TMP_Text targetText; //tmp로 지정된 텍스트
    [SerializeField]
    Image triangle; // 텍스트 우측 하단 삼각형

    [SerializeField]
    animation_Cam animation_Cam; //카메라 스크립트

    string text; // targetText의 텍스트 정보를 저장할 텍스트
    float delay = 1f; //텍스트 출력 지연 시간
    int textNumber = 0; // 텍스트 문장 넘버링

    [SerializeField]
    string[] newstexts; //뉴스 보도 자막에 들어갈 텍스트 배열

    void Start()
    {
        //텍스트 박스 크기 초기화
        gameObject.transform.localScale = new Vector3(0, 0, 0);

        //빈 텍스트 출력
        text = targetText.text.ToString();
        targetText.text = "";

        //뉴스 텍스트 창 생성
        StartCoroutine(newsTextBer());
    }
    IEnumerator newstext(float delay)// 뉴스 보도 텍스트,한 글자씩 생성
    {
        int count = 0;
        text = newstexts[textNumber];
        while (count != text.Length)
        {
            if (count < text.Length)
            { 
                targetText.text += text[count].ToString();
                count++;
            }
            _AudioManager.instance.PlaySfx(_AudioManager.Sfx.앵커대사2);
            yield return new WaitForSecondsRealtime(delay/50);
        }
        yield return new WaitForSecondsRealtime(delay * 3);
        if (textNumber+1 != newstexts.Length)
        {
            textNumber += 1;
            targetText.text = "";
            StartCoroutine(newstext(delay));
        }
        else
        {//모든 텍스트 출력 후
            //텍스트 상자 닫기
            _AudioManager.instance.PlaySfx(_AudioManager.Sfx.빈파일);
            StartCoroutine(destroynewsTextBer(delay));
            yield break;
        }

        yield return null;
    }
    IEnumerator newsTextBer()// 뉴스 텍스트 바 크기
    {
        yield return new WaitForSecondsRealtime(1.5f);
        // 커지면서 나타나기
        while (gameObject.transform.localScale != new Vector3(0.67f, 0.67f, 0.67f))
        {
            gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            yield return null;
        }
        //텍스트 출력
        StartCoroutine(newstext(delay));
    }
    IEnumerator destroynewsTextBer(float delay)//뉴스 텍스트바 사라지기
    {
        yield return new WaitForSecondsRealtime(delay);

        while (gameObject.transform.localScale != new Vector3(0, 0, 0))
        {
            gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            yield return null;
        }
        yield return new WaitForSecondsRealtime(0.5f);

        //카메라 이동
        animation_Cam.moveCam();
        yield break;
    }
}

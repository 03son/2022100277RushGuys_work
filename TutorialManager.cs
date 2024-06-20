using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Data;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;

    [Header("메인화면 텍스트")]
    [SerializeField]
    string[] s_newstexts_0; //튜토리얼 텍스트 배열

    [Header("봄 텍스트")]
    [SerializeField]
    string[] s_newstexts_1;
    [Header("봄 종료 텍스트")]
    [SerializeField]
    string[] f_newstexts_1;

    [Header("여름 텍스트")]
    [SerializeField]
    string[] s_newstexts_2; 
    [Header("여름 종료 텍스트")]
    [SerializeField]
    string[] f_newstexts_2;

    [Header("가을 텍스트")]
    [SerializeField]
    string[] s_newstexts_3;
    [Header("가을 종료 텍스트")]
    [SerializeField]
    string[] f_newstexts_3;

    [Header("겨울 텍스트")]
    [SerializeField]
    string[] s_newstexts_4;
    [Header("겨울 종료 텍스트")]
    [SerializeField]
    string[] f_newstexts_4;

    [Header("텍스트상자")]
    public GameObject textBar;

    [Header("텍스트 출력")]
    public TextMeshProUGUI tutoialText;

    [Header("크레딧 출력")]
    public GameObject credits;

    public GameObject fade;

    string[] T_text; 

    string text; // targetText의 텍스트 정보를 저장할 텍스트
    float delay = 1f; //텍스트 출력 지연 시간
    int textNumber = 0; // 텍스트 문장 넘버링
    bool FastText = false;
    public TextMeshProUGUI fast;
    //npc텍스트
    //npc대화창

    public int TutorialNum;

    void Awake()
    {
        //PlayerPrefs.DeleteAll();

        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this.gameObject);
    }

    public void setTutorial()
    {
        if (PlayerPrefs.HasKey("TutorialNum"))
        {
            TutorialNum = PlayerPrefs.GetInt("TutorialNum");
        }
        else TutorialNum = -1;
    }
    public void SettutorialNum(int tutorialNum)
    {
        TutorialNum += 1;
        PlayerPrefs.SetInt("TutorialNum", tutorialNum);
    }
    /*
    메인화면  = 0
    봄 시작전 = 1
    봄 끝 = 2
    여름 시작 전 = 3
    여름 끝 = 4
    가을 시작 전 = 5
    가을 끝 = 6
    겨울 시작 전 = 7
    겨울 끝 = 8
    엔딩 후 = 9
     */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && textBar.activeSelf)
        {
            if (!FastText)
            {
                //2배속
                FastText = true;
                delay = 0.25f;
                fast.color = new Color(0,0,255,255);
                return;
            }
            else if (FastText)
            {
                //1배속
                FastText = false;
                delay = 1f;
                fast.color = new Color(0, 0, 0,255);
                return;
            }
        }
        /*if (Input.GetKeyDown(KeyCode.Q) && textBar.activeSelf)
        {
            //창닫기
            textBar.SetActive(false);
            textNumber = 0;
            return;
        }*/
    }

    public void s_Tutorial_Text(int Number) //게임 시작 전
    {
        switch (Number+1)
        {
            case 0:
                T_text = s_newstexts_0;
                break;
            case 1:
                T_text = s_newstexts_1;
                break;
            case 3:
                T_text = s_newstexts_2;
                break;
            case 5:
                T_text = s_newstexts_3;
                break;
            case 7:
                T_text = s_newstexts_4;
                break;
        }
        StartCoroutine(openTextBar());
    }
    public void f_Tutorial_Text(int Number) //게임 끝난 후
    {
        switch (Number+1)
        {
            case 2:
                T_text = f_newstexts_1;
                break;
            case 4:
                T_text = f_newstexts_2;
                break;
            case 6:
                T_text = f_newstexts_3;
                break;
            case 8:
                T_text = f_newstexts_4;
                break;
        }
        StartCoroutine(openTextBar());
    }
    IEnumerator openTextBar()
    {
        textBar.SetActive(true);
        StartCoroutine(newstext());
        yield return null;
    }
    IEnumerator newstext()
    {
        int count = 0;
        tutoialText.text = "";
        text = T_text[textNumber];
        while (count != text.Length)
        {
            if (count < text.Length)
            {
                tutoialText.text += text[count].ToString();
                count++;
            }
            yield return new WaitForSecondsRealtime(delay / 50);
        }
        yield return new WaitForSecondsRealtime(delay * 3);
        if (textNumber +1 != T_text.Length)
        {
            tutoialText.text = "";
            textNumber += 1;
            StartCoroutine(newstext());
        }
        else
        {
            //모든 텍스트 출력 후
            //텍스트 상자 닫기
            textBar.SetActive(false);
            textNumber = 0;
            if (TutorialNum == 8)
            {
                //크래딧
                StartCoroutine(ending());
            }
            yield break;
        }

        yield return null;
    }

    IEnumerator ending()
    {
        fade.SetActive(true);
        Image i_fade = fade.gameObject.GetComponent<Image>();
        yield return new WaitForSecondsRealtime(1);
        while (i_fade.color.a < 1)
        {
            i_fade.color += new Color(0,0,0,0.1f);
        }
        credits.SetActive(true);
        while (i_fade.color.a > 0)
        {
            i_fade.color -= new Color(0, 0, 0, 0.1f);
        }
        fade.SetActive(false);
    }
    public IEnumerator endGame()
    {
        TutorialManager.instance.TutorialNum = 9;
        PlayerPrefs.SetInt("TutorialNum",9);
        yield return null;
        fade.SetActive(false);
        this.gameObject.SetActive(false);
    }
}

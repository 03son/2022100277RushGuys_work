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

    [Header("����ȭ�� �ؽ�Ʈ")]
    [SerializeField]
    string[] s_newstexts_0; //Ʃ�丮�� �ؽ�Ʈ �迭

    [Header("�� �ؽ�Ʈ")]
    [SerializeField]
    string[] s_newstexts_1;
    [Header("�� ���� �ؽ�Ʈ")]
    [SerializeField]
    string[] f_newstexts_1;

    [Header("���� �ؽ�Ʈ")]
    [SerializeField]
    string[] s_newstexts_2; 
    [Header("���� ���� �ؽ�Ʈ")]
    [SerializeField]
    string[] f_newstexts_2;

    [Header("���� �ؽ�Ʈ")]
    [SerializeField]
    string[] s_newstexts_3;
    [Header("���� ���� �ؽ�Ʈ")]
    [SerializeField]
    string[] f_newstexts_3;

    [Header("�ܿ� �ؽ�Ʈ")]
    [SerializeField]
    string[] s_newstexts_4;
    [Header("�ܿ� ���� �ؽ�Ʈ")]
    [SerializeField]
    string[] f_newstexts_4;

    [Header("�ؽ�Ʈ����")]
    public GameObject textBar;

    [Header("�ؽ�Ʈ ���")]
    public TextMeshProUGUI tutoialText;

    [Header("ũ���� ���")]
    public GameObject credits;

    public GameObject fade;

    string[] T_text; 

    string text; // targetText�� �ؽ�Ʈ ������ ������ �ؽ�Ʈ
    float delay = 1f; //�ؽ�Ʈ ��� ���� �ð�
    int textNumber = 0; // �ؽ�Ʈ ���� �ѹ���
    bool FastText = false;
    public TextMeshProUGUI fast;
    //npc�ؽ�Ʈ
    //npc��ȭâ

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
    ����ȭ��  = 0
    �� ������ = 1
    �� �� = 2
    ���� ���� �� = 3
    ���� �� = 4
    ���� ���� �� = 5
    ���� �� = 6
    �ܿ� ���� �� = 7
    �ܿ� �� = 8
    ���� �� = 9
     */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && textBar.activeSelf)
        {
            if (!FastText)
            {
                //2���
                FastText = true;
                delay = 0.25f;
                fast.color = new Color(0,0,255,255);
                return;
            }
            else if (FastText)
            {
                //1���
                FastText = false;
                delay = 1f;
                fast.color = new Color(0, 0, 0,255);
                return;
            }
        }
        /*if (Input.GetKeyDown(KeyCode.Q) && textBar.activeSelf)
        {
            //â�ݱ�
            textBar.SetActive(false);
            textNumber = 0;
            return;
        }*/
    }

    public void s_Tutorial_Text(int Number) //���� ���� ��
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
    public void f_Tutorial_Text(int Number) //���� ���� ��
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
            //��� �ؽ�Ʈ ��� ��
            //�ؽ�Ʈ ���� �ݱ�
            textBar.SetActive(false);
            textNumber = 0;
            if (TutorialNum == 8)
            {
                //ũ����
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class MainScene_UI_Button : MonoBehaviour
{
    [Header("����ȭ�� ��ư��")]
    [TooltipAttribute("������ư")]
    public Button setting_Button;

    [TooltipAttribute("���丮����ư")]
    public Button storymode_Button;

    [TooltipAttribute("��Ƽ����ư")]
    public Button Multiplaymode_Button;

    [TooltipAttribute("�ǻ��ư")]
    public Button clothes_Button;
    [TooltipAttribute("�ǻ� â")]
    public GameObject clothes;
    [TooltipAttribute("�ǻ� �ݱ�")]
    public Button clothesEsc;

    [Header("����â")]
    [TooltipAttribute("����â")]
    public GameObject setting;

    [TooltipAttribute("���� �ݱ�Esc ��ư")]
    public Button Esc_setting_Button;
    public GameObject Esc;

    [TooltipAttribute("����� ���� ��ư")]
    public Button Audio_Settings_Button;

    [TooltipAttribute("ȭ�� ���� ��ư")]
    public Button Screen_setting_Button;

    [TooltipAttribute("ũ���� ��ư")]
    public Button Credit_Button;

    [TooltipAttribute("���� ���� ��ư")]
    public Button Exit_Button;

    [Header("�ǻ��ư ���� �� ī�޶� ��ġ�̵�")]
    public GameObject cam;

    [Header("�� ���� â")]
    public GameObject mapselect;
    [Header("�� ���� �ݱ�")]
    public Button MapSelectEsc;

    [Header("���̵� �� ȭ��")]
    public GameObject fadeinImage;



    GameObject audioSetting;
    GameObject screenSetting;
    GameObject credits;

    void Awake()
    {
        FadeIn();
        //������� ���
        if (_AudioManager.instance != null)
        {
            _AudioManager.instance.PlayBgm(_AudioManager.Bgm.����ȭ��bgm);
        }
        return;
    }
    GameObject tutorialText;
    void Start()
    {
        SetButton();
        SetSettingObject();

        tutorialText = GameObject.Find("TutorialManager");
        StartCoroutine(on_tutorialText());

    }
    void SetButton()//AddListener �߰�
    {
        //����ȭ��
        setting_Button.onClick.AddListener(Setting); //����â �¿���
        storymode_Button.onClick.AddListener(StoryMode);//���丮��� ����
        Multiplaymode_Button.onClick.AddListener(MultiPlaymode);//��Ƽ
        clothes_Button.onClick.AddListener(Clothes);//����
        clothesEsc.onClick.AddListener(cloesclothes);

        //����ȭ��
        Exit_Button.onClick.AddListener(Exit);//��������
        Audio_Settings_Button.onClick.AddListener(audiosetting);//���������â
        Screen_setting_Button.onClick.AddListener(screensettig);//ȭ�鼳��â
        Credit_Button.onClick.AddListener(Credits);//ȭ�鼳��â
        
        //Esc ��ư
        Esc_setting_Button.onClick.AddListener(esc);//esc

        MapSelectEsc.onClick.AddListener(cloesMapSelect);//�� ����â �ݱ�
    }
    void SetSettingObject()//�����, ȭ��, ũ������� â ����
    {
        audioSetting = GetComponent<Setting_UI_Object>().audioSetting;
        screenSetting = GetComponent<Setting_UI_Object>().screenSetting;
        credits = GetComponent<Setting_UI_Object>().credits;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mapselect.activeSelf && TutorialManager.instance.TutorialNum < 9)
            {
                return;
            }
            if (!mapselect.activeSelf)
            {
                if (clothes.activeSelf != true)
                {
                    if (setting.activeSelf && (audioSetting.activeSelf || screenSetting.activeSelf || credits.activeSelf))
                    {
                        if (audioSetting.activeSelf)
                        {
                            audioSetting.SetActive(false);
                        }
                        if (screenSetting.activeSelf)
                        {
                            screenSetting.SetActive(false);
                        }
                        if (credits.activeSelf)
                        {
                            credits.SetActive(false);
                        }
                        return;
                    }
                    if (!setting.activeSelf)
                    {
                        Setting();
                    }
                    else if (setting.activeSelf && !(audioSetting.activeSelf && screenSetting.activeSelf && credits.activeSelf))
                        CloseSetting();
                }
                else StartCoroutine(cloesClothes());
            }
            else cloesMapSelect();
        }
    }

    void FadeIn()
    {
        if (!fadeinImage.activeSelf)
        {
            fadeinImage.SetActive(true);
        }
        return;
    }
    void Setting()
    {
        if (clothes.activeSelf)
        {
            StartCoroutine(cloesClothes());
        }
        if (!setting.activeSelf)
        {
            setting.SetActive(true);
            Esc.SetActive(true);
        }
    }
    void StoryMode()
    {
        if (!mapselect.activeSelf)
        {
            mapselect.SetActive(true);
        }
    }
    void MultiPlaymode()
    {
        Debug.Log("��Ƽ�÷��� ���");
    }
    void Clothes()
    {
        clothes.SetActive(true);
    }
    public void cloesclothes()
    {
        StartCoroutine(cloesClothes());
    }
    IEnumerator cloesClothes()
    {
        if (clothes.activeSelf)
        {
            cam.GetComponent<clothes>().StartCoroutine(cam.GetComponent<clothes>().CamDisable_Move());
        }
        if (clothes.activeSelf)
        {
            int xpos = -500;
            while (xpos >= -1450)
            {
                clothes.GetComponent<RectTransform>().anchoredPosition = new Vector3(xpos, 0, 0);
                xpos -= 50;
                yield return null;
            }
        }
    }

    void cloesMapSelect()
    {
        if (mapselect.activeSelf && TutorialManager.instance.TutorialNum > 8)
        {
            mapselect.SetActive(false);
        }
    }
    void esc()
    {
        if (TutorialManager.instance.TutorialNum == 8)
        {
            return;
        }
        if (mapselect.activeSelf)
        {
            mapselect.SetActive(false);
            return;
        }
        if (setting.activeSelf && (audioSetting.activeSelf || screenSetting.activeSelf || credits.activeSelf))
        {
            if (audioSetting.activeSelf)
            {
                audioSetting.SetActive(false);
            }
            if (screenSetting.activeSelf)
            {
                screenSetting.SetActive(false);
            }
            if (credits.activeSelf)
            {
                credits.SetActive(false);
            }
            return;
        }
        if (!setting.activeSelf)
        {
            Setting();
        }
        else if (setting.activeSelf && !(audioSetting.activeSelf && screenSetting.activeSelf && credits.activeSelf))
            CloseSetting();
    }
    void CloseSetting()
    {
        if (setting.activeSelf)
        {
            setting.SetActive(false);
            Esc.SetActive(false);
        }
    }
    void Exit()
    {
        GetComponent<Exit>().exitGame();
    }

    void audiosetting()
    {
        if (!audioSetting.activeSelf)
        {
            audioSetting.SetActive(true);
        }
    }
    void screensettig()
    {
        if (!screenSetting.activeSelf)
        {
            screenSetting.SetActive(true);
        }else screenSetting.SetActive(false);
    }
    void Credits()
    {
        if (!credits.activeSelf)
        {
            credits.SetActive(true);
        }else credits.SetActive(false);
    }

    public void clickEff()
    {
        if (_AudioManager.instance != null)
        {
            _AudioManager.instance.PlaySfx(_AudioManager.Sfx.uiŬ����);
        }
    }
    IEnumerator on_tutorialText() // ���丮 �ؽ�Ʈ
    {
        GameObject tutorialText = GameObject.Find("TutorialManager");
        yield return null;
        if (tutorialText)
        {
            int tutorialNum = tutorialText.GetComponent<TutorialManager>().TutorialNum;
            switch (tutorialNum)
            {
                case -1: //����ȭ��
                    tutorialText.GetComponent<TutorialManager>().s_Tutorial_Text(tutorialNum);
                    tutorialText.GetComponent<TutorialManager>().SettutorialNum(tutorialNum);
                    break;
                case 1: // �� ��
                    tutorialText.GetComponent<TutorialManager>().f_Tutorial_Text(tutorialNum);
                    tutorialText.GetComponent<TutorialManager>().SettutorialNum(tutorialNum);
                    break;
                case 3: // ���� ��
                    tutorialText.GetComponent<TutorialManager>().f_Tutorial_Text(tutorialNum);
                    tutorialText.GetComponent<TutorialManager>().SettutorialNum(tutorialNum);
                    break;
                case 5: // ���� ��
                    tutorialText.GetComponent<TutorialManager>().f_Tutorial_Text(tutorialNum);
                    tutorialText.GetComponent<TutorialManager>().SettutorialNum(tutorialNum);
                    break;
                case 7: // �ܿ� ��
                    tutorialText.GetComponent<TutorialManager>().f_Tutorial_Text(tutorialNum);
                    tutorialText.GetComponent<TutorialManager>().SettutorialNum(tutorialNum);
                    PlayerPrefs.SetInt("tutorial_clear", 1); //���丮 �Ϸ� ���
                    break;
            }
        }
    }
}

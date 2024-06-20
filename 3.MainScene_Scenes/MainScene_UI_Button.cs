using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class MainScene_UI_Button : MonoBehaviour
{
    [Header("메인화면 버튼들")]
    [TooltipAttribute("설정버튼")]
    public Button setting_Button;

    [TooltipAttribute("스토리모드버튼")]
    public Button storymode_Button;

    [TooltipAttribute("멀티모드버튼")]
    public Button Multiplaymode_Button;

    [TooltipAttribute("의상버튼")]
    public Button clothes_Button;
    [TooltipAttribute("의상 창")]
    public GameObject clothes;
    [TooltipAttribute("의상 닫기")]
    public Button clothesEsc;

    [Header("설정창")]
    [TooltipAttribute("설정창")]
    public GameObject setting;

    [TooltipAttribute("설정 닫기Esc 버튼")]
    public Button Esc_setting_Button;
    public GameObject Esc;

    [TooltipAttribute("오디오 설정 버튼")]
    public Button Audio_Settings_Button;

    [TooltipAttribute("화면 설정 버튼")]
    public Button Screen_setting_Button;

    [TooltipAttribute("크레딧 버튼")]
    public Button Credit_Button;

    [TooltipAttribute("게임 종료 버튼")]
    public Button Exit_Button;

    [Header("의상버튼 닫을 때 카메라 위치이동")]
    public GameObject cam;

    [Header("맵 선택 창")]
    public GameObject mapselect;
    [Header("맵 선택 닫기")]
    public Button MapSelectEsc;

    [Header("페이드 인 화면")]
    public GameObject fadeinImage;



    GameObject audioSetting;
    GameObject screenSetting;
    GameObject credits;

    void Awake()
    {
        FadeIn();
        //배경음악 재생
        if (_AudioManager.instance != null)
        {
            _AudioManager.instance.PlayBgm(_AudioManager.Bgm.메인화면bgm);
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
    void SetButton()//AddListener 추가
    {
        //메인화면
        setting_Button.onClick.AddListener(Setting); //설정창 온오프
        storymode_Button.onClick.AddListener(StoryMode);//스토리모드 진입
        Multiplaymode_Button.onClick.AddListener(MultiPlaymode);//멀티
        clothes_Button.onClick.AddListener(Clothes);//옷장
        clothesEsc.onClick.AddListener(cloesclothes);

        //설정화면
        Exit_Button.onClick.AddListener(Exit);//게임종료
        Audio_Settings_Button.onClick.AddListener(audiosetting);//오디오설정창
        Screen_setting_Button.onClick.AddListener(screensettig);//화면설정창
        Credit_Button.onClick.AddListener(Credits);//화면설정창
        
        //Esc 버튼
        Esc_setting_Button.onClick.AddListener(esc);//esc

        MapSelectEsc.onClick.AddListener(cloesMapSelect);//맵 선택창 닫기
    }
    void SetSettingObject()//오디오, 화면, 크레딧등등 창 연결
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
        Debug.Log("멀티플레이 모드");
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
            _AudioManager.instance.PlaySfx(_AudioManager.Sfx.ui클릭음);
        }
    }
    IEnumerator on_tutorialText() // 스토리 텍스트
    {
        GameObject tutorialText = GameObject.Find("TutorialManager");
        yield return null;
        if (tutorialText)
        {
            int tutorialNum = tutorialText.GetComponent<TutorialManager>().TutorialNum;
            switch (tutorialNum)
            {
                case -1: //메인화면
                    tutorialText.GetComponent<TutorialManager>().s_Tutorial_Text(tutorialNum);
                    tutorialText.GetComponent<TutorialManager>().SettutorialNum(tutorialNum);
                    break;
                case 1: // 봄 끝
                    tutorialText.GetComponent<TutorialManager>().f_Tutorial_Text(tutorialNum);
                    tutorialText.GetComponent<TutorialManager>().SettutorialNum(tutorialNum);
                    break;
                case 3: // 여름 끝
                    tutorialText.GetComponent<TutorialManager>().f_Tutorial_Text(tutorialNum);
                    tutorialText.GetComponent<TutorialManager>().SettutorialNum(tutorialNum);
                    break;
                case 5: // 가을 끝
                    tutorialText.GetComponent<TutorialManager>().f_Tutorial_Text(tutorialNum);
                    tutorialText.GetComponent<TutorialManager>().SettutorialNum(tutorialNum);
                    break;
                case 7: // 겨울 끝
                    tutorialText.GetComponent<TutorialManager>().f_Tutorial_Text(tutorialNum);
                    tutorialText.GetComponent<TutorialManager>().SettutorialNum(tutorialNum);
                    PlayerPrefs.SetInt("tutorial_clear", 1); //스토리 완료 기록
                    break;
            }
        }
    }
}

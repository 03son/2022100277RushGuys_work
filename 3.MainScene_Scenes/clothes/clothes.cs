using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;
//using static UnityEditor.PlayerSettings;

public class clothes : MonoBehaviour
{
    [Header("캐릭터 변경")]
    public Button Char; //캐릭터 슬롯 버튼
    public Image Char_Button_imgae;
    public Image Char_imgae;
    public GameObject Characterlist;//캐릭터 선택 이미지

    [Header("캐릭터 스킨 변경")]
    public Button Char_skin; //캐릭터 스킨 버튼
    public Image Charskin_Button_imgae;
    public Image Charskin_imgae;
    public GameObject skinlist;

    [Header("카메라")]
    public GameObject cam;

    RectTransform Pos;

    int xpos;
    Image[] Chane_clothesButtons_Image;
    GameObject[] list_Object;
    Image[] list_Image;

    public GameObject skin_Choice;

    Color32 selectColor = new Color32(160, 170, 255, 255);
    Color32 White = new Color32(255, 255, 255, 255);
    void Start()
    {
        Char.onClick.AddListener(ChangeChar);  
        Char_skin.onClick.AddListener(ChangeSkin);

        Chane_clothesButtons_Image = new Image[2]; // 버튼 이미지 리스트
        Chane_clothesButtons_Image[0] = Char_Button_imgae;
        Chane_clothesButtons_Image[1] = Charskin_Button_imgae;

        list_Object = new GameObject[2];
        list_Object[0] = Characterlist;
        list_Object[1] = skinlist;

        list_Image = new Image[2];
        list_Image[0] = Char_imgae;
        list_Image[1] = Charskin_imgae;


        Chane_clothesButtons_Image[0].color = selectColor;//처음에 선택된 버튼
        list_Image[0].color = selectColor;
        list_Object[0].SetActive(true);//처음 선택
    }
    void OnEnable()
    {
        cam.transform.position = new Vector3(10,0,0);
        cam.transform.rotation = Quaternion.Euler(0,-90,0);

        StartCoroutine(enable_Move());
        StartCoroutine(Camenable_Move());
        Pos = GetComponent<RectTransform>();
    }
    IEnumerator enable_Move()
    {
        xpos = -1450;
        if (GetComponent<RectTransform>().anchoredPosition.x != -500)
        {
            while (xpos <= -800)
            {
                GetComponent<RectTransform>().anchoredPosition = new Vector3(xpos, 0, 0);
                xpos += 50;
                yield return null;
            }
            while (xpos > -800 && xpos <= -500)
            {
                GetComponent<RectTransform>().anchoredPosition = new Vector3(xpos, 0, 0);
                xpos += 20;
                yield return null;
            }
            yield return null;
        }
        yield return null;
    }
    IEnumerator Camenable_Move()
    {
        float xpos = 10;
        float ypos = 0;
        float zpos = 0;
        cam.transform.position = new Vector3(xpos, ypos, zpos);
        while (xpos > 8.6)
        {
            xpos -= 0.1f;
            if (ypos > 0.17f)
            {
                ypos -= 0.05f;
            }
            if (zpos < -1.27f)
            {
                zpos += 0.05f;
            }
            cam.transform.position = new Vector3(xpos, ypos, zpos);
            yield return null;
        }
        cam.transform.position = new Vector3(8.6f, 0.17f, -1.27f);
        yield return null;
    }
    public IEnumerator CamDisable_Move()
    {
        float xpos = 8.6f;
        float ypos = 0.17f;
        float zpos = -1.27f;
        cam.transform.position = new Vector3(xpos, ypos, zpos);
        while (xpos < 10)
        {
            xpos += 0.1f;
            if (ypos < 0)
            {
                ypos += 0.05f;
            }
            if (zpos > 0)
            {
                zpos -= 0.05f;
            }
            cam.transform.position = new Vector3(xpos, ypos, zpos);
            yield return null;
        }
        cam.transform.position = new Vector3(10, 0, 0);
        gameObject.SetActive(false);
        yield return null;
    }

    void ChangeChar()
    {
        CheckButtonNum(0);
    }

    void ChangeSkin()
    {
        CheckButtonNum(1);
    }

    void CheckButtonNum(int Num)//번호 체크 후 색 변경
    {
        for (int i = 0; i < Chane_clothesButtons_Image.Length; i++)
        {
            if (Chane_clothesButtons_Image[i].color == selectColor && list_Image[i].color == selectColor && Num == i)
                return;

            if (Chane_clothesButtons_Image[i].color == White && Num == i)
            {
                //선택한 버튼의 색을 바꾼다
                Chane_clothesButtons_Image[i].color = selectColor;
                list_Image[i].color = selectColor;
                list_Object[i].SetActive(true);
                skin_Choice.GetComponent<skin_Choice>().CheckChar();
            }
            else
            {
                Chane_clothesButtons_Image[i].color = White;
                list_Image[i].color = Color.white;
                list_Object[i].SetActive(false);
            }
            //선택한 버튼이 아니면 흰색으로 바꾼다
        }
    }
}

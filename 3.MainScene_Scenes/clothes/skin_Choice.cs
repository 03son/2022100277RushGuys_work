using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skin_Choice : MonoBehaviour
{
    public Button skin_1; 
    public Button skin_2;
    public Button skin_3;

    public GameObject g_skin_1;
    public GameObject g_skin_2;
    public GameObject g_skin_3;

    public Sprite[] skinSprites = new Sprite[9];

    private void Start()
    {

        skin_1.onClick.AddListener(skin1);
        skin_2.onClick.AddListener(skin2);
        skin_3.onClick.AddListener(skin3);
    }
    void OnEnable()
    {
        CheckChar();
    }
    void skin1() //캐릭터별 1번스킨
    {
        int Num = 0;
        if (PlayerInformationManager.instance.PlayerCharacterNum == 0)
        {
            PlayerPrefs.SetInt("Rabbit_Skin", Num);
        }
        if (PlayerInformationManager.instance.PlayerCharacterNum == 1)
        {
            PlayerPrefs.SetInt("Bear_Skin", Num);
        }
        if (PlayerInformationManager.instance.PlayerCharacterNum == 2)
        {
            PlayerPrefs.SetInt("Duck_Skin", Num);
        }
        if (PlayerInformationManager.instance.PlayerCharacterNum == 3)
        {
            PlayerPrefs.SetInt("Penguin_Skin", Num);
        }
        ChoiceSkin();
    }
    void skin2()
    {
        int Num = 1;
        if (PlayerInformationManager.instance.PlayerCharacterNum == 0)
        {
            PlayerPrefs.SetInt("Rabbit_Skin", Num);
        }
        if (PlayerInformationManager.instance.PlayerCharacterNum == 1)
        {
            PlayerPrefs.SetInt("Bear_Skin", Num);
        }
        if (PlayerInformationManager.instance.PlayerCharacterNum == 2)
        {
            PlayerPrefs.SetInt("Duck_Skin", Num);
        }
        if (PlayerInformationManager.instance.PlayerCharacterNum == 3)
        {
            PlayerPrefs.SetInt("Penguin_Skin", Num);
        }
        ChoiceSkin();
    }
    void skin3()
    {
        int Num = 2;
        if (PlayerInformationManager.instance.PlayerCharacterNum == 0)
        {
            PlayerPrefs.SetInt("Rabbit_Skin", Num);
        }
        if (PlayerInformationManager.instance.PlayerCharacterNum == 1)
        {
            PlayerPrefs.SetInt("Bear_Skin", Num);
        }
        if (PlayerInformationManager.instance.PlayerCharacterNum == 2)
        {
            PlayerPrefs.SetInt("Duck_Skin", Num);
        }
        if (PlayerInformationManager.instance.PlayerCharacterNum == 3)
        {
            PlayerPrefs.SetInt("Penguin_Skin", Num);
        }
        ChoiceSkin();
    }
    void skin4()
    {

    }
    void ChoiceSkin()
    {
        PlayerInformationManager.instance.PlayerCharacter();
        Set_PlayerCharacterSkin.Instance.SelectSkin();
    }

    public void CheckChar()
    {
        if (PlayerInformationManager.instance.PlayerCharacterNum != 0)
        {
            g_skin_3.SetActive(false);
        }
        else g_skin_3.SetActive(true);

        //스킨 이미지
        if (PlayerInformationManager.instance.PlayerCharacterNum == 0)
        {
            g_skin_1.GetComponent<Image>().sprite = skinSprites[0];
            g_skin_2.GetComponent<Image>().sprite = skinSprites[1];
            g_skin_3.GetComponent<Image>().sprite = skinSprites[2];
        }
        if (PlayerInformationManager.instance.PlayerCharacterNum == 1)
        {
            g_skin_1.GetComponent<Image>().sprite = skinSprites[3];
            g_skin_2.GetComponent<Image>().sprite = skinSprites[4];
        }
        if (PlayerInformationManager.instance.PlayerCharacterNum == 2)
        {
            g_skin_1.GetComponent<Image>().sprite = skinSprites[5];
            g_skin_2.GetComponent<Image>().sprite = skinSprites[6];
        }
        if (PlayerInformationManager.instance.PlayerCharacterNum == 3)
        {
            g_skin_1.GetComponent<Image>().sprite = skinSprites[7];
            g_skin_2.GetComponent<Image>().sprite = skinSprites[8];
        }
    }
}

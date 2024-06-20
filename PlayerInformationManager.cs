using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformationManager : MonoBehaviour
{
    //플레이어의 정보를 관리하는 스크립트
    public static PlayerInformationManager instance;

    public string PlayerNickName;
    public int PlayerCharacterNum; // 캐릭터 번호

    public int PlayerCharacterSkinNum_Rabbit; // 스킨 번호
    public int PlayerCharacterSkinNum_Bear; // 스킨 번호
    public int PlayerCharacterSkinNum_Duck; // 스킨 번호
    public int PlayerCharacterSkinNum_Penguin; // 스킨 번호

    public int PlayerKeyNumber; //갖고 있는 열쇠 개수

    public int TutorialValue;

    
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        PlayerCharacter();
    }
    public void PlayerCharacter()
    {
        //캐릭터 종류
        if (PlayerPrefs.HasKey("Character") == true)//저장 된 닉네임 일 때
        {
            //캐릭터 번호 불러와서 변수에 담는다
            PlayerCharacterNum = PlayerPrefs.GetInt("Character");
        }
        else PlayerCharacterNum = 0; //기본 캐릭터

        //캐릭터 스킨(토끼)
        if (PlayerPrefs.HasKey("Rabbit_Skin") == true)//저장 된 닉네임 일 때
        {
            //스킨 번호 불러와서 변수에 담는다
            PlayerCharacterSkinNum_Rabbit = PlayerPrefs.GetInt("Rabbit_Skin");
        }
        else PlayerCharacterSkinNum_Rabbit = 0; //기본 스킨
        
        //캐릭터 스킨(곰)
        if (PlayerPrefs.HasKey("Bear_Skin") == true)//저장 된 닉네임 일 때
        {
            //스킨 번호 불러와서 변수에 담는다
            PlayerCharacterSkinNum_Bear = PlayerPrefs.GetInt("Bear_Skin");
        }
        else PlayerCharacterSkinNum_Bear = 0; //기본 스킨
       
        //캐릭터 스킨(오리)
        if (PlayerPrefs.HasKey("Duck_Skin") == true)//저장 된 닉네임 일 때
        {
            //스킨 번호 불러와서 변수에 담는다
            PlayerCharacterSkinNum_Duck = PlayerPrefs.GetInt("Duck_Skin");
        }
        else PlayerCharacterSkinNum_Duck = 0; //기본 스킨
      
        //캐릭터 스킨(펭귄)
        if (PlayerPrefs.HasKey("Penguin_Skin") == true)//저장 된 닉네임 일 때
        {
            //스킨 번호 불러와서 변수에 담는다
            PlayerCharacterSkinNum_Penguin = PlayerPrefs.GetInt("Penguin_Skin");
        }
        else PlayerCharacterSkinNum_Penguin = 0; //기본 스킨

        //플레이어가 얻은 키 개수
        if (PlayerPrefs.HasKey("Key") == true)//저장 된 닉네임 일 때
        {
            //열쇠 개수 불러와서 변수에 담는다
            PlayerKeyNumber = PlayerPrefs.GetInt("Key");
        }
        else PlayerKeyNumber = 0; //열쇠 0개

        Debug.Log("캐릭터 번호 = "+PlayerCharacterNum);

        Debug.Log("토끼 스킨 번호 = "+ PlayerCharacterSkinNum_Rabbit);
        Debug.Log("곰 스킨 번호 = "+ PlayerCharacterSkinNum_Bear);
        Debug.Log("오리 스킨 번호 = "+ PlayerCharacterSkinNum_Duck);
        Debug.Log("펭귄 스킨 번호 = "+ PlayerCharacterSkinNum_Penguin);

        Debug.Log("얻은 열쇠 개수 = "+PlayerKeyNumber);
    }


}

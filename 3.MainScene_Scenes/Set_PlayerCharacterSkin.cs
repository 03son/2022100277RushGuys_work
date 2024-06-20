using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_PlayerCharacterSkin : MonoBehaviour
{
    public static Set_PlayerCharacterSkin Instance;

    [Header("토끼스킨 머터리얼")]
    public Material[] Rabbit_skinMaterial; //캐릭터 번호 = 0

    [Header("곰 스킨 머터리얼")]
    public Material[] Bear_skinMaterial; // 캐릭터 번호 = 1

    [Header("오리 스킨 머터리얼")]
    public Material[] Duck_skinMaterial; // 캐릭터 번호 = 2

    [Header("펭귄 스킨 머터리얼")]
    public Material[] penguin_skinMaterial; // 캐릭터 번호 = 3

    [Header("캐릭터의 머터리얼")]
    [SerializeField]
    GameObject[] CharMaterial; //적용할 캐릭터의 머터리얼 경로

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
     void Start()
    {
        SelectSkin();
    }

    public void SelectSkin()//스킨 적용
    {
        switch (PlayerInformationManager.instance.PlayerCharacterNum)
        { 
            case 0://토끼
                CharMaterial[0].GetComponent<SkinnedMeshRenderer>().material = Rabbit_skinMaterial[PlayerInformationManager.instance.PlayerCharacterSkinNum_Rabbit];
                break;
            case 1://곰
                CharMaterial[1].GetComponent<SkinnedMeshRenderer>().material = Bear_skinMaterial[PlayerInformationManager.instance.PlayerCharacterSkinNum_Bear];
                break;
            case 2://오리
                CharMaterial[2].GetComponent<SkinnedMeshRenderer>().material = Duck_skinMaterial[PlayerInformationManager.instance.PlayerCharacterSkinNum_Duck];
                break;
            case 3://펭귄
                CharMaterial[3].GetComponent<SkinnedMeshRenderer>().material = penguin_skinMaterial[PlayerInformationManager.instance.PlayerCharacterSkinNum_Penguin];
                break;
        }
    }


}

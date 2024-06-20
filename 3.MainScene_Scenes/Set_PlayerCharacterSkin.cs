using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_PlayerCharacterSkin : MonoBehaviour
{
    public static Set_PlayerCharacterSkin Instance;

    [Header("�䳢��Ų ���͸���")]
    public Material[] Rabbit_skinMaterial; //ĳ���� ��ȣ = 0

    [Header("�� ��Ų ���͸���")]
    public Material[] Bear_skinMaterial; // ĳ���� ��ȣ = 1

    [Header("���� ��Ų ���͸���")]
    public Material[] Duck_skinMaterial; // ĳ���� ��ȣ = 2

    [Header("��� ��Ų ���͸���")]
    public Material[] penguin_skinMaterial; // ĳ���� ��ȣ = 3

    [Header("ĳ������ ���͸���")]
    [SerializeField]
    GameObject[] CharMaterial; //������ ĳ������ ���͸��� ���

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

    public void SelectSkin()//��Ų ����
    {
        switch (PlayerInformationManager.instance.PlayerCharacterNum)
        { 
            case 0://�䳢
                CharMaterial[0].GetComponent<SkinnedMeshRenderer>().material = Rabbit_skinMaterial[PlayerInformationManager.instance.PlayerCharacterSkinNum_Rabbit];
                break;
            case 1://��
                CharMaterial[1].GetComponent<SkinnedMeshRenderer>().material = Bear_skinMaterial[PlayerInformationManager.instance.PlayerCharacterSkinNum_Bear];
                break;
            case 2://����
                CharMaterial[2].GetComponent<SkinnedMeshRenderer>().material = Duck_skinMaterial[PlayerInformationManager.instance.PlayerCharacterSkinNum_Duck];
                break;
            case 3://���
                CharMaterial[3].GetComponent<SkinnedMeshRenderer>().material = penguin_skinMaterial[PlayerInformationManager.instance.PlayerCharacterSkinNum_Penguin];
                break;
        }
    }


}

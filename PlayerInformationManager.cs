using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformationManager : MonoBehaviour
{
    //�÷��̾��� ������ �����ϴ� ��ũ��Ʈ
    public static PlayerInformationManager instance;

    public string PlayerNickName;
    public int PlayerCharacterNum; // ĳ���� ��ȣ

    public int PlayerCharacterSkinNum_Rabbit; // ��Ų ��ȣ
    public int PlayerCharacterSkinNum_Bear; // ��Ų ��ȣ
    public int PlayerCharacterSkinNum_Duck; // ��Ų ��ȣ
    public int PlayerCharacterSkinNum_Penguin; // ��Ų ��ȣ

    public int PlayerKeyNumber; //���� �ִ� ���� ����

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
        //ĳ���� ����
        if (PlayerPrefs.HasKey("Character") == true)//���� �� �г��� �� ��
        {
            //ĳ���� ��ȣ �ҷ��ͼ� ������ ��´�
            PlayerCharacterNum = PlayerPrefs.GetInt("Character");
        }
        else PlayerCharacterNum = 0; //�⺻ ĳ����

        //ĳ���� ��Ų(�䳢)
        if (PlayerPrefs.HasKey("Rabbit_Skin") == true)//���� �� �г��� �� ��
        {
            //��Ų ��ȣ �ҷ��ͼ� ������ ��´�
            PlayerCharacterSkinNum_Rabbit = PlayerPrefs.GetInt("Rabbit_Skin");
        }
        else PlayerCharacterSkinNum_Rabbit = 0; //�⺻ ��Ų
        
        //ĳ���� ��Ų(��)
        if (PlayerPrefs.HasKey("Bear_Skin") == true)//���� �� �г��� �� ��
        {
            //��Ų ��ȣ �ҷ��ͼ� ������ ��´�
            PlayerCharacterSkinNum_Bear = PlayerPrefs.GetInt("Bear_Skin");
        }
        else PlayerCharacterSkinNum_Bear = 0; //�⺻ ��Ų
       
        //ĳ���� ��Ų(����)
        if (PlayerPrefs.HasKey("Duck_Skin") == true)//���� �� �г��� �� ��
        {
            //��Ų ��ȣ �ҷ��ͼ� ������ ��´�
            PlayerCharacterSkinNum_Duck = PlayerPrefs.GetInt("Duck_Skin");
        }
        else PlayerCharacterSkinNum_Duck = 0; //�⺻ ��Ų
      
        //ĳ���� ��Ų(���)
        if (PlayerPrefs.HasKey("Penguin_Skin") == true)//���� �� �г��� �� ��
        {
            //��Ų ��ȣ �ҷ��ͼ� ������ ��´�
            PlayerCharacterSkinNum_Penguin = PlayerPrefs.GetInt("Penguin_Skin");
        }
        else PlayerCharacterSkinNum_Penguin = 0; //�⺻ ��Ų

        //�÷��̾ ���� Ű ����
        if (PlayerPrefs.HasKey("Key") == true)//���� �� �г��� �� ��
        {
            //���� ���� �ҷ��ͼ� ������ ��´�
            PlayerKeyNumber = PlayerPrefs.GetInt("Key");
        }
        else PlayerKeyNumber = 0; //���� 0��

        Debug.Log("ĳ���� ��ȣ = "+PlayerCharacterNum);

        Debug.Log("�䳢 ��Ų ��ȣ = "+ PlayerCharacterSkinNum_Rabbit);
        Debug.Log("�� ��Ų ��ȣ = "+ PlayerCharacterSkinNum_Bear);
        Debug.Log("���� ��Ų ��ȣ = "+ PlayerCharacterSkinNum_Duck);
        Debug.Log("��� ��Ų ��ȣ = "+ PlayerCharacterSkinNum_Penguin);

        Debug.Log("���� ���� ���� = "+PlayerKeyNumber);
    }


}

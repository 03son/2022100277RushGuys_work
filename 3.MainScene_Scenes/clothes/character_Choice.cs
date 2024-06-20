using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character_Choice : MonoBehaviour
{
    public Button Char1; //�䳢
    public Button Char2; //��
    public Button Char3; //����
    public Button Char4; //���

    private void Start()
    {
        Char1.onClick.AddListener(char1);
        Char2.onClick.AddListener(char2);
        Char3.onClick.AddListener(char3);
        Char4.onClick.AddListener(char4);
    }
    void char1()
    {
        _AudioManager.instance.PlaySfx(_AudioManager.Sfx.�䳢);
        ChoiceCharacter(0);
    }
    void char2()
    {
        _AudioManager.instance.PlaySfx(_AudioManager.Sfx.��);
        ChoiceCharacter(1);
    }
    void char3()
    {
        _AudioManager.instance.PlaySfx(_AudioManager.Sfx.����);
        ChoiceCharacter(2);
    }
    void char4()
    {
        _AudioManager.instance.PlaySfx(_AudioManager.Sfx.���);
        ChoiceCharacter(3);
    }
    void ChoiceCharacter(int Num)
    {
        PlayerPrefs.SetInt("Character", Num);
        PlayerInformationManager.instance.PlayerCharacter();
        Set_PlayerCharacter.Instance.SelectChar();
    }

    
}

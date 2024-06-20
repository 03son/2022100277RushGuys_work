using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character_Choice : MonoBehaviour
{
    public Button Char1; //≈‰≥¢
    public Button Char2; //∞ı
    public Button Char3; //ø¿∏Æ
    public Button Char4; //∆Î±œ

    private void Start()
    {
        Char1.onClick.AddListener(char1);
        Char2.onClick.AddListener(char2);
        Char3.onClick.AddListener(char3);
        Char4.onClick.AddListener(char4);
    }
    void char1()
    {
        _AudioManager.instance.PlaySfx(_AudioManager.Sfx.≈‰≥¢);
        ChoiceCharacter(0);
    }
    void char2()
    {
        _AudioManager.instance.PlaySfx(_AudioManager.Sfx.∞ı);
        ChoiceCharacter(1);
    }
    void char3()
    {
        _AudioManager.instance.PlaySfx(_AudioManager.Sfx.ø¿∏Æ);
        ChoiceCharacter(2);
    }
    void char4()
    {
        _AudioManager.instance.PlaySfx(_AudioManager.Sfx.∆Î±œ);
        ChoiceCharacter(3);
    }
    void ChoiceCharacter(int Num)
    {
        PlayerPrefs.SetInt("Character", Num);
        PlayerInformationManager.instance.PlayerCharacter();
        Set_PlayerCharacter.Instance.SelectChar();
    }

    
}

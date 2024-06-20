using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_PlayerCharacter : MonoBehaviour
{
    public static Set_PlayerCharacter Instance;

    public GameObject[] Char;

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
        Char[PlayerInformationManager.instance.PlayerCharacterNum].SetActive(true);
    }

    public void SelectChar()
    {
        for (int i=0; i<Char.Length; i++)
        { 
           Char[i].SetActive(false);         
        }
       Char[PlayerInformationManager.instance.PlayerCharacterNum].SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.SceneManagement;
using System.Numerics;

public class CharacterScriptControl : MonoBehaviour
{
    public static CharacterScriptControl instance;
    private void Awake()
    {
       instance = this;
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAnimation>().enabled = true;
        }
        else
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAnimation>().enabled = false;
        }
    }
}

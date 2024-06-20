using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
//using static UnityEditor.Progress;

public class startGame_Set_Screen : MonoBehaviour
{
    List<Resolution> resolutions = new List<Resolution>();

    int width;
    int height;
    void Start()
    {
        set_Screen();
    }
    void set_Screen()
    {
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRate >= 60)
            {
                resolutions.Add(Screen.resolutions[i]);
            }
        }
        foreach (Resolution item in resolutions)
        {
            width = item.width;
            height = item.height;
        }
        Debug.Log(width + "x"+ height);
        Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
    }
}

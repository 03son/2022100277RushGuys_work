using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Credits_PlayerName : MonoBehaviour
{
    public Image Fade;
    public GameObject g_Fade;

    public GameObject setting;
    public GameObject Caedits;

    void Start()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Main());
    }
    IEnumerator Main()
    {
        while (Fade.color.a < 1.2f)
        {
            Fade.color += new Color32(0, 0, 0, 1);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        g_Fade.SetActive(false);
        Caedits.SetActive(false);
        if (setting != null)
        {
            setting.SetActive(false);
        }
        yield return null;
    }
}

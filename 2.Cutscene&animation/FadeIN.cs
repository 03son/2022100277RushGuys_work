using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class FadeIN : MonoBehaviour
{
    Image image;

    [SerializeField]
    GameObject skip;//메인 씬으로 이동할 스크립트
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(fadeIn());
    }
    IEnumerator fadeIn()
    {
        while (image.color.a > 0)
        {
            image.color -= new Color32(0, 0, 0, 5);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        image.color = new Color32(255, 255, 255, 0);
        StopCoroutine(fadeIn());
    }
    public IEnumerator fadeOut()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        image.color = new Color32(255, 255, 255, 0);
        for(int i = 0; i<25; i++)
        {
            image.color += new Color32(0, 0, 0, 1);
            yield return null;
        }
        image.color = new Color32(255, 255, 255, 255);
        yield return new WaitForSecondsRealtime(1.5f);
        skip.GetComponent<Skip_>().gomainScene();
        StopCoroutine(fadeOut());
    }
}

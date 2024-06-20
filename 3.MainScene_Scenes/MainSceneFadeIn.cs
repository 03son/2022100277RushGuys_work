using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneFadeIn : MonoBehaviour
{
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        if (!this.gameObject.activeSelf)
        {   
            gameObject.SetActive(true);
            image.color = new Color32(255, 255, 255, 255);
            StartCoroutine(fadeIn());
        }else StartCoroutine(fadeIn());
        return;
    }
    IEnumerator fadeIn()
    {
        while (image.color.a > 0)
        {
            image.color -= new Color32(0, 0, 0, 5);
            yield return null;
        }
        image.color = new Color32(0, 0, 0, 0);
        gameObject.SetActive(false);
        StopCoroutine(fadeIn());
    }
}

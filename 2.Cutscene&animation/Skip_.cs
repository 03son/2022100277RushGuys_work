using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Skip_ : MonoBehaviour
{
    [SerializeField]
    Image Bar;

    public Image image;

    int skipProgress = 0;

    GameObject SceneManager;


    private void Start()
    {
        StartCoroutine(esc());
        SceneManager = GameObject.Find("SceneManager");
        if (_AudioManager.instance != null)
        {
            _AudioManager.instance.PlayBgm(_AudioManager.Bgm.뉴스신bgm);
        }
        return;
    }
    IEnumerator esc()
    {
        while (skipProgress >= 0 && skipProgress < 100)
        {
            if (Input.GetKey("f"))
            {
                skipProgress += 1;
                image.color += new Color32(0, 0, 0, 3);
            }
            else if (skipProgress >= 1)
            {
                skipProgress -= 1;
                image.color -= new Color32(0, 0, 0, 3);
            }
            Bar.fillAmount = skipProgress * 0.01f;
            yield return new WaitForSecondsRealtime(0.005f);
        }
        if (skipProgress == 100)
        {
            image.color = new Color32(255, 255, 255, 255);
            gomainScene();
        }
    }

    public void gomainScene()
    {
       _AudioManager.instance.transform.Find("SfxObject").GetComponent<AudioSource>().Stop();
       _AudioManager.instance.transform.Find("BgmObject").GetComponent<AudioSource>().Stop();
        SceneManager.GetComponent<Loading_anime_main>().go_main();
    }
}

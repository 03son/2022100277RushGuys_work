using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMapNum : MonoBehaviour
{
    [Header("봄 맵 버튼")]
    public Button Level_1;

    [Header("여름 맵 버튼")]
    public Button Level_2;

    [Header("가을 맵 버튼")]
    public Button Level_3;

    [Header("겨울 맵 버튼")]
    public Button Level_4;

    private void Start()
    {
        Level_1.onClick.AddListener(Level1);
        Level_2.onClick.AddListener(Level2);
        Level_3.onClick.AddListener(Level3);
        Level_4.onClick.AddListener(Level4);
    }

    void Level1()
    {
        //Debug.Log("스테이지 1 시작");
        InGameLoadingManager.InGameLoading("Map_1",1);
        _AudioManager.instance.transform.Find("BgmObject").GetComponent<AudioSource>().Stop();
    }
    void Level2()
    {
        //Debug.Log("스테이지 2 시작");
        InGameLoadingManager.InGameLoading("Map_2",2);
        _AudioManager.instance.transform.Find("BgmObject").GetComponent<AudioSource>().Stop();
    }
    void Level3()
    {
        InGameLoadingManager.InGameLoading("Map_3",3);
        _AudioManager.instance.transform.Find("BgmObject").GetComponent<AudioSource>().Stop();
    }
    void Level4()
    {
        InGameLoadingManager.InGameLoading("Map_4",4);
        _AudioManager.instance.transform.Find("BgmObject").GetComponent<AudioSource>().Stop();
    }
}

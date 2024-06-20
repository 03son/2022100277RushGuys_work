using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockMap : MonoBehaviour
{
    public GameObject map1;
    public GameObject map1Lock;

    public GameObject map2;
    public GameObject map2Lock;

    public GameObject map3;
    public GameObject map3Lock;

    public GameObject map4;
    public GameObject map4Lock;

    void OnEnable()
    {
        if (!PlayerPrefs.HasKey("tutorial_clear"))
        {
            map1.gameObject.GetComponent<Button>().interactable = false;
            map2.gameObject.GetComponent<Button>().interactable = false;
            map3.gameObject.GetComponent<Button>().interactable = false;
            map4.gameObject.GetComponent<Button>().interactable = false;
            StartCoroutine(settutorialText());
        }
        if(TutorialManager.instance.TutorialNum == 9)
        {
            map1.gameObject.GetComponent<Button>().interactable = true;
            map2.gameObject.GetComponent<Button>().interactable = true;
            map3.gameObject.GetComponent<Button>().interactable = true;
            map4.gameObject.GetComponent<Button>().interactable = true;

            map1Lock.SetActive(false);
            map2Lock.SetActive(false);
            map3Lock.SetActive(false);
            map4Lock.SetActive(false);
        }
    }
    IEnumerator settutorialText()
    {
        GameObject tutorialText = GameObject.Find("TutorialManager");
        if (tutorialText)
        {
            int tutorialNum = tutorialText.GetComponent<TutorialManager>().TutorialNum;
            yield return null;
            if (tutorialText)
            {
                switch (tutorialNum)
                {
                    case 0: //봄 시작 전
                        map1Lock.SetActive(false);
                        map1.gameObject.GetComponent<Button>().interactable = true;

                        tutorialText.GetComponent<TutorialManager>().s_Tutorial_Text(tutorialNum);
                        tutorialText.GetComponent<TutorialManager>().SettutorialNum(tutorialNum); //진행상태 저장
                        break;
                    case 2: // 여름 시작 전
                        map2Lock.SetActive(false);
                        map2.gameObject.GetComponent<Button>().interactable = true;

                        tutorialText.GetComponent<TutorialManager>().s_Tutorial_Text(tutorialNum);
                        tutorialText.GetComponent<TutorialManager>().SettutorialNum(tutorialNum);
                        GetComponent<swipe_menu>().scroll_pos = 0.2f;
                        break;
                    case 4: // 가을 시작 전
                        map3Lock.SetActive(false);
                        map3.gameObject.GetComponent<Button>().interactable = true;

                        tutorialText.GetComponent<TutorialManager>().s_Tutorial_Text(tutorialNum);
                        tutorialText.GetComponent<TutorialManager>().SettutorialNum(tutorialNum);
                        GetComponent<swipe_menu>().scroll_pos = 0.6f;
                        break;
                    case 6: // 겨울 시작 전
                        map4Lock.SetActive(false);
                        map4.gameObject.GetComponent<Button>().interactable = true;

                        tutorialText.GetComponent<TutorialManager>().s_Tutorial_Text(tutorialNum);
                        tutorialText.GetComponent<TutorialManager>().SettutorialNum(tutorialNum);
                        GetComponent<swipe_menu>().scroll_pos = 1f;
                        break;
                }
            }
        }
    }
}

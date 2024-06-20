using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swipe_menu : MonoBehaviour
{
    public GameObject scrollbar;
    public float scroll_pos = 0;
    public float[] pos;

    public Button NextStageButton;
    public Button BeforemapStageButton;

    GameObject tutorialText;

    void Start()
    {
        NextStageButton.onClick.AddListener(nextmap);
        BeforemapStageButton.onClick.AddListener(beforemap);
        tutorialText = GameObject.Find("TutorialManager");
    }

    // Update is called once per frame
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2 ) && scroll_pos > pos[i] - (distance /2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }
        for (int i = 0; i<pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance/2) && scroll_pos > pos[i] -(distance/2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1.7f, 1.7f), 0.1f);

                if (PlayerPrefs.HasKey("tutorial_clear"))
                {
                    transform.GetChild(i).GetComponent<Button>().interactable = true;
                }
                for (int a = 0; a< pos.Length; a++)
                {
                    if (a != i)
                    {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(1.2f,1.2f), 0.1f);
                        if (PlayerPrefs.HasKey("tutorial_clear"))
                        {
                            transform.GetChild(a).GetComponent<Button>().interactable = false;
                        }
                    }
                }
            }
        }
    }

    void nextmap()
    {
        if (scroll_pos < 0.2f) // 1번 일때
        {
            scroll_pos = 0.2f;
        } 
        else if (scroll_pos >= 0.2f && scroll_pos < 0.6f)//2번 일 때
        {
            scroll_pos = 0.6f;
        }
        else if (scroll_pos >= 0.6f)//3번 일 때
        {
            scroll_pos = 1f;
        }
    }
    void beforemap()
    {
        if (scroll_pos >= 0.8f) // 4번 일때
        {
            scroll_pos = 0.6f;
        }
        else if (scroll_pos < 0.8f && scroll_pos > 0.5f)//3번 일 때
        {
            scroll_pos = 0.2f;
        }
        else if (scroll_pos <= 0.5f)//2번 일 때
        {
            scroll_pos = 0f;
        }
    }
}

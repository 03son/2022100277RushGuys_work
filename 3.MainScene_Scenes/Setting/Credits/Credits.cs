using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{

    public GameObject startPos; //시작 지점
    public GameObject endPos; //끝나는 지점
    
    public GameObject Logo;

    private void OnEnable()
    {
        Logo.transform.position = startPos.transform.position;
    }
    private void Update()
    {
        Logo.transform.Translate(Vector3.up * dis * Time.deltaTime);
        // Logo.transform.position = Vector3.MoveTowards(Logo.transform.position, endLogoPos.transform.position, dis * Time.deltaTime);

        if (TutorialManager.instance.TutorialNum == 8)
        {
            TutorialManager.instance.TutorialNum = 9;
            PlayerPrefs.SetInt("TutorialNum", 9);
            if (Input.GetKeyDown(KeyCode.Escape) && Logo.transform.position != endPos.transform.position)
            {
                TutorialManager.instance.StartCoroutine(TutorialManager.instance.endGame());
            }
            if (Logo.transform.position.y == endPos.transform.position.y)
            {
                TutorialManager.instance.StartCoroutine(TutorialManager.instance.endGame());
            }
            return;
        }
    }

    float dis = 150;
}

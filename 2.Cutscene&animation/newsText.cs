using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class newsText : MonoBehaviour
{
    [SerializeField]
    TMP_Text targetText; //tmp�� ������ �ؽ�Ʈ
    [SerializeField]
    Image triangle; // �ؽ�Ʈ ���� �ϴ� �ﰢ��

    [SerializeField]
    animation_Cam animation_Cam; //ī�޶� ��ũ��Ʈ

    string text; // targetText�� �ؽ�Ʈ ������ ������ �ؽ�Ʈ
    float delay = 1f; //�ؽ�Ʈ ��� ���� �ð�
    int textNumber = 0; // �ؽ�Ʈ ���� �ѹ���

    [SerializeField]
    string[] newstexts; //���� ���� �ڸ��� �� �ؽ�Ʈ �迭

    void Start()
    {
        //�ؽ�Ʈ �ڽ� ũ�� �ʱ�ȭ
        gameObject.transform.localScale = new Vector3(0, 0, 0);

        //�� �ؽ�Ʈ ���
        text = targetText.text.ToString();
        targetText.text = "";

        //���� �ؽ�Ʈ â ����
        StartCoroutine(newsTextBer());
    }
    IEnumerator newstext(float delay)// ���� ���� �ؽ�Ʈ,�� ���ھ� ����
    {
        int count = 0;
        text = newstexts[textNumber];
        while (count != text.Length)
        {
            if (count < text.Length)
            { 
                targetText.text += text[count].ToString();
                count++;
            }
            _AudioManager.instance.PlaySfx(_AudioManager.Sfx.��Ŀ���2);
            yield return new WaitForSecondsRealtime(delay/50);
        }
        yield return new WaitForSecondsRealtime(delay * 3);
        if (textNumber+1 != newstexts.Length)
        {
            textNumber += 1;
            targetText.text = "";
            StartCoroutine(newstext(delay));
        }
        else
        {//��� �ؽ�Ʈ ��� ��
            //�ؽ�Ʈ ���� �ݱ�
            _AudioManager.instance.PlaySfx(_AudioManager.Sfx.������);
            StartCoroutine(destroynewsTextBer(delay));
            yield break;
        }

        yield return null;
    }
    IEnumerator newsTextBer()// ���� �ؽ�Ʈ �� ũ��
    {
        yield return new WaitForSecondsRealtime(1.5f);
        // Ŀ���鼭 ��Ÿ����
        while (gameObject.transform.localScale != new Vector3(0.67f, 0.67f, 0.67f))
        {
            gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            yield return null;
        }
        //�ؽ�Ʈ ���
        StartCoroutine(newstext(delay));
    }
    IEnumerator destroynewsTextBer(float delay)//���� �ؽ�Ʈ�� �������
    {
        yield return new WaitForSecondsRealtime(delay);

        while (gameObject.transform.localScale != new Vector3(0, 0, 0))
        {
            gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            yield return null;
        }
        yield return new WaitForSecondsRealtime(0.5f);

        //ī�޶� �̵�
        animation_Cam.moveCam();
        yield break;
    }
}

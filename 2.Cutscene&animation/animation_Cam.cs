using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Cinemachine;
using Unity.VisualScripting.Antlr3.Runtime;

public class animation_Cam : MonoBehaviour
{
    [SerializeField]
    Animator mail;//���� �ִϸ��̼��� ���� ����
    [SerializeField]
    GameObject RushGuysMail;//���� ������Ʈ�� ���� ����
    [SerializeField]
    GameObject light;//�������� ������ �� ����Ʈ
    [SerializeField]
    FadeIN fadeout;//���̵� �ƿ��� ���̵� �� �̹���

    Vector3 TagetPos = new Vector3(0.56f, 0.7951f, -0.602f);// �̵� �� ��ġ

    void Awake()
    {
        //ī�޶� ó�� ��ġ ����
       gameObject.transform.position = new Vector3(1.08f, 0.7951f,-0.602f);
    }
    public void moveCam()//(-X)�ڷ� �̵�
    {
        StartCoroutine(x_move());
    }
    IEnumerator x_move()
    {
       while (TagetPos.x + 0.001f <= gameObject.transform.position.x)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, TagetPos, 0.01f);
            yield return null;
        }
        yield return null;
        gameObject.transform.position = TagetPos;
        StartCoroutine(mailMove());
    }
    IEnumerator mailMove()//�ִϸ��̼� �� �ڿ������� �׸��ڸ� ���� ���� �̵�
    {
        yield return null;
        mail.SetTrigger("FlyingMail");//���� ���ƿ��� �ִϸ��̼� ����
        if (_AudioManager.instance != null)
        {
            _AudioManager.instance.PlaySfx(_AudioManager.Sfx.����������ȿ����3);
        }
        StartCoroutine(LookatMail());
        
        yield return new WaitForSeconds(7);
        StartCoroutine(nextScenes());
    }
    IEnumerator nextScenes()//�������� �����鼭 ����ȭ������ �̵�
    {
        Vector3 onmail = new Vector3(0.9f, 1, -0.602f);
        yield return null;
        while (gameObject.transform.position.y <= 0.999f)
        {
            gameObject.transform.position = Vector3.Lerp(transform.position, onmail, 0.01f);
            yield return null;
        }
        StartCoroutine(luminescentletter());
    }
    IEnumerator luminescentletter()//���� ������ 
    {
        StartCoroutine(fadeout.fadeOut());
        if (_AudioManager.instance != null)
        {
            _AudioManager.instance.PlaySfx(_AudioManager.Sfx.���̵�ƿ�ȿ����);
        }
        while (light.GetComponent<Light>().intensity <= 30)
        {
            light.GetComponent<Light>().intensity += 0.1f;
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }

    IEnumerator LookatMail()//ī�޶� ���� �ٶ󺸰� �ϱ�
    {
        yield return new WaitForSecondsRealtime(1f);

        gameObject.GetComponent<CinemachineVirtualCamera>().LookAt = RushGuysMail.transform;
        if (_AudioManager.instance != null)
        {
            _AudioManager.instance.PlaySfx(_AudioManager.Sfx.����������ȿ����1);
        }

    }
}

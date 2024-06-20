using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Cinemachine;
using Unity.VisualScripting.Antlr3.Runtime;

public class animation_Cam : MonoBehaviour
{
    [SerializeField]
    Animator mail;//메일 애니메이션을 담을 변수
    [SerializeField]
    GameObject RushGuysMail;//메일 오브젝트를 담을 변수
    [SerializeField]
    GameObject light;//편지에서 빛나게 할 라이트
    [SerializeField]
    FadeIN fadeout;//페이드 아웃할 페이드 인 이미지

    Vector3 TagetPos = new Vector3(0.56f, 0.7951f, -0.602f);// 이동 후 위치

    void Awake()
    {
        //카메라 처음 위치 설정
       gameObject.transform.position = new Vector3(1.08f, 0.7951f,-0.602f);
    }
    public void moveCam()//(-X)뒤로 이동
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
    IEnumerator mailMove()//애니메이션 전 자연스러운 그림자를 위한 사전 이동
    {
        yield return null;
        mail.SetTrigger("FlyingMail");//메일 날아오는 애니메이션 실행
        if (_AudioManager.instance != null)
        {
            _AudioManager.instance.PlaySfx(_AudioManager.Sfx.편지들어오는효과음3);
        }
        StartCoroutine(LookatMail());
        
        yield return new WaitForSeconds(7);
        StartCoroutine(nextScenes());
    }
    IEnumerator nextScenes()//편지에서 빛나면서 메인화면으로 이동
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
    IEnumerator luminescentletter()//편지 빛나게 
    {
        StartCoroutine(fadeout.fadeOut());
        if (_AudioManager.instance != null)
        {
            _AudioManager.instance.PlaySfx(_AudioManager.Sfx.페이드아웃효과음);
        }
        while (light.GetComponent<Light>().intensity <= 30)
        {
            light.GetComponent<Light>().intensity += 0.1f;
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }

    IEnumerator LookatMail()//카메라가 편지 바라보게 하기
    {
        yield return new WaitForSecondsRealtime(1f);

        gameObject.GetComponent<CinemachineVirtualCamera>().LookAt = RushGuysMail.transform;
        if (_AudioManager.instance != null)
        {
            _AudioManager.instance.PlaySfx(_AudioManager.Sfx.편지들어오는효과음1);
        }

    }
}

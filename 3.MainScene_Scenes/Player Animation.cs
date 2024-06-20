using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator Ani;

    int IdlingVel;
    void Start()
    {
        Ani = GetComponent<Animator>();
        StartCoroutine(idlingvel());
    }

    IEnumerator idlingvel()
    {
        yield return new WaitForSecondsRealtime(10);
        IdlingVel = Random.Range(0,8);

        switch (IdlingVel)
        { 
            case 0:
                Ani.SetInteger("Idling",0);
                break;
            case 1:
                Ani.SetInteger("Idling", 1);
                yield return new WaitForSecondsRealtime(4);
                Ani.SetInteger("Idling", 0);
                break;
            case 2:
                Ani.SetInteger("Idling", 2);
                yield return new WaitForSecondsRealtime(4);
                Ani.SetInteger("Idling", 0);
                break;
            case 7:
                Ani.SetInteger("Idling", 7);
                yield return new WaitForSecondsRealtime(4);
                Ani.SetInteger("Idling", 0);
                break;
        }
        StartCoroutine(idlingvel());
    }


    
}

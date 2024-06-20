using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class news : MonoBehaviour
{
    public Material[] NewsMat = new Material[2]; //뉴스 그림 넣을 머티리얼 배열

    Material[] TVmat;//tv에 있는 머티리얼들의 정보를 담을 배열

    void Awake()
    {
        TVmat = this.gameObject.GetComponent<MeshRenderer>().materials;
    }
    IEnumerator Start()
    { 
        while (true)
        {
            TVmat[2] = NewsMat[0];
            this.gameObject.GetComponent<MeshRenderer>().materials = TVmat;
            yield return new WaitForSecondsRealtime(0.5f);
            TVmat[2] = NewsMat[1];
            this.gameObject.GetComponent<MeshRenderer>().materials = TVmat;
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}

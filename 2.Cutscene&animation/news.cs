using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class news : MonoBehaviour
{
    public Material[] NewsMat = new Material[2]; //���� �׸� ���� ��Ƽ���� �迭

    Material[] TVmat;//tv�� �ִ� ��Ƽ������� ������ ���� �迭

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

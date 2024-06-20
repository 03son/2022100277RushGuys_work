using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSky : MonoBehaviour
{
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation",Time.time * 2.5f);
    }
}

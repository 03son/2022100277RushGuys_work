using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting_UI_Object : MonoBehaviour
{
    [Header("각 설정창")]
    [TooltipAttribute("오디오 세팅화면")]
    public GameObject audioSetting;
    [TooltipAttribute("화면 세팅화면")]
    public GameObject screenSetting;
    [TooltipAttribute("크레딧 화면")]
    public GameObject credits;
}

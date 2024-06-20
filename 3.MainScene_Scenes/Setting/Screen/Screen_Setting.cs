using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore;
using UnityEngine.UI;
using UnityEditor;
//using static UnityEditor.Progress;

public class Screen_Setting : MonoBehaviour
{
    FullScreenMode ScreenMode;
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullScreenBtn;
    public Toggle vSyncToggle;
    List<Resolution> resolutions = new List<Resolution>();
    int resolutionNum;
    int gcd(int a, int b) //��Ŭ���� ȣ���(�ּҰ����)
    {
        if (b == 0)
            return a;
        else
            return gcd(b, a % b);
    }
    void Start()
    {
        InitUI();
    }

    void InitUI()
    {
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRate == 60)
            {
                resolutions.Add(Screen.resolutions[i]);
            }
        }

        resolutionDropdown.options.Clear();

        int optionNum = 0;
        foreach (Resolution item in resolutions)//����Ͱ� ��� �� �� �ִ� �ɼǵ��� ������ ��Ӵٿ �Ҵ�
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " " + item.refreshRate + "hz";
            resolutionDropdown.options.Add(option);
            if (item.width == Screen.width && item.height == Screen.height)
            {
                resolutionDropdown.value = optionNum;
            }
            optionNum++;
        }
        resolutionDropdown.RefreshShownValue();

        fullScreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.Windowed) ?true : false;

        vSyncToggle.isOn = QualitySettings.vSyncCount > 0;
    }
    public void DropboxOptionChange(int x)
    {
        resolutionNum = x;
    }

    public void FullScreenBtn(bool isFull)
    {
        ScreenMode = isFull ? FullScreenMode.Windowed : FullScreenMode.FullScreenWindow;
    }

    public void OkBinClick()
    {
        Screen.SetResolution(
            resolutions[resolutionNum].width, resolutions[resolutionNum].height,ScreenMode);
    }

    public void VSyncToggle(bool isOn)
    { 
        QualitySettings.vSyncCount = isOn ? 1 : 0;
    }

}

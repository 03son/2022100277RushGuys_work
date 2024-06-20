using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    [Header("������ ����")]
    public Slider masterVolume;
    public TextMeshProUGUI masterVolumeText;
    public GameObject smallVolume;
    public GameObject middleVolume;
    public GameObject highVolume;
    [Header("���� ����")]
    public Slider musicVolume;
    public TextMeshProUGUI musicVolumeText;
    AudioSource[] musicffect;
    [Header("ȿ���� ����")]
    public Slider soundeffectVolume;
    public TextMeshProUGUI soundeffectVolumeText;
    AudioSource[] soundeffect;
    void OnEnable()
    {
        Debug.Log(PlayerPrefs.HasKey("masterMixer"));
        Debug.Log(Mathf.FloorToInt(PlayerPrefs.GetFloat("masterMixer") * 100));
        if (PlayerPrefs.HasKey("masterMixer"))
        {
            masterVolumeText.text = (Mathf.FloorToInt(PlayerPrefs.GetFloat("masterMixer") * 100)).ToString();
            masterVolume.value = PlayerPrefs.GetFloat("masterMixer");
            Debug.Log(Mathf.FloorToInt(PlayerPrefs.GetFloat("masterMixer")));
        }
        else
        {
            //masterVolume.value = 100;
           // masterVolumeText.text = "100";
        }
        if (PlayerPrefs.HasKey("bgmVolume"))
        {
            musicVolumeText.text = (PlayerPrefs.GetFloat("bgmVolume") * 100).ToString();
            musicVolume.value = PlayerPrefs.GetFloat("bgmVolume");
        }
        else
        {
            musicVolume.value = 100;
            musicVolumeText.text = "100";
        }
        if (PlayerPrefs.HasKey("soundeffectVolume"))
        {
            soundeffectVolumeText.text = (PlayerPrefs.GetFloat("soundeffectVolume") * 100).ToString();
            soundeffectVolume.value = PlayerPrefs.GetFloat("soundeffectVolume");
        }
        else
        {
            soundeffectVolume.value = 100;
            soundeffectVolumeText.text = "100";
        }
        setSpeakerImage(masterVolume.value);
    }
   
    public void Setmaster(float Volume)//������ ���� ����
    {
        //��ġ �� ǥ��
        masterVolumeText.text = Mathf.FloorToInt(Volume * 100).ToString();
        //����� �ͼ��� �� �ֱ�
        if (Volume * 100 != 0)
        {
            GameObject.Find("BgmObject").GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("masterMixer", -20 + ((Volume) * 30));
            //�� ����
            PlayerPrefs.SetFloat("masterMixer", Volume);
            //PlayerPrefs.SetFloat("masterMixer", Mathf.Floor(Volume));
            //Mathf.Floor(-20 + ((Volume) * 30))
            if (smallVolume != null)
            {
                if (Volume * 100 > 0)
                {
                    smallVolume.SetActive(true);
                }
                else smallVolume.SetActive(false);
                if (Volume * 100 > 40)
                {
                    middleVolume.SetActive(true);
                }
                else middleVolume.SetActive(false);
                if (Volume * 100 >= 70)
                {
                    highVolume.SetActive(true);
                }
                else highVolume.SetActive(false);
            }
        }
        else
        {
            if (smallVolume != null)
            {
                smallVolume.SetActive(false);
                middleVolume.SetActive(false);
                highVolume.SetActive(false);
            }
            GameObject.Find("BgmObject").GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("masterMixer", -80f);
            PlayerPrefs.SetFloat("masterMixer", 0);
        } 
    }
    public void Setmusic(float Volume)//���� ���� ����
    {
        //�����̴� �� �ؽ�Ʈ�� ǥ��
        musicVolumeText.text = Mathf.FloorToInt(Volume * 100).ToString();
        //��� ������ �� �ֱ�(�Ҽ��� 2�ڸ� ���� ������)
        musicffect = GameObject.Find("BgmObject").GetComponents<AudioSource>();
        for (int index = 0; index < musicffect.Length; index++)
        {
            musicffect[index].volume = Mathf.Floor(Volume * 100f) / 100f;
        }
        //�� ����
        PlayerPrefs.SetFloat("bgmVolume", Mathf.Floor(Volume * 100f) / 100f);
    }
    public void Setsoundeffect(float Volume)//ȿ���� ���� ����
    {
        //�ؽ�Ʈ ǥ��
        soundeffectVolumeText.text = Mathf.FloorToInt(Volume * 100).ToString();
        //ȿ���� ������ �� �ֱ�
        soundeffect = GameObject.Find("SfxObject").GetComponents<AudioSource>();
        for (int index = 0; index< soundeffect.Length; index++)
        {
            soundeffect[index].volume = Mathf.Floor(Volume * 100f) / 100f;
        }
        //�� ����
        PlayerPrefs.SetFloat("soundeffectVolume", Mathf.Floor(Volume * 100f) / 100f);
    }

    void setSpeakerImage(float Volume)//����Ŀ �̹��� ����
    {
        if (smallVolume != null)
        {
            if (Volume * 100 > 0)
            {
                smallVolume.SetActive(true);
            }
            else smallVolume.SetActive(false);
            if (Volume * 100 > 40)
            {
                middleVolume.SetActive(true);
            }
            else middleVolume.SetActive(false);
            if (Volume * 100 >= 70)
            {
                highVolume.SetActive(true);
            }
            else highVolume.SetActive(false);
        }
    }
}

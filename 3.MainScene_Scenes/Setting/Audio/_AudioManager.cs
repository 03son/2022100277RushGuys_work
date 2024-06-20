using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Timeline;
using Random = UnityEngine.Random;

public class _AudioManager : MonoBehaviour
{
    public static _AudioManager instance;

    [Header("#Master")]
    public AudioMixerGroup master;

    [Header("#BGM")]
    public AudioClip[] bgmClip;
    public float bgmVolume;
    [HideInInspector]
    public AudioSource[] bgmPlayer;

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    [HideInInspector]
    public AudioSource[] sfxPlayers;
    int channelIndex;

    //����� ȿ���� �̸� ����
    public enum Sfx 
    {
        uiŬ����, 
        ��Ŀ���1,
        ��Ŀ���2,
        ����������ȿ����1,
        ����������ȿ����2, 
        ����������ȿ����3,
        ���̵�ƿ�ȿ����,
        ����ȹ��ȿ����,
        ü����������ȿ����,
        ���ǵ����ȿ����,
        ��ֹ��浹ȿ����,
        ������,
        �䳢,
        ��,
        ����,
        ���,
        ī��Ʈ�ٿ�ȿ����
    };
    //_AudioManager.instance.PlaySfx(_AudioManager.Sfx.�̸�);ȣ��
    //����� ��� �̸� ����
    public enum Bgm
    { 
        ������bgm,
        ����ȭ��bgm,
        ��bgm,
        ����bgm,
        ����bgm,
        �ܿ�bgm,
        ����bgm
    };

    void Awake()
    {
        instance = this;

        sfxVolume = 0.3f;
        bgmVolume = 0.2f;

        if (PlayerPrefs.HasKey("soundeffectVolume"))
        {
            sfxVolume = PlayerPrefs.GetFloat("soundeffectVolume");
        }
        if (PlayerPrefs.HasKey("bgmVolume"))
        {
            bgmVolume = PlayerPrefs.GetFloat("bgmVolume");
        }

        Init();
    }

    void Init()
    {
        //����� �÷��̾� �ʱ�ȭ
        GameObject bgmObject = new GameObject("BgmObject");
        bgmObject.transform.parent = transform;
        bgmPlayer = new AudioSource[channels];

        for (int index = 0; index < bgmPlayer.Length; index++)
        {
            bgmPlayer[index] = bgmObject.AddComponent<AudioSource>();
            bgmPlayer[index].playOnAwake = false;
            bgmPlayer[index].volume = bgmVolume;
            bgmPlayer[index].outputAudioMixerGroup = master;
            bgmPlayer[index].loop = true;
        }

        //ȿ���� �÷��̾� �ʱ�ȭ
        GameObject sfxObject = new GameObject("SfxObject");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].volume = sfxVolume;
            sfxPlayers[index].outputAudioMixerGroup = master;
        }

      //  GameObject.Find("BgmPlayer").GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("masterMixer", PlayerPrefs.GetFloat("masterMixer"));
    }
    public void PlayBgm(Bgm bgm)
    {
        for (int index = 0; index < bgmPlayer.Length; index++)
        {
            int loopIndex = (index + channelIndex) % bgmPlayer.Length;

            if (bgmPlayer[loopIndex].isPlaying)
                continue;

            channelIndex = loopIndex;
            bgmPlayer[loopIndex].clip = bgmClip[(int)bgm];
            bgmPlayer[loopIndex].Play();
            break;
        }
    }
    public void PlaySfx(Sfx sfx)
    {
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopIndex = (index + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
                continue;

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopIndex].Play();
            break;
        }
    }
}
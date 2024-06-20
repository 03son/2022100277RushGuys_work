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

    //사용할 효과음 이름 열거
    public enum Sfx 
    {
        ui클릭음, 
        앵커대사1,
        앵커대사2,
        편지들어오는효과음1,
        편지들어오는효과음2, 
        편지들어오는효과음3,
        페이드아웃효과음,
        열쇠획득효과음,
        체리떨어지는효과음,
        스피드버프효과음,
        장애물충돌효과음,
        빈파일,
        토끼,
        곰,
        오리,
        펭귄,
        카운트다운효과음
    };
    //_AudioManager.instance.PlaySfx(_AudioManager.Sfx.이름);호출
    //사용할 브금 이름 열거
    public enum Bgm
    { 
        뉴스신bgm,
        메인화면bgm,
        봄bgm,
        여름bgm,
        가을bgm,
        겨울bgm,
        완주bgm
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
        //배경음 플레이어 초기화
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

        //효과음 플레이어 초기화
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
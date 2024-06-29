using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Bgms
{
    Normal,
    Win,
    Lose
}

public enum SoundEffects
{
    BtnClick,
    Revelation,
    NextBall,
    ShakeBall,
    InputText,
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource bgmAudioSource;
    public AudioSource[] audioSources;

    public AudioClip introBgm;
    public AudioClip normalBgm;
    public AudioClip winBgm;
    public AudioClip loseBgm;

    public AudioClip btnClickSoundEffect;
    public AudioClip typingSoundEffect;
    public AudioClip chooseNextBallSoundEffect;
    public AudioClip shakeBallSoundEffect;
    public AudioClip revelationSoundEffect;
    public AudioClip cardUseSoundEffect;
    private int _audioSourceIdx= 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
        
        Initialize();
    }

    private void Start()
    {
        PlayIntro();
    }

    void Initialize()
    {
        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        audioSources = new AudioSource[10];
        for (int i = 0; i < 10; i++)
        {
            var audioSource = gameObject.AddComponent<AudioSource>();
            audioSources[i] = audioSource;
        }
    }

    public void PlayIntro()
    {
        bgmAudioSource.clip = introBgm;
        bgmAudioSource.loop = true;
        bgmAudioSource.Play();
    }

    public void PlayBGM()
    {
        bgmAudioSource.clip = normalBgm;
        bgmAudioSource.loop = true;
        bgmAudioSource.Play();
    }

    public void PlayerWinBgm()
    {
        bgmAudioSource.clip = winBgm;
        bgmAudioSource.loop = false;
        bgmAudioSource.Play();
    }

    public void PlayLoseBgm()
    {
        bgmAudioSource.clip = loseBgm;
        bgmAudioSource.loop = false;
        bgmAudioSource.Play();
    }

    public void PlayBallShakeSound()
    {
        
        // audioSources[_audioSourceIdx].PlayOneShot(shakeBallSoundEffect);
        // UpdateAudioSourceIdx();
        audioSources[_audioSourceIdx].clip = shakeBallSoundEffect;
        audioSources[_audioSourceIdx].loop = false;
        audioSources[_audioSourceIdx].Play();
        UpdateAudioSourceIdx();
    }

    public void PlayBtnClickSound()
    {
        audioSources[_audioSourceIdx].PlayOneShot(btnClickSoundEffect);
        UpdateAudioSourceIdx();
    }

    public void PlayChooseNextBallSound()
    {
        audioSources[_audioSourceIdx].PlayOneShot(chooseNextBallSoundEffect);
        UpdateAudioSourceIdx();
    }

    public void PlayerRevelationSound()
    {
        audioSources[_audioSourceIdx].PlayOneShot(revelationSoundEffect);
        UpdateAudioSourceIdx();
    }

    public void PlayKeyBoardSound()
    {
        audioSources[_audioSourceIdx].PlayOneShot(typingSoundEffect);
        UpdateAudioSourceIdx();
    }
    
    public void PlayCardUseSound()
    {
        audioSources[_audioSourceIdx].PlayOneShot(typingSoundEffect);
        UpdateAudioSourceIdx();
    }
    

    void UpdateAudioSourceIdx()
    {
        _audioSourceIdx++;
        if (_audioSourceIdx >= 10)
        {
            _audioSourceIdx = 0;
        }
    }
    
    


}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] public List<AudioClip> musicList;
    AudioSource musicPlayer;

    private void OnEnable()
    {
        UIManager.Instance.OnMusicOptionsChange.AddListener(ApplySoundChanges);
    }

    private void OnDisable()
    {
        UIManager.Instance.OnMusicOptionsChange.RemoveListener(ApplySoundChanges);
    }

    void Start()
    {
        musicPlayer = Camera.main.gameObject.GetComponent<AudioSource>();

        ApplyConfigMusicSettings();
    }

    private void ApplySoundChanges(Enums.MusicOptions opt, object obj)
    {
        switch (opt)
        {
            case Enums.MusicOptions.Clip:
                AudioClip clip = obj as AudioClip;
                if (musicPlayer.clip != clip)
                {
                    musicPlayer.clip = clip;
                    musicPlayer.Play();
                }
                break;

            case Enums.MusicOptions.Mono:
                bool mono = (bool)obj;
                musicPlayer.spatialBlend = mono ? 1 : 0;
                break;

            case Enums.MusicOptions.Volume:
                float volume = (float)obj;
                musicPlayer.volume = volume;
                break;
        }
    }

    void ApplyConfigMusicSettings()
    {
        musicPlayer.volume = GameManager.Instance.cfg.musicVolume;
        musicPlayer.clip = GameManager.Instance.cfg.musicClip;
        musicPlayer.spatialBlend = GameManager.Instance.cfg.musicMono ? 1 : 0;
        musicPlayer.Play();
    }
}

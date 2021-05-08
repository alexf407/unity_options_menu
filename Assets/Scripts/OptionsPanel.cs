using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsPanel : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] Slider musicSliderVolume;
    [SerializeField] Toggle musicToggleMono;
    [SerializeField] TMP_Dropdown musicTracks;

    [Header("Font")]
    [SerializeField] public List<FontColor> colorList;
    [SerializeField] Slider graphSliderFontScale;
    [SerializeField] TMP_Dropdown graphFontColors;

    [Header("Localization")]
    [SerializeField] Localization[] localizations;
    [SerializeField] TMP_Dropdown currentLocale;

    [Header("Navigation")]
    [SerializeField] GameObject mainMenu;

    Dictionary<string, Delegate> changes = new Dictionary<string, Delegate>();

    private void Awake()
    {
        FillLocaleOptions();
        FillMusicOptions();
        FillColorOptions();
    }

    private void OnEnable()
    {
        SetValuesUI();
    }

    private void FillLocaleOptions()
    {
        List<string> locales = new List<string>();
        foreach (Localization locale in localizations)
        {
            locales.Add(locale.LocalizationName);
        }

        currentLocale.AddOptions(locales);
    }

    private void FillMusicOptions()
    {
        List<string> tracks = new List<string>();
        foreach (AudioClip clip in SoundManager.Instance.musicList)
        {
            tracks.Add(clip.name);
        }

        musicTracks.AddOptions(tracks);
    }

    private void FillColorOptions()
    {
        List<string> colors = new List<string>();
        foreach (FontColor color in colorList)
        {
            colors.Add(color.name);
        }

        graphFontColors.AddOptions(colors);
    }

    private int GetCurrentLocaleId()
    {
        return currentLocale.options.FindIndex(x => x.text == GameManager.Instance.cfg.localization.LocalizationName);
    }

    private int GetCurrentTrackId()
    {
        return musicTracks.options.FindIndex(x => x.text == GameManager.Instance.cfg.musicClip.name);
    }

    private int GetCurrentColorId()
    {
        return graphFontColors.options.FindIndex(x => x.text == GameManager.Instance.cfg.fontColor.name);
    }

    private void SetValuesUI()
    {
        currentLocale.SetValueWithoutNotify(GetCurrentLocaleId());

        musicSliderVolume.SetValueWithoutNotify(GameManager.Instance.cfg.musicVolume);
        musicToggleMono.SetIsOnWithoutNotify(GameManager.Instance.cfg.musicMono);
        musicTracks.SetValueWithoutNotify(GetCurrentTrackId());

        graphSliderFontScale.SetValueWithoutNotify(GameManager.Instance.cfg.fontScale - 0.5f);
        graphFontColors.SetValueWithoutNotify(GetCurrentColorId());
    }

    public void SetLocale(int localeId)
    {
        changes["locale"] = new Action(() => { GameManager.Instance.cfg.localization = localizations[localeId]; });
        UIManager.Instance.OnLocalizationChange?.Invoke(localizations[localeId]);
    }

    public void SetVolume(float volume)
    {
        changes["volume"] = new Action(() => { GameManager.Instance.cfg.musicVolume = volume; });
        UIManager.Instance.OnMusicOptionsChange?.Invoke(Enums.MusicOptions.Volume, volume);
    }

    public void SetMono(bool mono)
    {
        changes["mono"] = new Action(() => { GameManager.Instance.cfg.musicMono = mono; });
        UIManager.Instance.OnMusicOptionsChange?.Invoke(Enums.MusicOptions.Mono, mono);
    }

    public void SetClip(int clipId)
    {
        AudioClip clip = SoundManager.Instance.musicList[clipId];
        changes["clip"] = new Action(() => { GameManager.Instance.cfg.musicClip = clip; });
        UIManager.Instance.OnMusicOptionsChange?.Invoke(Enums.MusicOptions.Clip, clip);
    }

    public void SetFontScale(float scale)
    {
        float fontScale = 0.5f + scale;
        changes["scale"] = new Action(() => { GameManager.Instance.cfg.fontScale = fontScale; });
        UIManager.Instance.OnGraphicsOptionsChange?.Invoke(Enums.GraphicsOptions.FontScale, fontScale);
    }

    public void SetFontColor(int colorId)
    {
        FontColor fontColor = colorList[colorId];
        changes["color"] = new Action(() => { GameManager.Instance.cfg.fontColor = fontColor; });
        UIManager.Instance.OnGraphicsOptionsChange?.Invoke(Enums.GraphicsOptions.FontColor, fontColor.color);
    }

    public void SaveSettings()
    {
        foreach (var cmd in changes.Keys)
        {
            changes[cmd].DynamicInvoke();
        }

        ExitOptions();
    }

    public void CancelSettings()
    {
        SetLocale(GetCurrentLocaleId());

        SetVolume(GameManager.Instance.cfg.musicVolume);
        SetMono(GameManager.Instance.cfg.musicMono);
        SetClip(GetCurrentTrackId());

        SetFontScale(GameManager.Instance.cfg.fontScale);
        SetFontColor(GetCurrentColorId());

        ExitOptions();
    }

    private void ExitOptions()
    {
        changes.Clear();

        OpenMainMenu();
    }

    public void OpenMainMenu()
    {
        gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}

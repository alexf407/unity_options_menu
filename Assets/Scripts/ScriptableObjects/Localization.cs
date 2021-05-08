using System.Collections.Generic;
using UnityEngine;

// It will be better to use com.unity.localization
// But I want to experiment with ScriptableObjects :)

[CreateAssetMenu(fileName = "lang", menuName = "ScriptableObjects/Localization", order = 1)]
public class Localization : ScriptableObject
{
    [SerializeField] string localizationName;

    [SerializeField] string mainMenuPlayButton;
    [SerializeField] string mainMenuNotPlayButton;
    [SerializeField] string mainMenuOptionsButton;
    [SerializeField] string mainMenuQuitButton;

    [SerializeField] string optionsLanguage;
    [SerializeField] string optionsMusicVolume;
    [SerializeField] string optionsMusicTrack;
    [SerializeField] string optionsMusicMono;
    [SerializeField] string optionsFontColor;
    [SerializeField] string optionsFontSize;

    [SerializeField] string optionsSaveButton;
    [SerializeField] string optionsCancelButton;

    public string LocalizationName { get { return localizationName; } }

    public string MainMenuPlayButton { get { return mainMenuPlayButton; } }
    public string MainMenuNotPlayButton { get { return mainMenuNotPlayButton; } }
    public string MainMenuOptionsButton { get { return mainMenuOptionsButton; } }
    public string MainMenuQuitButton { get { return mainMenuQuitButton; } }

    public string OptionsLanguage { get { return optionsLanguage; } }
    public string OptionsMusicVolume { get { return optionsMusicVolume; } }
    public string OptionsMusicTrack { get { return optionsMusicTrack; } }
    public string OptionsMusicMono { get { return optionsMusicMono; } }
    public string OptionsFontColor { get { return optionsFontColor; } }
    public string OptionsFontSize { get { return optionsFontSize; } }

    public string OptionsSaveButton { get { return optionsSaveButton; } }
    public string OptionsCancelButton { get { return optionsCancelButton; } }

    // structs become too complex with reflections, but they were way more organized.
    //[SerializeField] MainMenu mainMenu;
    //public MainMenu MainMenu { get { return mainMenu; } }
}

//[System.Serializable]
//public struct MainMenu
//{
//    public string playButton;
//    public string optionsButton;
//    public string quitButton;
//}
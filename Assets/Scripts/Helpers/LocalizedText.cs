using System;
using UnityEngine;
using UnityEditor;
using TMPro;

public class LocalizedText : MonoBehaviour
{
    [SerializeField] public string localizationPath;

    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        UIManager.Instance.OnLocalizationChange.AddListener(LiveLocalize);
        ApplyConfigLocalize();
    }

    private void OnDisable()
    {
        UIManager.Instance.OnLocalizationChange.RemoveListener(LiveLocalize);
    }

    public void ChangeText(string locPath)
    {
        localizationPath = locPath;

        ApplyConfigLocalize();
    }

    void LiveLocalize(object obj)
    {
        text.text = (string)typeof(Localization).GetProperty(localizationPath).GetValue(obj as Localization);
    }

    void ApplyConfigLocalize()
    {
        text.text = (string)typeof(Localization).GetProperty(localizationPath).GetValue(GameManager.Instance.cfg.localization);
    }
}

// Dropdown with localized strings
[CustomEditor(typeof(LocalizedText))]
[CanEditMultipleObjects]
public class LocalizedTextEditor : Editor
{
    SerializedProperty localizationPath;
    string[] _choices = new[] {
        "MainMenuPlayButton",
        "MainMenuNotPlayButton",
        "MainMenuOptionsButton",
        "MainMenuQuitButton",
        "OptionsLanguage",
        "OptionsMusicVolume",
        "OptionsMusicTrack",
        "OptionsMusicMono",
        "OptionsFontColor",
        "OptionsFontSize",
        "OptionsSaveButton",
        "OptionsCancelButton"
    };
    int _choiceIndex = 0;

    void OnEnable()
    {
        localizationPath = serializedObject.FindProperty("localizationPath");
        _choiceIndex = Array.IndexOf(_choices, localizationPath.stringValue);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        _choiceIndex = EditorGUILayout.Popup("Localized Element", _choiceIndex, _choices);
        if (_choiceIndex < 0)
            _choiceIndex = 0;
        localizationPath.stringValue = _choices[_choiceIndex];

        serializedObject.ApplyModifiedProperties();
    }
}
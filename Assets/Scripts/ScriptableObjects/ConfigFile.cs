using UnityEngine;

[CreateAssetMenu(fileName = "cfg", menuName = "ScriptableObjects/ConfigFile", order = 1)]
public class ConfigFile : ScriptableObject
{
    public Localization localization;

    [Range(0, 1)]
    public float musicVolume;
    public bool musicMono;
    public AudioClip musicClip;

    [Range(0.5f, 1.5f)]
    public float fontScale;
    public FontColor fontColor;
}

[System.Serializable]
public struct FontColor
{
    public string name;
    public Color color;
}
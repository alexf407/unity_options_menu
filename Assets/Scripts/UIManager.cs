using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public Events.MusicOptionsChanged OnMusicOptionsChange;
    public Events.GraphicsOptionsChanged OnGraphicsOptionsChange;
    public Events.LocalizationChanged OnLocalizationChange;
}

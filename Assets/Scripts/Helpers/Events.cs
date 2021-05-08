using UnityEngine.Events;

public class Events
{
    [System.Serializable] public class LocalizationChanged : UnityEvent<object> { }
    [System.Serializable] public class MusicOptionsChanged : UnityEvent<Enums.MusicOptions, object> { }
    [System.Serializable] public class GraphicsOptionsChanged : UnityEvent<Enums.GraphicsOptions, object> { }
}

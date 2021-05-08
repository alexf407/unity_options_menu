using UnityEngine;
using UnityEngine.UI;

public class SetFocus : MonoBehaviour
{
    Button button;
    Slider slider;

    private void Awake()
    {
        button = GetComponent<Button>();
        slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        button?.Select();
        slider?.Select();
    }
}

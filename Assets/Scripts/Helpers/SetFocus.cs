using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetFocus : MonoBehaviour
{
    Button button;
    Slider slider;
    TMP_Dropdown dropdown;

    private void Awake()
    {
        button = GetComponent<Button>();
        slider = GetComponent<Slider>();
        dropdown = GetComponent<TMP_Dropdown>();
    }

    private void OnEnable()
    {
        button?.Select();
        slider?.Select();
        dropdown?.Select();
    }
}

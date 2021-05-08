using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ConfigurableText : MonoBehaviour
{
    [Header("Optional TMPro text field")]
    [SerializeField] TextMeshProUGUI text;
    float origFontSize;

    private void Awake()
    {
        if (text == null)
        {
            text = GetComponent<TextMeshProUGUI>();
        }
        origFontSize = text.fontSize;
    }

    private void OnEnable()
    {
        UIManager.Instance.OnGraphicsOptionsChange.AddListener(ApplyTextChanges);
        ApplyConfigFontSettings();
    }

    private void OnDisable()
    {
        UIManager.Instance.OnGraphicsOptionsChange.RemoveListener(ApplyTextChanges);
    }

    void ApplyConfigFontSettings()
    {
        text.fontSize = origFontSize * GameManager.Instance.cfg.fontScale;
        text.color = GameManager.Instance.cfg.fontColor.color;
    }

    private void ApplyTextChanges(Enums.GraphicsOptions opt, object obj)
    {
        switch (opt)
        {
            case Enums.GraphicsOptions.FontScale:
                float fontScale = (float)obj;
                text.fontSize = origFontSize * fontScale;
                break;

            case Enums.GraphicsOptions.FontColor:
                Color color = (Color)obj;
                text.color = color;
                break;
        }
    }
}

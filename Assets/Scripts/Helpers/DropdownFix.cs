using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class DropdownFix : MonoBehaviour, ISelectHandler
{
    // Dropdown doesn't update scrollbar position correctly when user uses gamepad or keyboard
    // So this fix calculates correct position on select event

    public Scrollbar scrollbar;
    public RectTransform contentRectTransform;
    public RectTransform viewportRectTransform;
    RectTransform thisRectTransform;

    private void Start()
    {
        thisRectTransform = GetComponent<RectTransform>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (thisRectTransform == null || contentRectTransform == null || viewportRectTransform == null)
        {
            return;
        }

        float posY = thisRectTransform.localPosition.y;
        float offset = contentRectTransform.localPosition.y + posY;
        float halfSize = thisRectTransform.sizeDelta.y / 2;
        float scrollableHeight = contentRectTransform.sizeDelta.y - viewportRectTransform.rect.height;
        float viewportSize = viewportRectTransform.rect.height;

        if (offset < -viewportRectTransform.rect.height + halfSize)
        {
            scrollbar.value = (float)System.Math.Round(1 + ((posY - halfSize + viewportSize) / scrollableHeight), 2);
        }
        else if (offset > -halfSize)
        {
            scrollbar.value = (float)System.Math.Round(1 + ((posY + halfSize) / scrollableHeight), 2);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        ToolTipManager._instance.ShowToolTip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipManager._instance.HideToolTip();
    }
}

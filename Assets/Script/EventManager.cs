using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // Identify the active button (this.gameObject)
        Debug.Log("Clicked Button: " + this.gameObject.name);
    }
}

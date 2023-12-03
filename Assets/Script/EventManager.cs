using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * The EventManager class implements the IPointerClickHandler interface
 * to handle pointer click events on the attached GameObject.
 */
public class EventManager : MonoBehaviour, IPointerClickHandler
{
    /*
     * Called when a pointer (e.g., mouse) is clicked on the attached GameObject.
     * Logs the name of the clicked button.
     */
    public void OnPointerClick(PointerEventData eventData)
    {
        // Identify the active button (this.gameObject)
        Debug.Log("Clicked Button: " + this.gameObject.name);
    }
}

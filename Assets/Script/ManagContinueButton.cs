using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagContinueButton : MonoBehaviour
{
    public Scrollbar scrollbar;
    public Button continueButton;
    
    private void Start()
    {
        // Assuming the button should be inactive initially
        continueButton.interactable = false;
    }

    private void Update()
    {
        // Check if the scrollbar value is close to the bottom (adjust threshold as needed)
        if (scrollbar.value <= 0.2f)
        {
            continueButton.interactable = true;  // Enable the button
        }
        else
        {
            continueButton.interactable = false; // Disable the button
        }
    }
}

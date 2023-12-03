using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagContinueButton : MonoBehaviour
{
    // Public fields to assign in the Unity Editor
    public Scrollbar scrollbar;
    public Button continueButton;

    private void Start()
    {
        // Set the button to be inactive initially
        continueButton.interactable = false;
    }

    private void Update()
    {
        // Check if the scrollbar value is close to the bottom (adjust threshold as needed)
        if (IsScrollbarCloseToBottom())
        {
            EnableContinueButton();
        }
        else
        {
            DisableContinueButton();
        }
    }

    // Method to check if the scrollbar value is close to the bottom
    private bool IsScrollbarCloseToBottom()
    {
        // Adjust the threshold as needed
        return scrollbar.value <= 0.2f;
    }

    // Method to enable the continue button
    private void EnableContinueButton()
    {
        continueButton.interactable = true;
    }

    // Method to disable the continue button
    private void DisableContinueButton()
    {
        continueButton.interactable = false;
    }
}
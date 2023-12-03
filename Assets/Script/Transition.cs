using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Transition : MonoBehaviour
{
    // Variable to store the previous level name
    private string _previousLevel;

    // Start is called before the first frame update
    void Start()
    {
        // Initiate the coroutine to load the original scene after a delay
        StartCoroutine(LoadOriginalSceneAfterDelay());
    }

    // Coroutine to load the original scene after a delay
    IEnumerator LoadOriginalSceneAfterDelay()
    {
        // Wait for a specific duration (in seconds)
        yield return new WaitForSeconds(5);

        // Retrieve the name of the button that was selected
        string buttonName = PlayerPrefs.GetString("SelectedButtonName");

        // Update the selected button name based on the current selection
        switch (buttonName.ToLower())
        {
            case "easy":
                PlayerPrefs.SetString("SelectedButtonName", "medium");
                break;
            case "medium":
                PlayerPrefs.SetString("SelectedButtonName", "hard");
                break;
        }

        // Load the previous scene in the build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

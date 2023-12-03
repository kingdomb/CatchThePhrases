using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginSteps : MonoBehaviour
{
    // Countdown information
    [Header("Count down information")]
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private int countdownDuration = 3;

    // Reference to the container to be disabled
    public GameObject disableGameInstructionContainer;

    // Method to be called on confirmation
    public void Confirm()
    {
        // Disable the game instruction container if it's not null
        if (disableGameInstructionContainer != null)
        {
            disableGameInstructionContainer.SetActive(false);
        }

        // Start the countdown
        StartCoroutine(StartCountdown());
    }

    // Coroutine to handle the countdown
    private IEnumerator StartCountdown()
    {
        int timeLeft = countdownDuration;

        while (timeLeft > 0)
        {
            // Display the countdown text
            countdownText.text = Mathf.Ceil(timeLeft).ToString();
            yield return new WaitForSeconds(1);
            timeLeft -= 1;
        }

        // Display "Go!" when the countdown finishes
        countdownText.text = "Go!";

        // Start the next scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

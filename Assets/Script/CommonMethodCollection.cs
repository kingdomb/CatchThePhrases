using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This class provides common methods for managing text display and game resetting.
 */
public class CommonMethodCollection : MonoBehaviour
{
    public TextMeshProUGUI answerTextPro;  // Reference to the TextMeshProUGUI component for answer text.
    public float textBlinkInterval = 1.0f;  // Interval for text blinking.

    public bool isAnsVisible = true;        // Flag indicating whether the answer text is currently visible.
    private float maxWaitTime = 6.0f;        // Maximum waiting time for text blinking.
    private float elapsedTime = 0.0f;        // Elapsed time for tracking text blinking.

    /*
     * Coroutine to control the blinking of the answer text.
     */
    public void AnsBlinkCourtine()
    {
        answerTextPro = GetComponent<TextMeshProUGUI>();

        if (answerTextPro != null)
        {
            while (elapsedTime <= maxWaitTime)
            {
                isAnsVisible = !isAnsVisible;
                answerTextPro.enabled = isAnsVisible;
                // yield return new WaitForSeconds(textBlinkInterval);
                System.Threading.Thread.Sleep((int)(textBlinkInterval));

                elapsedTime += textBlinkInterval;
            }
        }
        else
        {
            Debug.LogError("The answerTextPro is null.");
        }
    }

    /*
     * Resets the current game by reloading the current scene.
     */
    public void ResetGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
}

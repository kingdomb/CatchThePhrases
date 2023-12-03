using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * The mainMenu class handles the functionality of the main menu buttons.
 */
public class mainMenu : MonoBehaviour
{
    /*
     * Loads the next scene when the "Play" button is clicked.
     * Alternatively, you can specify the scene name.
     */
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // Alternatively, you can use:
        // SceneManager.LoadScene("sampleScene");
    }

    /*
     * Quits the application when the "Quit" button is clicked.
     */
    public void Quit()
    {
        Application.Quit();
    }
}

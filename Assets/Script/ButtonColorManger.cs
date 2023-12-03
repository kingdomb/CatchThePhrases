using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * This class manages the active color of difficulty level buttons.
 */
public class ButtonColorManger : MonoBehaviour
{
    public Button initialSelectedButton;
    public ImageCollectionControll imageCollectionControll;

    /*
     * Changes the color of the active difficulty level button.
     */
    public void ChangeButtonColor()
    {
        string buttonName = PlayerPrefs.GetString("SelectedButtonName");

        if (!string.IsNullOrEmpty(buttonName))
        {
            imageCollectionControll.SetDifficultyLevel(buttonName.ToLower());

            Button[] allButtons = FindObjectsOfType<Button>();
            foreach (Button button in allButtons)
            {
                if (button.name.ToLower() == buttonName.ToLower())
                {
                    button.Select();

                    // Reset the selected button name for 'hard' difficulty
                    if (PlayerPrefs.GetString("SelectedButtonName").ToLower() == "hard")
                        PlayerPrefs.SetString("SelectedButtonName", "");
                    break;
                }
            }
        }
        else if (initialSelectedButton != null)
        {
            // Select the initial button and save its name
            initialSelectedButton.Select();
            PlayerPrefs.SetString("SelectedButtonName", initialSelectedButton.name.ToLower());
        }
    }

    /*
     * Keeps the existing difficulty level button active.
     */
    public void KeepExistingButtonActive()
    {
        string buttonName = PlayerPrefs.GetString("SelectedButtonName");

        Button[] allButtons = FindObjectsOfType<Button>();
        foreach (Button button in allButtons)
        {
            if (button.name.ToLower() == buttonName.ToLower())
            {
                button.Select();

                // Reset the selected button name for 'hard' difficulty
                if (PlayerPrefs.GetString("SelectedButtonName").ToLower() == "hard")
                    PlayerPrefs.SetString("SelectedButtonName", "");
                break;
            }
        }
    }
}

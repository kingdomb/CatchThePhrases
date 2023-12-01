using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorManger : MonoBehaviour
{
    public Button initialSelectedButton;
    public ImageCollectionControll imageCollectionControll;

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

                    if(PlayerPrefs.GetString("SelectedButtonName").ToLower() == "hard")
                        PlayerPrefs.SetString("SelectedButtonName", "");
                    break;
                }
            }
        }
        else if (initialSelectedButton != null)
        {
            initialSelectedButton.Select();
            PlayerPrefs.SetString("SelectedButtonName", initialSelectedButton.name.ToLower());
        }
    }

    public void KeepExisitngButtonActive()
    {
        string buttonName = PlayerPrefs.GetString("SelectedButtonName");

        Button[] allButtons = FindObjectsOfType<Button>();
        foreach (Button button in allButtons)
        {
            if (button.name.ToLower() == buttonName.ToLower())
            {
                button.Select();

                if (PlayerPrefs.GetString("SelectedButtonName").ToLower() == "hard")
                    PlayerPrefs.SetString("SelectedButtonName", "");
                break;
            }
        }
    }
}

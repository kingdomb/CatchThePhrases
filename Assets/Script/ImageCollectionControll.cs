using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ImageCollectionControll : MonoBehaviour
{
    // Reference to the GameStartCountdown script
    public GameStartCountdown gameStartCountdown;

    // Image collections for different difficulty levels
    public Common imageCollectionEasy;
    public Common imageCollectionMedium;
    public Common imageCollectionHard;

    // Reference to the UI image
    [SerializeField] private Image imageUI;

    // List to store the current image collection
    private List<Common.ImageData> currentImageList;

    // Method to set the difficulty level and initialize the game
    public void SetDifficultyLevel(string level)
    {
        // Set the current image list based on the selected difficulty level
        switch (level.ToLower())
        {
            case "easy":
                currentImageList = imageCollectionEasy.imageDatas;
                break;
            case "medium":
                currentImageList = imageCollectionMedium.imageDatas;
                break;
            case "hard":
                currentImageList = imageCollectionHard.imageDatas;
                break;
        }

        // Save the selected difficulty level
        PlayerPrefs.SetString("SelectedButtonName", level.ToLower());

        // Enable the answer input field for the player
        gameStartCountdown.answerInputField.enabled = true;

        // Start the countdown and update the image collection
        StartCoroutine(gameStartCountdown.StartCountdown());
        gameStartCountdown.UpdateImageCollection(currentImageList);
    }

    // Method to display a random image from the current collection
    public void ShowRandomImage()
    {
        if (currentImageList != null && currentImageList.Count > 0)
        {
            int randomIndex = Random.Range(0, currentImageList.Count);
            imageUI.sprite = currentImageList[randomIndex].image;
        }
    }
}

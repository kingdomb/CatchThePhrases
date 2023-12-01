using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class ImageCollectionControll : MonoBehaviour
{
    public GameStartCountdown gameStartCountdown;

    //[Header("Iamge Collections")]
    //[SerializeField] private List<Sprite> imageCollectionEasy;
    //[SerializeField] private List<Sprite> imageCollectionMedium;
    //[SerializeField] private List<Sprite> imageCollectionHard;
    public Common imageCollectionEasy;
    public Common imageCollectionMedium;
    public Common imageCollectionHard;

    [SerializeField] private Image imageUI;

    //private List<Sprite> currentImageList;

    private List<Common.ImageData> currentImageList;
    public void SetDifficultyLevel(string level)
    {
        switch (level.ToLower())
        {
            case "easy":
                //currentImageList = imageCollectionEasy.images;
                currentImageList = imageCollectionEasy.imageDatas;
                break;
            case "medium":
                //currentImageList = imageCollectionMedium.images;
                currentImageList = imageCollectionMedium.imageDatas;
                break;
            case "hard":
                //currentImageList = imageCollectionHard.images;
                currentImageList = imageCollectionHard.imageDatas;
                break;
        }
        PlayerPrefs.SetString("SelectedButtonName", level.ToLower());

        gameStartCountdown.answerInputField.enabled = true;

        //ShowRandomImage();
        StartCoroutine(gameStartCountdown.StartCountdown());
        gameStartCountdown.UpdateImageCollection(currentImageList);
    }

    public void ShowRandomImage()
    {
        if (currentImageList != null && currentImageList.Count > 0)
        {
            int randomIndex = Random.Range(0, currentImageList.Count);
            imageUI.sprite = currentImageList[randomIndex].image;
        }
    }
}

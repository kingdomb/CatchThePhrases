using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using System;

public class GameStartCountdown : MonoBehaviour
{
    //public CommonMethodCollection commonMethodCollection;

    [Header("Timer")]
    [SerializeField] private float countdownDuration = 5;
    //[SerializeField] private string sceneToLoad;
    [SerializeField] private TMP_Text countdownText;

    private bool _pausedCliked = false;

    [Header("Iamge Collections")]
    //public List<Sprite> imagecollection;
    public List<Common.ImageData> imagecollection;


    [Header("Dependent variables")]
    [SerializeField] private Image imageUI;
    //[SerializeField] private TMP_InputField answerInputField;
    public TMP_InputField answerInputField;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private Button submitButton;
    [SerializeField] private Button skipButton;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highestScoreText;

    private int currentImageIndex;
    private int score;
    private int highestScore;
    private float countdown;

    public ButtonColorManger buttonColorManger;
    public AnswerAudioManager answerAudioManager;

    //when scene load, set the default values of score, the image intiated
    //add event listner to submit button
    private void Start()
    {
        //// Make sure the tooltip is initially hidden
        //tooltipCanvasGroup.alpha = 0;
        //tooltipCanvasGroup.blocksRaycasts = false;

        buttonColorManger.ChangeButtonColor();
        highestScore = PlayerPrefs.GetInt("HghestScoreRecord", 3);
        score = 0;
        currentImageIndex = 0;
        UpdateImage();

        UpdateScoreTextValue();
        UpdateHighestScoreTextValue();
        // Add a cliclk event function to submit button
        submitButton.onClick.AddListener(ValidateAnswer);

        //Add a click event function to skip button
        skipButton.onClick.AddListener(SkipAndMoveToLast);


        StartCoroutine(StartCountdown());
        // Subscribe to input field's text change event
        answerInputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    public IEnumerator StartCountdown()
    {

        countdown = countdownDuration * 60;

        while (countdown > 0)
        {
            if (!_pausedCliked)
            {
                updateTimerTextValue();
                yield return new WaitForSeconds(1);
                countdown--;
            }
            else
            {
                yield return null;
            }
        }

        countdownText.text = "00:00";
        answerInputField.enabled = false;
        // Load the specified scene after a delay (you can adjust this delay)
        yield return new WaitForSeconds(1);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void updateTimerTextValue()
    {
        float min = Mathf.Floor(countdown / 60);
        float sec = countdown % 60;
        countdownText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
    //Pause the game playing 
    public void PausedClicked()
    {
        _pausedCliked = true;
        buttonColorManger.KeepExisitngButtonActive();
    }
    //resume game from paused
    public void resumeClick()
    {
        _pausedCliked = false;
        buttonColorManger.KeepExisitngButtonActive();
    }

    //To add image into UA image section
    public void UpdateImage()
    {
        if (currentImageIndex >= 0 && currentImageIndex < imagecollection.Count)
        {
            imageUI.sprite = imagecollection[currentImageIndex].image;

            // Set the tooltip text value for the image
            ToolTipManager._instance.textComponent.text = imagecollection[currentImageIndex].tooltipText;
            resultText.text = "";
        }
    }

    //for skip functionlaity
    public void SkipAndMoveToLast()
    {
        buttonColorManger.KeepExisitngButtonActive();
        // Move the current image to the last index
        if (currentImageIndex < imagecollection.Count - 1)
        {
            Common.ImageData currentImageData = imagecollection[currentImageIndex];
            imagecollection.RemoveAt(currentImageIndex);
            imagecollection.Add(currentImageData);
            UpdateImage();
        }
    }
    public void ValidateAnswer()
    {
        buttonColorManger.KeepExisitngButtonActive();
        string answerPassed = answerInputField.text;

        if (currentImageIndex >= 0 && currentImageIndex < imagecollection.Count)
        {
            string correctAnswer = imagecollection[currentImageIndex].image.name;

            if (answerPassed.Trim().ToLower() == correctAnswer.Trim().ToLower())
            {
                // Play correct sound
                if (answerAudioManager != null)
                {
                    answerAudioManager.PlayCorrectSound();
                }

                score++;
                resultText.text = "<color=#80b3ff>Correct!</color>";

                UpdateScoreTextValue();

                
                //increase the time by 20 sec for winner
                countdown += 20;

                //set the highest score value
                if (score > highestScore)
                {
                    PlayerPrefs.SetInt("HghestScoreRecord", score);
                    highestScore = score;

                    UpdateHighestScoreTextValue();
                }

                currentImageIndex++;
                if (currentImageIndex == imagecollection.Count)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                else
                {
                    UpdateImage();
                    answerInputField.text = "";
                }
            }
            else
            {
                // Play incorrect sound
                if (answerAudioManager != null)
                {
                    answerAudioManager.PlayIncorrectSound();
                }

                resultText.text = "<color=#ff5c33>Incorrect. Try again.</color>";
                
            }
        }
    }
    //updates player cuyrrent correct value
    public void UpdateScoreTextValue()
    {
        scoreText.text = "Current score: " + score;
    }
    //updates highest score value
    public void UpdateHighestScoreTextValue()
    {
        highestScoreText.text = "Highest Score: " + highestScore;
    }
    //Method to update the imagecollection per diffcult level choice
    public void UpdateImageCollection(List<Common.ImageData> newImageCollection)
    {
        imagecollection = newImageCollection;
    }

    public void ExitGame()
    {
        PlayerPrefs.SetString("SelectedButtonName", "");
        Application.Quit();
    }

    private void OnInputValueChanged(string inputText)
    {
        // Check if the entered value exactly matches one of the suggestions
        //bool isCorrect = suggestions.Contains(inputText);
        string answerValue = imagecollection[currentImageIndex].image.name;
        bool isCorrect = answerValue.Trim().ToLower() == inputText.Trim().ToLower();
        // Change text color based on correctness
        answerInputField.textComponent.color = isCorrect ? Color.green : Color.black;

        //display correct placehloder
        if (isCorrect)
        {
            resultText.text = "<color=#80b3ff>Correct!</color>";
        }
        else
        {
            resultText.text = "";
        }
    }
}



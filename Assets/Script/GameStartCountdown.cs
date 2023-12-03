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
    [Header("Timer")]
    [SerializeField] private float countdownDuration = 5;
    [SerializeField] private TMP_Text countdownText;

    private bool _pausedCliked = false;

    [Header("Image Collections")]
    public List<Common.ImageData> imagecollection;

    [Header("Dependent Variables")]
    [SerializeField] private Image imageUI;
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

    // Initialization when the scene loads
    private void Start()
    {
        buttonColorManger.ChangeButtonColor();
        highestScore = PlayerPrefs.GetInt("HghestScoreRecord", 3);
        score = 0;
        currentImageIndex = 0;
        UpdateImage();

        UpdateScoreTextValue();
        UpdateHighestScoreTextValue();

        submitButton.onClick.AddListener(ValidateAnswer);
        skipButton.onClick.AddListener(SkipAndMoveToLast);

        StartCoroutine(StartCountdown());
        answerInputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    // Coroutine for the countdown timer
    public IEnumerator StartCountdown()
    {
        countdown = countdownDuration * 60;

        while (countdown > 0)
        {
            if (!_pausedCliked)
            {
                UpdateTimerTextValue();
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

        // Load the next scene after a delay
        yield return new WaitForSeconds(1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update the timer text value
    public void UpdateTimerTextValue()
    {
        float min = Mathf.Floor(countdown / 60);
        float sec = countdown % 60;
        countdownText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    // Pause the game
    public void PausedClicked()
    {
        _pausedCliked = true;
        buttonColorManger.KeepExistingButtonActive();
    }

    // Resume the game from paused state
    public void ResumeClick()
    {
        _pausedCliked = false;
        buttonColorManger.KeepExistingButtonActive();
    }

    // Update the displayed image
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

    // Skip functionality to move the current image to the last index
    public void SkipAndMoveToLast()
    {
        buttonColorManger.KeepExistingButtonActive();

        if (currentImageIndex < imagecollection.Count - 1)
        {
            Common.ImageData currentImageData = imagecollection[currentImageIndex];
            imagecollection.RemoveAt(currentImageIndex);
            imagecollection.Add(currentImageData);
            UpdateImage();
        }
    }

    // Validate the player's answer
    public void ValidateAnswer()
    {
        buttonColorManger.KeepExistingButtonActive();
        string answerPassed = answerInputField.text;

        if (currentImageIndex >= 0 && currentImageIndex < imagecollection.Count)
        {
            string correctAnswer = imagecollection[currentImageIndex].image.name;

            if (answerPassed.Trim().ToLower() == correctAnswer.Trim().ToLower())
            {
                score++;

                // Play correct sound
                answerAudioManager.PlayCorrectSound();
               
                resultText.text = "<color=#80b3ff>Correct!</color>";

                UpdateScoreTextValue();

                // Increase the time by 20 sec for the winner
                countdown += 20;

                // Set the highest score value
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
                answerAudioManager.PlayIncorrectSound();

                resultText.text = "<color=#ff5c33>Incorrect. Try again.</color>";
            }
        }
    }

    // Update the displayed current score
    public void UpdateScoreTextValue()
    {
        scoreText.text = "Current score: " + score;
    }

    // Update the displayed highest score
    public void UpdateHighestScoreTextValue()
    {
        highestScoreText.text = "Highest Score: " + highestScore;
    }

    // Method to update the image collection per difficulty level choice
    public void UpdateImageCollection(List<Common.ImageData> newImageCollection)
    {
        imagecollection = newImageCollection;
    }

    // Exit the game
    public void ExitGame()
    {
        PlayerPrefs.SetString("SelectedButtonName", "");
        Application.Quit();
    }

    // Event handler for input field text change
    private void OnInputValueChanged(string inputText)
    {
        string answerValue = imagecollection[currentImageIndex].image.name;
        bool isCorrect = answerValue.Trim().ToLower() == inputText.Trim().ToLower();

        // Change text color based on correctness
        answerInputField.textComponent.color = isCorrect ? Color.green : Color.black;

        // Display correct placeholder
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

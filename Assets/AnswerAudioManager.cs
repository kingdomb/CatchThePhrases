using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerAudioManager : MonoBehaviour
{
    // Public fields to assign audio sources in the Unity Editor
    public AudioSource correctAns;
    public AudioSource wrongAns;

    // Method to play the correct sound
    public void PlayCorrectSound()
    {
        // Check if the correctAns AudioSource is not null
        if (correctAns != null)
        {
            // Play the audio assigned to the correctAns AudioSource
            correctAns.Play();
        }
    }

    // Method to play the incorrect sound
    public void PlayIncorrectSound()
    {
        // Check if the wrongAns AudioSource is not null
        if (wrongAns != null)
        {
            // Play the audio assigned to the wrongAns AudioSource
            wrongAns.Play();
        }
    }
}
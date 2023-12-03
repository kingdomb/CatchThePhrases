using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerAudioManager : MonoBehaviour
{
    public AudioSource correctAns;
    public AudioSource wrongAns;

    public void PlayCorrectSound()
    {
        if (correctAns != null)
        {
            correctAns.Play();
        }
    }

    public void PlayIncorrectSound()
    {
        if (wrongAns != null)
        {
            wrongAns.Play();
        }
    }
}

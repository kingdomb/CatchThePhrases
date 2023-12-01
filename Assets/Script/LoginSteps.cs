using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginSteps : MonoBehaviour
{
    [Header("Count down inforation")]
    [SerializeField] private TMP_Text countdownText;
    [SerializeField] private int countdownDuration = 3;

    //private void Start()
    //{
    //    StartCoroutine(StartCountdown());
    //}

    public void Confirm()
    {
        StartCoroutine(StartCountdown());
    }
    //yield results a wait for a sec to count down
    private IEnumerator StartCountdown()
    {
        int timeLeft = countdownDuration;

        while (timeLeft > 0)
        {
            countdownText.text = Mathf.Ceil(timeLeft).ToString();
            yield return new WaitForSeconds(1);
            timeLeft -= 1;
        }

        countdownText.text = "Go!"; 

        // Start the next scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

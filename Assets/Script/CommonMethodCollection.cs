using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonMethodCollection : MonoBehaviour
{
    public TextMeshProUGUI answerTextPro;
    public float textBlinkInterval = 1.0f;

    public bool isAnsVisible = true;
    private float maxWaitTime = 6.0f;
    private float elapsedTime = 0.0f;
    public void AnsBlinkCourtine()
    {
        answerTextPro = GetComponent<TextMeshProUGUI>();

        if(answerTextPro != null)
        {
            while (elapsedTime <= maxWaitTime)
            {
                isAnsVisible = !isAnsVisible;
                answerTextPro.enabled = isAnsVisible;
                // yield return new WaitForSeconds(textBlinkInterval);
                System.Threading.Thread.Sleep((int)(textBlinkInterval));

                elapsedTime += textBlinkInterval;
            }
        }
        else
        {
            Debug.LogError("the answerTextPro is null");
        }
        
    }

    public void ResetGame()
    {
        string CurrentScence = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(CurrentScence);
    }
}

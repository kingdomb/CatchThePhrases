using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //or we can use 
        //SceneManager.LoadScene("sampleScene");
    }
    public void Quit()
    {
       Application.Quit();
    }
}

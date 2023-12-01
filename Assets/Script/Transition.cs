
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Transition : MonoBehaviour
{
    private string _previouseLevel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadOriginalSceneAfterDelay());
    }

    // Update is called once per frame
    IEnumerator LoadOriginalSceneAfterDelay()
    {
        //int waitingTime =   Convert.ToInt32(Configuration.GetAppsettings("waitingTime"));
        //wait for 10 sec
        yield return new WaitForSeconds(5);
        string buttonName = PlayerPrefs.GetString("SelectedButtonName");

        switch (buttonName.ToLower())
        {
            case "easy":
                PlayerPrefs.SetString("SelectedButtonName", "medium");
                break;
            case "medium":
                PlayerPrefs.SetString("SelectedButtonName", "hard");
                break;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

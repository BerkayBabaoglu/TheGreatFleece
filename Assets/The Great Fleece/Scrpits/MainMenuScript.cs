using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void startTheGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void quitTheGame()
    {
        Application.Quit();
    }
}

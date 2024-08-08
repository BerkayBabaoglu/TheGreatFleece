using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("UIManager is null!");
            }

            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }


    public void restart()
    {
        SceneManager.LoadScene("Main");
    }

    public void quit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneNavigation : MonoBehaviour
{

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneByBuildIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    ////expand this by making it take a float variable and putting that as the invoke time.
    //public void LoadMainMenuAfterWait()
    //{
    //    Invoke("LoadMainMenu", 3.0f);
    //}

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Application.");
    }
}

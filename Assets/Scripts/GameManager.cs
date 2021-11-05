using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton Game Manager
    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }


    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
        
    }

    #endregion

    //todo-- same behaviour, no sockets.

    public ButtonSceneNavigation sceneNavigation;
    public bool cardInReader = false;

    public void PlayerWins()
    {
        Debug.Log("hello from PlayerWins() in GameManager");
        Debug.Log("bool cardInReader is:");
        Debug.Log(cardInReader.ToString());
       // sceneNavigation.LoadScene("MainMenu");
    }

}

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



    public void PlayerWins()
    {

        Debug.Log("hello from PlayerWins() in GameManager");
        Debug.Log("Player Wins! Put some Logic in here");
        Debug.Log("xxxxxxxxxxxxxxx");
    }

}

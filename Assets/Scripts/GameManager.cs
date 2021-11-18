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


    public ButtonSceneNavigation sceneNavigation;
    private bool winConditionReached = false;



    public void PlayerWins()
    {
        Debug.Log("-----------------------------------------------------------------------hello from PlayerWins() in GameManager");

        sceneNavigation.LoadScene("MainMenu");

    }

    public void CheckWinConditions()
    {
        Debug.Log("hello from check win condition");
        Debug.Log("winConditionReached is :::::::::::::::::::" + winConditionReached.ToString());
        if(winConditionReached)
        {
            Debug.Log("windcondition reached, invoking playerwins in 3-2-1");
            Invoke("PlayerWins", 3.0f);
        }
    }

    public void AchieveWinningCondition()
    {
        winConditionReached = true;
    }


}

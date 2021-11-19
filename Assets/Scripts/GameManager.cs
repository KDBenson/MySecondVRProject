using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool winConditionReached = false;


    public void PlayerWins()
    {
        Debug.Log("-----------------------------------------------------------------------hello from PlayerWins() in GameManager");
        sceneNavigation.LoadMainMenu();
    }

    public void CheckWinConditions()
    {
        
        Debug.Log("hello from check win condition");
        Invoke("PlayerWins", 1.5f);
        //PlayerWins();
    }

    
    public void AchieveWinningCondition()
    {
        winConditionReached = true;
    }

    public void RemoveWinningCondition()
    {
        winConditionReached = false;
    }

}

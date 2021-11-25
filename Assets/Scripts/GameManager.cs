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
        Debug.Log("---------------------------------------hello from PlayerWins() in GameManager");
        //having issue with this being null if I try to do it more than once
        sceneNavigation.LoadMainMenu();

    }

    public void CheckWinConditions()
    {
        
        Debug.Log("hello from check win condition");
        Invoke("PlayerWins", 2.5f);
        //PlayerWins();
    }

    public void TestThing()
    {
        //making this because for some reason it'll only invoke player wins on the very first time the triggerable goes off, and only if it's the first card used
        Debug.Log("~~~#############~~~~~~~~~~~~~~~~~~~~~~~~Hello from Test thing");
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

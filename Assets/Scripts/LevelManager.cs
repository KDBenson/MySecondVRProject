using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    //this intermediary layer talks to the Game Manager on the hgher plane of existence

    public void CheckWinConditions()
    {
        GameManager.Instance.CheckWinConditions();
    }

    public void TestThing()
    {
        GameManager.Instance.TestThing();
    }

    public void TestExitThing()
    {
        GameManager.Instance.TestExitThing();
    }

}

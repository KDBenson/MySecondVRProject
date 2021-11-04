using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTriggerArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object collider enters OnTriggerEnter is tagged: ");
        Debug.Log(other.tag);
        if(other.tag == "IDCard")
        {
            GameManager.Instance.PlayerWins();
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTriggerArea : MonoBehaviour
{
    public string targetTag = string.Empty;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object collider enters OnTriggerEnter is tagged: " + other.tag);
        if(other.CompareTag(targetTag))
        {
            GameManager.Instance.PlayerWins();
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTagCheck : MonoBehaviour
{
    //case sensitive tag to check for
    public string targetTag = " ";

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag(targetTag))
        {
            Debug.Log("SimpleTagCheck Tag match!-----------------------");
        }
    }

    public bool LookForMatchingTag(GameObject gameObject)
    {
        return gameObject.CompareTag(targetTag);
    }

}

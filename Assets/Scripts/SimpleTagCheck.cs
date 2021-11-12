using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTagCheck : MonoBehaviour
{
    //case sensitive tag to check for
    public string targetTag = " ";

    public bool LookForMatchingTag(GameObject gameObject)
    {
        return gameObject.CompareTag(targetTag);
    }

    public bool LookForMatchingTagWithString(GameObject gameObject, string compare)
    {
        return gameObject.CompareTag(compare);
    }

}

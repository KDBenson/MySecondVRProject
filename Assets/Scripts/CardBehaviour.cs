using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    private GameObject _currentInteractable;

    private void OnCollisionEnter(Collision collision)
    {
        _currentInteractable = collision.gameObject;
        if (_currentInteractable != null)
        {
            Debug.Log("Card in the reader! Good!");
        }
    }
}

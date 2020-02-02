using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<Roomba>() != null)
        {
            ShowInteractableAllLayers();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Roomba>() != null)
        {
            HideInteractable();
        }
    }

    private void ShowInteractableAllLayers()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.layer = 11;
        }
    }
    private void HideInteractable()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.layer = 10;
        }
    }
    public virtual void PickUp()
    {
        gameObject.SetActive(false);
    }
}

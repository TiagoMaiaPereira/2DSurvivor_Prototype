using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingBox : MonoBehaviour, IInteractable
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Interaction>().SetInteractable(this);
            Debug.Log("Can Interact");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Interaction>().SetInteractable(null);
            Debug.Log("Can't Interact");
        }
    }


    public void Interact()
    {
        Destroy(gameObject);
    }
}

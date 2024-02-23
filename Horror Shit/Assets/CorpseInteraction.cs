using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseInteraction : Interactable
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("The player has entered");
        }
    }
    protected override void Interact()
    {

    }
}

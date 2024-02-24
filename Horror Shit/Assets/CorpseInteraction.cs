using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseInteraction : Interactable
{
    [SerializeField]
    private GameObject cutScene;
    [SerializeField]
    private GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("The player has entered");
        }
    }
    protected override void Interact()
    {
        DeactivatePlayer();
        ActivateCutscene();
        StartCoroutine(FinishCutScene());
    }

    private void ActivateCutscene()
    {
        cutScene.SetActive(true);
    }

    private void DeactivatePlayer()
    {
        player.SetActive(false);
    }
    IEnumerator FinishCutScene()
    {
        yield return new WaitForSeconds(2.53f);
        player.SetActive(true);
        cutScene.SetActive(false);
    }
}

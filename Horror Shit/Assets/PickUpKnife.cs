using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKnife : Interactable
{
    public Animator playerAnimatorForKnife;
    public KeyItermTracker keyItemTracker;
    public GameObject knifeObjectPickUp;

    protected override void Interact()
    {
        playerAnimatorForKnife.SetBool("hasKnife", true);
        keyItemTracker.playerHasKnife = true;
        knifeObjectPickUp.SetActive(true);
        StartCoroutine(SpriteRemoval());
    }

    IEnumerator SpriteRemoval()
    {
        yield return new WaitForSeconds(2f);
        knifeObjectPickUp.SetActive(false);
        Destroy(this.gameObject);
    }
}

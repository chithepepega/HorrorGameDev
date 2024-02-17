using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject armsFlashLight;

    public bool flashLightIsOn;
    public Animator animator;

    private void Awake()
    {
        flashLightIsOn = false;
    }
    private void Update()
    {
        FlashLightArm();
    }
    private void Start()
    {
        armsFlashLight.SetActive(false);
    }

    IEnumerator PlayAnimationAndDeactivate()
    {
        Debug.Log("We getting into iEnumerator");
        animator.Play("Put_TelephoneAway");
        // Wait for the animation to finish. Here, 1f is the length of the animation in seconds.
        yield return new WaitForSeconds(2f);
        armsFlashLight.SetActive(false);
        flashLightIsOn = false;
    }

    public void FlashLightArm()
    {
        if (!flashLightIsOn)
        { 
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Flash light is on");
                armsFlashLight.SetActive(true);
                flashLightIsOn = true;
            }
        }
        else
        {
            if (flashLightIsOn == false)
                return;

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Flash light off");
                StartCoroutine(PlayAnimationAndDeactivate());
            }
        }

    }

}

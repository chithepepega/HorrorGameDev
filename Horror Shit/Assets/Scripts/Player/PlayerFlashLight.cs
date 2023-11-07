using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashLight : MonoBehaviour
{
    public FlashLightOnOff flashLightOnOff;
    public Animator anim;
    public GameObject flashLight;
    private bool flashlightOn;
    private float flashlightBaterry;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        flashLight.SetActive(false);
        flashlightOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        Flashlight();
    }
    IEnumerator PlayAnimationAndDeactivate()
    {
        anim.Play("Put_TelephoneAway");
        // Wait for the animation to finish. Here, 1f is the length of the animation in seconds.
        yield return new WaitForSeconds(2f);
        flashLight.SetActive(false);
        flashlightOn = false;
    }
    void Flashlight()
    {
        if (!flashlightOn)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                flashLightOnOff.cameraLight.intensity = 2f;
                flashLight.SetActive(true);
                flashlightOn = true;
            }
        }
        else
        {
            if (flashlightOn == false)
            return;
             
             if (Input.GetKeyDown(KeyCode.F))
             {
                StartCoroutine(PlayAnimationAndDeactivate());
             }
        }
        
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject armsFlashLight;
    public FlashLightInputManager flashLightInputManager;

    private void Awake()
    {
        flashLightInputManager = GetComponentInChildren<FlashLightInputManager>();
    }

    private void Start()
    {
        armsFlashLight.SetActive(false);
    }

    public void FlashLightArm()
    {
        if (flashLightInputManager.flashLightIsOn == false)
        {
            armsFlashLight.SetActive(true);
        }
        if(flashLightInputManager.flashLightIsOn == true)
        {
            armsFlashLight.SetActive(false);
        }
   
    }

}

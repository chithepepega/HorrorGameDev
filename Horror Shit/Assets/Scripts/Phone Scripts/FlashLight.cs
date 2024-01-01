using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject armsFlashLight;
    private bool flashLightOn = true;
    

    public void FlashLightArm()
    {
        if (!flashLightOn)
            return;
        armsFlashLight.SetActive(true);

    }

    public void FlashLightArm0ff()
    {
        if (flashLightOn)
            return;
        armsFlashLight.SetActive(false);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightOnOff : MonoBehaviour
{
    public GameObject flashLight;
    public Light cameraLight;
    public float minWaitTime = 0.1f;
    public float maxWaitTime = 10f;

    private void Start()
    {
        InvokeRepeating("GlitchFlashLight",60, Random.Range(60, 120));
       
    }
   
    public void FlashLightOn()
    {
        flashLight.SetActive(true);
    }

    public void FlashLightOff()
    {
        flashLight.SetActive(false);
    }
    void GlitchFlashLight()
    {
        StartCoroutine(GlitchLight());
    }

    IEnumerator GlitchLight()
    {
        int randomNumber = Random.Range(1, 3);
        if (randomNumber == 1)
        {

            Debug.Log("Opcao 1");
            cameraLight.intensity = 0f;
        }
        else if (randomNumber == 2)
        {
            Debug.Log("Opcao 2");
            cameraLight.intensity = 3f;
        }
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
    }
}

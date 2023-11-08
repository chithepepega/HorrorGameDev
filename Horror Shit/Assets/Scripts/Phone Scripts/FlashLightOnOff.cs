using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightOnOff : MonoBehaviour
{
    public GameObject flashLight;
    public Light cameraLight;
    public float minWaitTime = 0.1f;
    public float maxWaitTime = 10f;
    public bool glitched;

    private void Awake()
    {
        glitched = false;
    }
    private void Start()
    {
        
        if (flashLight.activeSelf)
        {
            InvokeRepeating("GlitchFlashLight", 10, Random.Range(10, 20));
        }
       
    }

    private void LateUpdate()
    {

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
            glitched = true;
            Debug.Log("Opcao 1");
            cameraLight.intensity = 0f;
        }
        else if (randomNumber == 2)
        {
            glitched = false;
            Debug.Log("Opcao 2");
            cameraLight.intensity = 2f;
        }
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
    }
}

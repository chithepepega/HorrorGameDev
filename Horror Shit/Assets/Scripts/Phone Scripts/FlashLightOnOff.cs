using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightOnOff : MonoBehaviour
{
    public GameObject phone;
    public GameObject flashLight;
    public Light cameraLight;
    public float minWaitTime = 0.1f;
    public float maxWaitTime = 10f;
    public bool glitched;
    public Material newScreenMaterial;
    public Material currentScreenMaterial;
    public bool caller;

    private void Awake()
    {
        glitched = false;
    }
    private void Start()
    {
        if (phone.activeInHierarchy)
        {
            InvokeRepeating("GlitchFlashLight", 10, Random.Range(10, 20));
        }
        else
        {
            return;
        }
       
    }

    private void LateUpdate()
    {

    }

    public void FlashLightOn()
    {
        var myRenderer = phone.GetComponent<Renderer>();
        var TempArray = myRenderer.materials;
        TempArray[1] = currentScreenMaterial;
        myRenderer.materials = TempArray;
        flashLight.SetActive(true);
    }

    public void FlashLightOff()
    {
        var myRenderer = phone.GetComponent<Renderer>();
        var TempArray = myRenderer.materials;
        TempArray[1] = newScreenMaterial;
        myRenderer.materials = TempArray;
        flashLight.SetActive(false);
    }
    void GlitchFlashLight()
    {
        StartCoroutine(GlitchLight());
    }

    IEnumerator GlitchLight()
    {
        int randomNumber = Random.Range(1, 4);
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
        else if (randomNumber == 3)
        {
            caller = true;
            Debug.Log("caller");
        }
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashLight : MonoBehaviour
{
    public GameObject flashLight;
    private bool flashlightOn;
    
    
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

    void Flashlight()
    {
        if (!flashlightOn)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
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
                flashLight.SetActive(false);
                flashlightOn = false;
            }
        }
    }
    
}

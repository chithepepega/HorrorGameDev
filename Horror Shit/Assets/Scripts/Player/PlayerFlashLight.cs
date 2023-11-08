using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerFlashLight : MonoBehaviour
{
    public FlashLightOnOff flashLightOnOff;
    public Animator anim;
    public GameObject flashLight;
    private bool flashlightOn;

    private bool keypad = false;    
    [SerializeField] private TextMeshProUGUI codeText;
    string codeTextValue = "";
    public string safeCode;
    public GameObject codePanel;
    
    // Start is called before the first frame update
    void Awake()
    {
        flashLight.SetActive(false);
        flashlightOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        codeText.text = codeTextValue;
        FlashlightMinigame();
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
         // else if shit 
        else if(flashLightOnOff.glitched == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                keypad = true;
                codePanel.SetActive(true);
            }
            
        }
        else
        {
            if (flashlightOn == false || flashLightOnOff.glitched == true)
            return;
             
             if (Input.GetKeyDown(KeyCode.F))
             {
                StartCoroutine(PlayAnimationAndDeactivate());
             }
        }
        
    }

    void CallerOnPhone()
    {
        anim.Play("Put_TelephoneAway");
    }

    #region Keypad Stuff
    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
    public void FlashlightMinigame()
    {
        if (codeTextValue == safeCode)
        {
            keypad = false; 
            flashLightOnOff.glitched = false;
            flashLightOnOff.cameraLight.intensity = 2f;
            codePanel.SetActive(false);
            codeTextValue = "";
        }

        if (codeTextValue.Length >= 4)
        {
            codeTextValue = "";
        }
    }
    #endregion

}

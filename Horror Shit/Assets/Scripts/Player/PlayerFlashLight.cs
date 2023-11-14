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

    public GameObject phone;
    public Material newScreenMaterial;
    public Material currentScreenMaterial;

    public float timer = 10f;
    public GameObject fearQuestion;
    public GameObject godQuestion;
    public GameObject deathQuestion;

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
        if (anim.GetBool("receiveCall") == true)
        {
            Debug.Log("timer :" + timer);
            timer -= Time.deltaTime;
        }
        
    }
    IEnumerator PlayAnimationAndDeactivate()
    {
        anim.Play("Put_TelephoneAway");
        // Wait for the animation to finish. Here, 1f is the length of the animation in seconds.
        yield return new WaitForSeconds(2f);
        flashLight.SetActive(false);
        flashlightOn = false;
        flashLightOnOff.DisablePhoneEvent();
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
                flashLightOnOff.EnablePhoneEvent();
            }
        }
         // else if shit 
        else if(flashLightOnOff.glitched == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                flashLightOnOff.EnablePhoneEvent();
                keypad = true;
                codePanel.SetActive(true);
            }
            
        }
        else if (flashLightOnOff.caller == true)
        {
            anim.SetBool("receiveCall", true);
            var myRenderer = phone.GetComponent<Renderer>();
            var TempArray = myRenderer.materials;
            TempArray[1] = newScreenMaterial;
            myRenderer.materials = TempArray;
            if (timer <= 0f)
            {
                flashLightOnOff.callingSound.Stop();
                Debug.Log("The timer hit 0");
                godQuestion.SetActive(false);
                deathQuestion.SetActive(false);
                fearQuestion.SetActive(false);
                flashLightOnOff.caller = false;
                StartCoroutine(PlayAnimationAndDeactivate());
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetBool("receiveCall", false);
                anim.SetBool("acceptCall", true);
                Debug.Log("Received");
                anim.Play("Answer_Phone");
                CallerOnPhone();
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
        flashLightOnOff.caller = false;
        int randomQuestion = Random.Range(1, 4);
        flashLightOnOff.callingSound.Stop();
        if (randomQuestion == 1)
        {
            fearQuestion.SetActive(true);
        }
        if (randomQuestion == 2)
        {
            deathQuestion.SetActive(true);
        }
        if (randomQuestion == 3)
        {
            godQuestion.SetActive(true);
        }
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
            flashLightOnOff.EnablePhoneEvent();
        }

        if (codeTextValue.Length >= 4)
        {
            codeTextValue = "";
        }
    }
    #endregion

}

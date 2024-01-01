using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightInputManager : MonoBehaviour
{
   public bool flashLightIsOn = false;

    private void Awake()
    {
        flashLightIsOn = false;
    }
    public void StateSetOn()
   {
        flashLightIsOn = true;
   }

    public void StateSetOff()
    {
        flashLightIsOn = false;
    }
}

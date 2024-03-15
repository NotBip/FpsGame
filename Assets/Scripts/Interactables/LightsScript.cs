using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsScript : MonoBehaviour
{

    [SerializeField] private Light light; 

    private bool isLights = false; 

    private void Update()
     {
        if(isLights)
            light.intensity = 1; 
        else 
            light.intensity = 0; 
     }

    public void lightSwitch()
    {
        Debug.Log("Light Toggled");
        isLights = !isLights; 
    }

}

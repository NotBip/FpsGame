using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{   

    protected override void Interact()
    {   
        promptMessage = "DOOR DETECTED"; 
        Debug.Log("Interacted With: " + gameObject.name); 
    }

}

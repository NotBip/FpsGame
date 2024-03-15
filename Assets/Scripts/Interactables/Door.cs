using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : Interactable
{       

    private bool doorOpen = false; 
    
    protected override void Interact()
    {   
        doorOpen = !doorOpen; 
        this.GetComponent<Animator>().SetBool("isOpen", doorOpen); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : Interactable
{       

    private bool doorOpen; 
    
    private void Start()
    { 

    }
    
    private void Update()
    { 

    }

    protected override void Interact()
    {   
        doorOpen = !doorOpen; 
        this.GetComponent<Animator>().SetBool("isOpen", true); 
    }
}

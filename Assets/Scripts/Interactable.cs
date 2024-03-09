using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    [SerializeField] public string promptMessage; 

    public void BaseInteract()
    { 
        Interact();
    }

    protected virtual void Interact(){}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] private Camera cam; 
    [SerializeField] private float distance = 4f; 
    [SerializeField] private LayerMask layerMask; 
    [SerializeField] private PlayerUI playerUI; 
    [SerializeField] private InputManager inputManager; 


    public void Update()
    {       
        playerUI.updateText(string.Empty); 
        Ray ray = new Ray(cam.transform.position, cam.transform.forward); 
        Debug.DrawRay(ray.origin, ray.direction * distance); 
        RaycastHit hitInfo; 
        if(Physics.Raycast(ray, out hitInfo, distance, layerMask)) { 
            
            if(hitInfo.collider.GetComponent<Interactable>() != null) {     
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>(); 

                playerUI.updateText(interactable.promptMessage); 

                if(inputManager.onFoot.Interact.triggered) {
                    interactable.BaseInteract(); 
                }
            } 
        }   

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem; 
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] private PlayerMovement playerMovement; 
    [SerializeField] private PlayerLook playerLook; 
    [SerializeField] private PlayerMisc playerMisc; 

    private PlayerInput playerInput; 
    public PlayerInput.OnFootActions onFoot;

    private void Awake()
    { 
        playerInput = new PlayerInput(); 
        onFoot = playerInput.OnFoot; 

        onFoot.Jump.performed += ctx => playerMovement.jump(); 
        onFoot.Sprint.performed += ctx => playerMovement.sprint(true);
        onFoot.Sprint.canceled += ctx => playerMovement.sprint(false);  
        onFoot.Crouch.performed += ctx => playerMovement.crouch(true); 
        onFoot.Crouch.canceled += ctx => playerMovement.crouch(false);     
        onFoot.CursorLock.performed += ctx => playerMisc.toggleLock(); 
    }

    private void FixedUpdate()
    { 
        playerMovement.ProcessMove(onFoot.Movement.ReadValue<Vector2>()); 
    }

    private void LateUpdate()
    { 
        playerLook.ProcessLook(onFoot.Look.ReadValue<Vector2>()); 
    }

    private void OnEnable()
    { 
        onFoot.Enable(); 
    }

    private void OnDisable()
    { 
        onFoot.Disable(); 
    }

}

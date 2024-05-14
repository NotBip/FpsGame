using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMisc : MonoBehaviour
{   
    private bool isLocked = false; 

    private void Update()
    { 
        if(isLocked) { 
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false; 
        } else { 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; 
        }

    }

    public void toggleLock()
    { 
        isLocked = !isLocked; 
    }


}

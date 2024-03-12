using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerHealth : MonoBehaviour
{   
    private float health; 
    private float lerpTimer; 

    [SerializeField] private float maxHealth = 100f; 
    [SerializeField] private float chipSpeed = 2f; 
    [SerializeField] private Image frontHealth; 
    [SerializeField] private Image backHealth; 

    private void Start() 
    { 
        health = maxHealth; 
    }

    private void Update() 
    { 
        health = Mathf.Clamp(health, 0, maxHealth); 
        updateHealth(); 
        if(Input.GetKeyDown(KeyCode.K)) 
            takeDamage(Random.Range(5, 10)); 

        if(Input.GetKeyDown(KeyCode.L))
            restoreHealth(Random.Range(5, 10)); 
        
    }

    public void updateHealth() 
    { 
        Debug.Log(health); 
        float fillF = frontHealth.fillAmount; 
        float fillB = backHealth.fillAmount; 
        float hFraction = health / maxHealth; 

        if(fillB > hFraction) { 
            frontHealth.fillAmount = hFraction; 
            lerpTimer += Time.deltaTime;    
            float percentComplete = lerpTimer / chipSpeed; 
            percentComplete *= percentComplete; 
            backHealth.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete); 
        } 

        if(fillF < hFraction) { 
            backHealth.fillAmount = hFraction; 
            lerpTimer += Time.deltaTime; 
            float percentComplete = lerpTimer / chipSpeed; 
            percentComplete *= percentComplete;  
            frontHealth.fillAmount = Mathf.Lerp(fillF, hFraction, percentComplete); 
        }

    }

    public void takeDamage(float damage) 
    { 
        health -= damage; 
        lerpTimer = 0; 
    }

    public void restoreHealth(float healAmount)
     {
        health += healAmount; 
        lerpTimer = 0;
     }


}

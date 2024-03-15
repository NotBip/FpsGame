using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerHealth : MonoBehaviour
{   
    private float health; 
    private float lerpTimer; 
    private float durationTimer; 
    [SerializeField] private float maxHealth = 100f; 
    [SerializeField] private float chipSpeed = 2f; 
    [SerializeField] private Image frontHealth; 
    [SerializeField] private Image backHealth; 

    [SerializeField] private Image DamageOverlay; 
    [SerializeField] private float duration; 
    [SerializeField] private float fadeSpeed; 
    

    private void Start() 
    { 
        health = maxHealth; 
        DamageOverlay.color = new Color(DamageOverlay.color.r, DamageOverlay.color.g, DamageOverlay.color.b, 0); 
    }

    private void Update() 
    { 
        health = Mathf.Clamp(health, 0, maxHealth); 
        updateHealth(); 

        if(DamageOverlay.color.a > 0) { 
            if(health < 25)
                return;
            durationTimer += Time.deltaTime;    
            if(durationTimer > duration) { 
                float tempAlpha = DamageOverlay.color.a; 
                tempAlpha -= Time.deltaTime * fadeSpeed; 
                DamageOverlay.color = new Color(DamageOverlay.color.r, DamageOverlay.color.g, DamageOverlay.color.b, tempAlpha); 
            }
        }
        
    }

    public void updateHealth() 
    {   
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
        durationTimer = 0f; 
        DamageOverlay.color = new Color(DamageOverlay.color.r, DamageOverlay.color.g, DamageOverlay.color.b, 1); 

    }

    public void restoreHealth(float healAmount)
     {
        health += healAmount; 
        lerpTimer = 0;
     }


}

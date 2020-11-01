using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public const int maxHealth = 100;
    public int currentHealth = maxHealth;

    public RectTransform healthBar;

    // Prendre des dégats
    public void TakeDamage(int amount)
    {
        // On baisse la vie actuelle selon le nombre de dégats
        currentHealth -= amount;

        // Si la vie actuelle atteint 0 le personnage meurt
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead !!!!!");
        }

        healthBar.sizeDelta = new Vector2(currentHealth,healthBar.sizeDelta.y);
        
    }    
}

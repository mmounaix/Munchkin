using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{
    public const int maxHealth = 100;

    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;
    public bool destroyOnDeath;

    public RectTransform healthBar;
  
    // Prendre des dégats
    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }
        // On baisse la vie actuelle selon le nombre de dégats
        currentHealth -= amount;

        // Si la vie actuelle atteint 0 le personnage meurt
        if (currentHealth <= 0)
        {
            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
            else
            {
                currentHealth = maxHealth;
                RpcRespawn();
            }
            
        }
        
    }    

    void OnChangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            // on replace le joueur aux positions (0,0,0)
            transform.position = Vector3.zero;
        }
    }
}

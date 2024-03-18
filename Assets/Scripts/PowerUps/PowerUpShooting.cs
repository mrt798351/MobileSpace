using System;
using UnityEngine;

public class PowerUpShooting : MonoBehaviour
{
    private int upgradeAmount = 1;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShooting player = other.GetComponent<PlayerShooting>(); 
            player.IncreaseUpgrade(upgradeAmount); 
            Destroy(gameObject);
        }
    }
}

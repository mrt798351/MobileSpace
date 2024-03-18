using System;
using UnityEngine;

public class PowerUpHeal : MonoBehaviour
{
    [SerializeField] private int healAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStates player = other.GetComponent<PlayerStates>();
            player.AddHealth(healAmount);
            Destroy(gameObject);
        }
    }
}

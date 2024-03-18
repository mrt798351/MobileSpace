using System;
using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    [SerializeField] private AudioClip clipToPlay;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShieldActivator shieldActivator = other.GetComponent<PlayerShieldActivator>();
            shieldActivator.ActivateShield();
            AudioSource.PlayClipAtPoint(clipToPlay, transform.position, 1f);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

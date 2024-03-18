using System;
using UnityEngine;

public class PurpleBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStates>().PlayerTakeDamage(damage);
            Destroy(gameObject);
        }
    }
    

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpecialBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private GameObject miniBullet;
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        rb.velocity = Vector2.down * speed;
    }

    private void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    IEnumerator Explode()
    {
        float randomExplodeTime = Random.Range(1.5f, 2.5f);
        yield return new WaitForSeconds(randomExplodeTime);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(miniBullet, spawnPoints[i].position, spawnPoints[i].rotation);
        }
        Destroy(gameObject);
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

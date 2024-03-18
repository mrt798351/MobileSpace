using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected Rigidbody2D rb;

    [SerializeField] protected float damage = 1f;
    [SerializeField] protected GameObject explosionPrefab;

    [SerializeField] protected Animator anim;
    [Header("Score")]
    [SerializeField] protected int scoreValue;
    public void TakeDamage(float damage)
    {
        health -= damage;
        HurtSequence();
        if (health <= 0)
        {
            DeathSequence();
        }
    }

    public virtual void HurtSequence()
    {
        
    }
    public virtual void DeathSequence()
    {
        EndGameManager.endManager.UpdateScore(scoreValue);
    }
}

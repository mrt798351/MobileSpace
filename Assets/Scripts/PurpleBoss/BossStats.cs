using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossStats : Enemy
{
    [SerializeField] private BossController bossController;

    public override void HurtSequence()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg"))
        {
            return;
        }
        anim.SetTrigger("Damage");
    }

    public override void DeathSequence()
    {
        base.DeathSequence();
        bossController.ChangeState(BossStates.Death);
        Instantiate(explosionPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStates>().PlayerTakeDamage(damage);
        }
    }
}

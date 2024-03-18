using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossFire : BossBaseState
{
    [SerializeField] private float speed;
    [SerializeField] private float shootRate;
    [SerializeField] private GameObject bulletPrefab;

    [Header("Shooting Points")]
    [SerializeField] private Transform[] shootPoints;

    public override void RunState()
    {
        StartCoroutine(RunFireState());
    }

    public override void StopState()
    {
        base.StopState();
    }

    IEnumerator RunFireState()
    {
        float shooTimer = 0f;
        float fireStateTimer = 0f;
        float fireStateExitTime = Random.Range(5f, 10f);
        Vector2 targetPosition = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxDown, maxUp));
        while (fireStateTimer <= fireStateExitTime)
        {
            if (Vector2.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
            else
            {
                targetPosition = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxDown, maxUp));
            }
            shooTimer += Time.deltaTime;
            if (shooTimer >= shootRate)
            {
                for (int i = 0; i < shootPoints.Length; i++)
                {
                    Instantiate(bulletPrefab, shootPoints[i].position, quaternion.identity);
                }
                shooTimer = 0;
            }
            yield return new WaitForEndOfFrame();
            fireStateTimer += Time.deltaTime;
        }
        bossController.ChangeState(BossStates.Special);
        // int randomPick = Random.Range(0, 2);
    //     if (randomPick == 0)
    //     {
    //         bossController.ChangeState(BossStates.Fire);
    //     }
    //     else
    //     {
    //         bossController.ChangeState(BossStates.Special);
    //     }
    }
}

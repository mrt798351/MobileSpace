using System;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private float timer;
    [SerializeField] private float possibleWinTime;
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private bool hasBoss;

    public bool canSpawnBoss = false;
    private void Update()
    {
        if (EndGameManager.endManager.gameObject == true)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer >= possibleWinTime)
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                spawners[i].SetActive(false);
            }
            if (hasBoss == false)
            {
                EndGameManager.endManager.possibleWin = true;
                EndGameManager.endManager.StartResolveSequence();
            }
            else
            {
                canSpawnBoss = true;
            }
            gameObject.SetActive(false);
        }
    }
}

using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "SO/PowerUpsSpawner", fileName = "Spawner")]
public class ExampleSO : ScriptableObject
{
    public int spawnThreshold;
    public GameObject[] powerUps;

    public void SpawnPowerUp(Vector3 spawnPos)
    {
        int randomChance = Random.Range(0, 100);

        if (randomChance > spawnThreshold)
        {
            int randomPowerUp = Random.Range(0, powerUps.Length); 
            Instantiate(powerUps[randomPowerUp], spawnPos, quaternion.identity);
        }
    }
}

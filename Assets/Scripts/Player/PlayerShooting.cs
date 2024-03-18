using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private float shootingInterval;
    
    [Header("Basic Attack")]
    [SerializeField] private Transform shootPoint;

    [Header("Upgrade Points")]
    [SerializeField] private Transform leftCanon;
    [SerializeField] private Transform rightCanon;
    [SerializeField] private Transform secondLeftCanon;
    [SerializeField] private Transform secondRightCanon;
    
    [Header("Upgrade Rotation Points")]
    [SerializeField] private Transform leftRotationCanon;
    [SerializeField] private Transform rightRotationCanon;

    [Header("Sounds")]
    [SerializeField] private AudioSource source;
    
    private int upgradeLevel = 0;
    
    private float intervalReset;

    private void Start()
    {
        intervalReset = shootingInterval;
    }

    private void Update()
    {
        shootingInterval -= Time.deltaTime;
        if (shootingInterval <= 0)
        {
            Shoot();
            shootingInterval = intervalReset;
        }
    }

    public void IncreaseUpgrade(int increaseAmount)
    {
        upgradeLevel += increaseAmount;
        if (upgradeLevel > 4)
        {
            upgradeLevel = 4;
        }
    }

    public void DecreaseUpgrade()
    {
        upgradeLevel -= 1;
        if (upgradeLevel < 0)
        {
            upgradeLevel = 0;
        }
    }

    private void Shoot()
    {
        source.Play();
        switch (upgradeLevel)
        {
            case 0: 
                Instantiate(laserBullet, shootPoint.position, quaternion.identity);
                break;
            case 1:
                Instantiate(laserBullet, leftCanon.position, quaternion.identity);
                Instantiate(laserBullet, rightCanon.position, quaternion.identity);
                break;
            case 2:
                Instantiate(laserBullet, shootPoint.position, quaternion.identity);
                Instantiate(laserBullet, leftCanon.position, quaternion.identity);
                Instantiate(laserBullet, rightCanon.position, quaternion.identity);
                break;
            case 3:
                Instantiate(laserBullet, shootPoint.position, quaternion.identity);
                Instantiate(laserBullet, leftCanon.position, quaternion.identity);
                Instantiate(laserBullet, rightCanon.position, quaternion.identity);
                Instantiate(laserBullet, secondLeftCanon.position, quaternion.identity);
                Instantiate(laserBullet, secondRightCanon.position, quaternion.identity);
                break;
            case 4:
                Instantiate(laserBullet, shootPoint.position, quaternion.identity);
                Instantiate(laserBullet, leftCanon.position, quaternion.identity);
                Instantiate(laserBullet, rightCanon.position, quaternion.identity);
                Instantiate(laserBullet, secondLeftCanon.position, quaternion.identity);
                Instantiate(laserBullet, secondRightCanon.position, quaternion.identity);
                
                Instantiate(laserBullet, leftRotationCanon.position, quaternion.identity);
                Instantiate(laserBullet, rightRotationCanon.position, quaternion.identity);
                break;
            default:
                break;
        }
    }
}

using System;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private int hitsToDestroy = 3;
    public bool protection = false;

    [SerializeField] private GameObject[] shieldsBase;

    private void OnEnable()
    {
        hitsToDestroy = 3;
        for (int i = 0; i < shieldsBase.Length; i++)
        {
            shieldsBase[i].SetActive(true);
        }
        protection = true;
    }

    private void UpdateUI()
    {
        switch (hitsToDestroy)
        {
            case 0:
                for (int i = 0; i < shieldsBase.Length; i++)
                {
                    shieldsBase[i].SetActive(false);
                }
                break;
            case 1:
                shieldsBase[0].SetActive(true);
                shieldsBase[1].SetActive(false);
                shieldsBase[2].SetActive(false);
                break;
            case 2:
                shieldsBase[0].SetActive(true);
                shieldsBase[1].SetActive(true);
                shieldsBase[2].SetActive(false);
                break;
            case 3:
                shieldsBase[0].SetActive(true);
                shieldsBase[1].SetActive(true); 
                shieldsBase[2].SetActive(true);
                break;
            default:
                Debug.Log("Wrong case");
                break;
        }
    }
    private void DamageShield()
    {
        hitsToDestroy -= 1;
        if (hitsToDestroy <= 0)
        {
            hitsToDestroy = 0;
            protection = false;
            gameObject.SetActive(false);
        }
        UpdateUI();
    }

    public void RepairShield()
    {
        hitsToDestroy = 3;
        UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (other.CompareTag("Boss"))
            {
                hitsToDestroy = 0;
                DamageShield();
                return;
            }
            enemy.TakeDamage(10000);
            DamageShield();
        }
        else
        {
            Destroy(other.gameObject);
            DamageShield();
        }
    }
}

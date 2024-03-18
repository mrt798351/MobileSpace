using System;
using UnityEngine;

public enum BossStates
{
    Enter,
    Fire,
    Special,
    Death
}

public class BossController : MonoBehaviour
{
    [SerializeField] private BossEnter bossEnter;
    [SerializeField] private BossFire bossFire;
    [SerializeField] private BossSpecial bossSpecial;
    [SerializeField] private BossDeath bossDeath;
    
    [SerializeField] private bool test;
    [SerializeField] private BossStates testStates;
    private void Start()
    {
        ChangeState(BossStates.Enter);
        if (test)
        {
            ChangeState(testStates);
        }
    }

    public void ChangeState(BossStates states)
    {
        switch (states)
        {
            case BossStates.Enter:
                bossEnter.RunState();
                break;
            case BossStates.Fire:
                bossFire.RunState();
                break;
            case BossStates.Special:
                bossSpecial.RunState();
                break;
            case BossStates.Death:
                bossEnter.StopState();
                bossFire.StopState();
                bossSpecial.StopState();
                bossDeath.RunState();
                break;
        }
    }
}

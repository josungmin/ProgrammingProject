using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAttackState : DragonState
{
    private Dragon dragon;

    public Transform target;
    public Vector3 direction;

    private Animator animator;

    void DragonState.OnEnter(Dragon dragon)
    {
        Debug.Log("Attack State");
        this.dragon = dragon;
        animator = dragon.GetComponent<Animator>();
    }

    void DragonState.Update()
    {
        animator.SetBool("isAttack", true);

        if(dragon.dragonInfo.attackCount >= 3)
        {
            dragon.SetState(new DragonSkill_2State());
        }
        else
        {          
            dragon.SetState(new DragonSkill_1State());
        }
    }

    void DragonState.OnExit()
    {
        animator.SetBool("isAttack", false); 
    }
}

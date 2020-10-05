using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonIdleState : DragonState
{
    private Dragon dragon;
    private Animator animator;

    private Transform target;
    private Vector3 direction;

    void DragonState.OnEnter(Dragon dragon)
    {
        this.dragon = dragon;
        animator = dragon.GetComponent<Animator>();
    }

    void DragonState.Update()
    {
        animator.SetBool("isIdle", true);

        target = GameObject.Find("Player").transform;
        direction = (target.position - dragon.transform.position).normalized;

        float distance = Vector3.Distance(target.position, dragon.transform.position);

        if (dragon.dragonInfo.Attack_Range <= distance && distance <= dragon.dragonInfo.Idle_Range)
        {
            dragon.SetState(new DragonMoveState());
        }
        else if(dragon.dragonInfo.Attack_Range >= distance)
        {
            dragon.SetState(new DragonAttackState());
        }
    }

    void DragonState.OnExit()
    {
        animator.SetBool("isIdle", false);
    }
}

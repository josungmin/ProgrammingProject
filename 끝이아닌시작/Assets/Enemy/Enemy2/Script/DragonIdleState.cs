using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonIdleState : DragonState
{
    private Dragon dragon;
    private Animator animator;

    private Transform target;
    private Vector3 direction;

    private int randNum;

    void DragonState.OnEnter(Dragon dragon)
    {
        this.dragon = dragon;
        animator = dragon.GetComponent<Animator>();

        randNum = Random.Range(0, 3);
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
            if (randNum == 0)
                dragon.SetState(new DragonAttackState());
            else if (randNum == 1)
                dragon.SetState(new DragonSkill_2State());
            else if(randNum == 2)
                dragon.SetState(new DragonSkill_3State());
            else
                dragon.SetState(new DragonSkill_2State());
        }
    }

    void DragonState.OnExit()
    {
        animator.SetBool("isIdle", false);
    }
}

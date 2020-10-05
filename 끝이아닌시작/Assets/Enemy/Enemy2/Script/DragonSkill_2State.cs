using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSkill_2State : DragonState
{
    private Dragon dragon;

    public Transform target;
    public Vector3 direction;

    private Animator animator;

    void DragonState.OnEnter(Dragon dragon)
    {
        this.dragon = dragon;
        animator = dragon.GetComponent<Animator>();

        dragon.dragonInfo.attackCount = 0;
    }

    void DragonState.Update()
    {
        animator.SetBool("isSkill_2", true);

        //dragon.SetState(new DragonIdleState());
    }

    void DragonState.OnExit()
    {
        animator.SetBool("isSkill_2", false); 
    }
}

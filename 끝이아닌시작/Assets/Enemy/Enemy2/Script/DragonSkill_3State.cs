﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSkill_3State : DragonState
{
    private Dragon dragon;

    public Transform target;
    public Vector3 direction;

    private float coolTime;
    private float currentTime;

    private Animator animator;

    void DragonState.OnEnter(Dragon dragon)
    {
        this.dragon = dragon;
        animator = dragon.GetComponent<Animator>();

        coolTime = 1.0f;
        currentTime = 0.0f;

        animator.SetBool("isAttack", true);
        animator.SetBool("isSkill_3", true);
    }

    void DragonState.Update()
    {
        if (coolTime < currentTime)
        {
            dragon.SetState(new DragonIdleState());
        }
        currentTime += Time.deltaTime;
    }

    void DragonState.OnExit()
    {
        animator.SetBool("isSkill_3", false);
        animator.SetBool("isAttack", false);
        dragon.dragonInfo.attackNum = 0;
    }
}

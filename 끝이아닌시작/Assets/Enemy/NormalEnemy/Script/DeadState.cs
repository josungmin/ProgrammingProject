using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    private Enemy enemy;
    private Animator animator;

    private Transform target;

    void State.OnEnter(Enemy enemy)
    {
        Debug.Log("Dead State");
        this.enemy = enemy;
        //animator = enemy.GetComponent<Animator>();
    }

    void State.Update()
    {
        //animator.SetBool("isIdle", true);
    }

    void State.OnExit()
    {
        //animator.SetBool("isIdle", false);
    }
}

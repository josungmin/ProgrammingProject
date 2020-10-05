using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private Enemy enemy;
    private Animator animator;

    private Transform target;
    private Vector3 direction;

    void State.OnEnter(Enemy enemy)
    {
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();
    }

    void State.Update()
    {
        animator.SetBool("isIdle", true);

        target = GameObject.Find("Player").transform;
        direction = (target.position - enemy.transform.position).normalized;

        float distance = Vector3.Distance(target.position, enemy.transform.position);

        if (enemy.enemyInfo.Attack_Range <= distance && distance <= enemy.enemyInfo.Idle_Range)
        {
            enemy.SetState(new MoveState());
        }
        else if(enemy.enemyInfo.Attack_Range >= distance)
        {
            enemy.SetState(new Skill_2State());
        }
    }

    void State.OnExit()
    {
        animator.SetBool("isIdle", false);
    }
}

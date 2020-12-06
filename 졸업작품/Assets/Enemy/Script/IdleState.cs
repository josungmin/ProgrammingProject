using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private Enemy enemy;
    private Animator animator;

    private Transform target;

    void State.OnEnter(Enemy enemy)
    {
        Debug.Log("Idle State");
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();
    }

    void State.Update()
    {
        animator.SetBool("isIdle", true);
        target = GameObject.Find("Player").transform;

        float distance = Vector3.Distance(target.position, enemy.transform.position);

        if(enemy.enemyInfo.isAlive)
        {
            // 이동 상태로 전환 
            if (enemy.enemyInfo.isDamaged)
            {
                enemy.SetState(new MoveState());
            }
        }
        else
        {
            enemy.SetState(new DeadState());
        }
    }

    void State.OnExit()
    {
        animator.SetBool("isIdle", false);
    }
}

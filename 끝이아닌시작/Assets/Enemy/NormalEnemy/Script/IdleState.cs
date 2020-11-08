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
            /*
            if (enemy.enemyInfo._isDamaged)
            {
                enemy.SetState(new DamagedState());
            }
            */
            // 이동 상태로 전환 
            if (enemy.enemyInfo.attackRange <= distance && distance <= enemy.enemyInfo.idleRange)
            {
                enemy.SetState(new MoveState());
            }
            // 공격 상태로 전환
            else if (enemy.enemyInfo.attackRange >= distance)
            {
                enemy.SetState(new AttackState());
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

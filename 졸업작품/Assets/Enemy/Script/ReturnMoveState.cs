using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReturnMoveState : State
{
    private Enemy enemy;
    private Animator animator;
    private NavMeshAgent agent;

    void State.OnEnter(Enemy enemy)
    {
        Debug.Log("ReturnMove State");
        this.enemy = enemy;

        animator = enemy.GetComponent<Animator>();
        agent = enemy.GetComponent<NavMeshAgent>();
    }

    void State.Update()
    {
        animator.SetBool("isWalk", true);

        // 살아 있는 경우에만 실행
        if (enemy.enemyInfo.isAlive)
        {
            // 이동
            agent.SetDestination(enemy.enemyInfo.initPos.localPosition);

            if (enemy.transform == enemy.enemyInfo.initPos)
            {
                enemy.SetState(new IdleState());
            }
        }
        // 죽은경우 실행
        else
        {
            enemy.SetState(new DeadState());
        }
    }

    void State.OnExit()
    {
        animator.SetBool("isWalk", false);
    }
}

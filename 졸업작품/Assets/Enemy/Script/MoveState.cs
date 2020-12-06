using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : State
{
    private Enemy enemy;
    private Animator animator;
    private NavMeshAgent agent;

    private Transform target;

    void State.OnEnter(Enemy enemy)
    {
        Debug.Log("Move State");
        this.enemy = enemy;

        animator = enemy.GetComponent<Animator>();
        agent = enemy.GetComponent<NavMeshAgent>();

        enemy.enemyInfo.isDamaged = false;
    }

    void State.Update()
    {
        animator.SetBool("isWalk", true);
        target = GameObject.Find("Player").transform;

        float distance = Vector3.Distance(target.position, enemy.transform.position);

        // 살아 있는 경우에만 실행
        if (enemy.enemyInfo.isAlive)
        {
            // 이동
            agent.SetDestination(target.localPosition);

            if (enemy.enemyInfo.idleRange <= distance)
            {
                enemy.SetState(new ReturnMoveState());
            }
            else if (enemy.enemyInfo.attackRange >= distance)
            {
                enemy.SetState(new AttackState());
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

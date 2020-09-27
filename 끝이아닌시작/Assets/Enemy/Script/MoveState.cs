using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : State
{
    private Enemy enemy;
    private Animator animator;
    private EnemyInfo enemyinfo;
    private NavMeshAgent agent;

    public Transform target;
    public Vector3 direction;

    private float distance;

    void State.OnEnter(Enemy enemy)
    {
        Debug.Log("Move State");
        this.enemy = enemy;

        animator = enemy.GetComponent<Animator>();
        enemyinfo = enemy.GetComponent<EnemyInfo>();
        agent = enemy.GetComponent<NavMeshAgent>();
    }

    void State.Update()
    {
        animator.SetBool("isWalk", true);
        target = GameObject.Find("Player").transform;
        direction = (target.position - enemy.transform.position).normalized;

        float distance = Vector3.Distance(target.position, enemy.transform.position);

        agent.SetDestination(target.localPosition);

        if (enemy.enemyInfo.Idle_Range <= distance)
        {
            enemy.SetState(new IdleState());
        }
        else if (enemy.enemyInfo.Attack_Range >= distance)
        {
            int randNum = Random.Range(0, 2);

            if(randNum == 0)
                enemy.SetState(new Skill_1State());
            else if(randNum == 1)
                enemy.SetState(new Skill_2State());
        }
    }

    void State.OnExit()
    {
        animator.SetBool("isWalk", false);
    }
}

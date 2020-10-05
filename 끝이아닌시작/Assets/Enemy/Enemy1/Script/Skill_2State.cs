using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_2State : State
{
    private Enemy enemy;

    public Transform target;
    public Vector3 direction;

    private Animator animator;
    private EnemyInfo enemyinfo;

    void State.OnEnter(Enemy enemy)
    {
        Debug.Log("Attack State");
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();
        enemyinfo = enemy.GetComponent<EnemyInfo>();

        animator.SetBool("isAttack", true);
    }

    void State.Update()
    {
        animator.SetBool("isSkill_2", true);
        target = GameObject.Find("Player").transform;
        direction = (target.position - enemy.transform.position).normalized;

        float distance = Vector3.Distance(target.position, enemy.transform.position);

        if (enemy.enemyInfo.Attack_Range <= distance && distance <= enemy.enemyInfo.Idle_Range)
        {
            enemy.SetState(new MoveState());
        }
        else if (enemy.enemyInfo.Idle_Range <= distance)
        {
            enemy.SetState(new IdleState());
        }
    }

    void State.OnExit()
    {
        animator.SetBool("isAttack", false);
        animator.SetBool("isSkill_2", false);    
    }  
}

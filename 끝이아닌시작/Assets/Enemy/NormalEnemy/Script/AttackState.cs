using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private Enemy enemy;
    private Animator animator;

    private Transform target;
    private bool isAttack = false;

    void State.OnEnter(Enemy enemy)
    {
        Debug.Log("Attack State");
        this.enemy = enemy;

        isAttack = true;
        enemy.StartCoroutine(Attack());
        animator = enemy.GetComponent<Animator>();
    }

    void State.Update()
    {
        animator.SetBool("isAttack", true);
        target = GameObject.Find("Player").transform;

        float distance = Vector3.Distance(target.position, enemy.transform.position);

        if (enemy.enemyInfo.isAlive)
        {
            /*
            if (enemy.enemyInfo._isDamaged)
            {
                enemy.SetState(new DamagedState());
            }
            */
            if (!isAttack)
            {
                if (enemy.enemyInfo.attackRange <= distance && distance <= enemy.enemyInfo.idleRange)
                {
                    enemy.SetState(new MoveState());
                }
                else if (enemy.enemyInfo.idleRange <= distance)
                {
                    enemy.SetState(new IdleState());
                }
            }
        }
        else
        {
            enemy.SetState(new DeadState());
        }
    }

    void State.OnExit()
    {
        animator.SetBool("isAttack", false);
        enemy.StopCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        // 공격 애니메이션 시간 대기
        yield return new WaitForSeconds(1.0f);  // 공격 애니메이션 길이보다 조금 짧게 지정
        isAttack = false;
    }
}

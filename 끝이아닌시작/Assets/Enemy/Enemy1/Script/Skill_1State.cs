using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1State : State
{
    private Enemy enemy;

    public Transform target;
    public Vector3 direction;

    private Animator animator;
    private EnemyInfo enemyinfo;

    private Coroutine attackRoutine;

    void State.OnEnter(Enemy enemy)
    {
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();
        enemyinfo = enemy.GetComponent<EnemyInfo>();

        animator.SetBool("isAttack", true);
    }

    void State.Update()
    {
        animator.SetBool("isSkill_1", true);
        target = GameObject.Find("Player").transform;
        direction = (target.position - enemy.transform.position).normalized;

        float distance = Vector3.Distance(target.position, enemy.transform.position);

        if(attackRoutine == null)
        {
            attackRoutine = enemy.StartCoroutine(Attack());
        }

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
        animator.SetBool("isSkill_1", false);
    }

    private IEnumerator Attack()
    {
        GameObject skill = enemy.enemyInfo.skillPrefab;
        EnemySkill_1 s = Enemy.Instantiate(skill, enemy.enemyInfo.firePos.transform.position, enemy.enemyInfo.firePos.transform.rotation).GetComponent<EnemySkill_1>();

        yield return new WaitForSeconds(2.18f); // 애니메이션 재생 시간

        StopAttack();
    }

    private void StopAttack()
    {
        if (attackRoutine != null)
        {
            Debug.Log("StopAttack()");

            enemy.StopCoroutine(attackRoutine);
            attackRoutine = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAttackState : DragonState
{
    private Dragon dragon;

    public Transform target;
    public Vector3 direction;

    private float coolTime;
    private float currentTime;

    private Animator animator;

    void DragonState.OnEnter(Dragon dragon)
    {
        Debug.Log("Attack State");
        this.dragon = dragon;
        animator = dragon.GetComponent<Animator>();

        coolTime = 6.367f;
        currentTime = 0.0f;

        animator.SetBool("isAttack", true);
        animator.SetBool("isSkill_1", true);
    }

    void DragonState.Update()
    {
        target = GameObject.Find("Player").transform;
        direction = (target.position - dragon.transform.position).normalized;

        float distance = Vector3.Distance(target.position, dragon.transform.position);

        if (coolTime < currentTime)
        {
            dragon.SetState(new DragonIdleState());
        }
        currentTime += Time.deltaTime;
    }

    void DragonState.OnExit()
    {
        animator.SetBool("isAttack", false);
        animator.SetBool("isSkill_1", false);
    }
}

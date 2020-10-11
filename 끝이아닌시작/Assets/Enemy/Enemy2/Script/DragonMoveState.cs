using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonMoveState : DragonState
{
    private Dragon dragon;
    private Animator animator;
    private NavMeshAgent agent;

    public Transform target;
    public Vector3 direction;

    private float distance;

    private int randNum;

    void DragonState.OnEnter(Dragon dragon)
    {
        Debug.Log("Move State");
        this.dragon = dragon;

        animator = dragon.GetComponent<Animator>();
        agent = dragon.GetComponent<NavMeshAgent>();

        randNum = Random.Range(0, 2);
        dragon.dragonInfo.attackNum++;
    }

    void DragonState.Update()
    {
        animator.SetBool("isWalk", true);
        target = GameObject.Find("Player").transform;
        direction = (target.position - dragon.transform.position).normalized;

        float distance = Vector3.Distance(target.position, dragon.transform.position);

        agent.SetDestination(target.localPosition);

        if (dragon.dragonInfo.Idle_Range <= distance)
        {
            dragon.SetState(new DragonIdleState());
        }
        else if (dragon.dragonInfo.Attack_Range >= distance)
        {
            if (dragon.dragonInfo.attackNum == 0)
                dragon.SetState(new DragonAttackState());
            else if (dragon.dragonInfo.attackNum == 1)
                dragon.SetState(new DragonSkill_2State());
            else if (dragon.dragonInfo.attackNum == 2)
                dragon.SetState(new DragonSkill_3State());
            else
                dragon.SetState(new DragonSkill_2State());
        }
    }

    void DragonState.OnExit()
    {
        animator.SetBool("isWalk", false);
    }
}

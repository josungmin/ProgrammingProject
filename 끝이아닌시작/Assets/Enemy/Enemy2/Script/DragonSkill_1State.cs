using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSkill_1State : DragonState
{
    private Dragon dragon;

    public Transform target;
    public Vector3 direction;

    private Animator animator;

    private float coolTime = 1.0f;
    private float currentTime = 0.0f;

    void DragonState.OnEnter(Dragon dragon)
    {
        this.dragon = dragon;
        animator = dragon.GetComponent<Animator>();

        dragon.dragonInfo.attackCount++;
    }

    void DragonState.Update()
    {
        animator.SetBool("isSkill_1", true);

        while (currentTime < coolTime)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                dragon.SetState(new DragonIdleState());
                break;
            }
            currentTime += Time.deltaTime;
        }
        
    }

    void DragonState.OnExit()
    {
        animator.SetBool("isSkill_1", false); 
    }
}

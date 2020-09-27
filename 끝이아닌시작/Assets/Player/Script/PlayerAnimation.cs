using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        // 이동
        if (!playerInput.IsMoving)
            animator.SetBool("isRunning", false);

        else
            animator.SetBool("isRunning", true);

        // 공격
        if (!playerInput.isAttack)
            animator.SetBool("isAttack", false);

        else
            animator.SetBool("isAttack", true);

        // 스킬 공격
        if (!playerInput.isSkillAttack)
            animator.SetBool("isSkillAttack", false);

        else
            animator.SetBool("isSkillAttack", true);

        // 1번("Q") 스킬
        if (!playerInput.isSkill_1)
            animator.SetBool("isSkill_1", false);

        else
            animator.SetBool("isSkill_1", true);

        // 2번("W") 스킬
        if (!playerInput.isSkill_2)
            animator.SetBool("isSkill_2", false);

        else
            animator.SetBool("isSkill_2", true);
    }
}

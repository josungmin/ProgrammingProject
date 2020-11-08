using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GauntletsPlayerSkill : MonoBehaviour
{
    private Animator animator;
    private GauntletsPlayerInput playerInput;
    private Coroutine skillRoutine;

    [SerializeField]
    private float[] skillCoolTime;

    [SerializeField]
    private GameObject[] skillPrefab;
    [SerializeField]
    private GameObject[] skillPos;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<GauntletsPlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.isSkillAttack && (skillRoutine == null))
        {
            if (playerInput.isSkill_Q)
            {
                skillRoutine = StartCoroutine(CastSkill_Q());
            }
            else if (playerInput.isSkill_W)
            {
                skillRoutine = StartCoroutine(CastSkill_W());
            }
            else if (playerInput.isSkill_E)
            {
                skillRoutine = StartCoroutine(CastSkill_E());
            }
            else if (playerInput.isSkill_R)
            {
                skillRoutine = StartCoroutine(CastSkill_R());
            }
        }
    }

    /*******************************************************************************************************************/

    private IEnumerator CastSkill_Q()
    {
        animator.SetBool("isSkillQ", true);
        yield return new WaitForSeconds(skillCoolTime[0]);
        StopSkill_Q();
    }

    private void StopSkill_Q()
    {
        if (skillRoutine != null)
        {
            StopCoroutine(skillRoutine);
            playerInput.isSkill_Q = false;
            playerInput.isSkillAttack = false;
            animator.SetBool("isSkillQ", false);
            skillRoutine = null;
        }
    }

    /*******************************************************************************************************************/

    private IEnumerator CastSkill_W()
    {
        animator.SetBool("isSkillW", true);
        yield return new WaitForSeconds(skillCoolTime[1]);
        StopSkill_W();
    }

    private void StopSkill_W()
    {
        if (skillRoutine != null)
        {
            StopCoroutine(skillRoutine);
            playerInput.isSkill_W = false;
            playerInput.isSkillAttack = false;
            animator.SetBool("isSkillW", false);
            skillRoutine = null;
        }
    }

    /*******************************************************************************************************************/

    private IEnumerator CastSkill_E()
    {
        animator.SetBool("isSkillE", true);
        yield return new WaitForSeconds(skillCoolTime[2]);      
        StopSkill_E();
    }

    private void StopSkill_E()
    {
        if (skillRoutine != null)
        {
            StopCoroutine(skillRoutine);
            playerInput.isSkill_E = false;
            playerInput.isSkillAttack = false;
            animator.SetBool("isSkillE", false);
            skillRoutine = null;
        }
    }

    /*******************************************************************************************************************/

    private IEnumerator CastSkill_R()
    {
        animator.SetBool("isSkillR", true);
        yield return new WaitForSeconds(skillCoolTime[3]);
        StopSkill_R();
    }

    private void StopSkill_R()
    {
        if (skillRoutine != null)
        {
            StopCoroutine(skillRoutine);
            playerInput.isSkill_R = false;
            playerInput.isSkillAttack = false;
            animator.SetBool("isSkillR", false);
            skillRoutine = null;
        }
    }

    /*******************************************************************************************************************/
}

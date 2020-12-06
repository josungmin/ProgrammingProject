using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private Animator animator;
    private PlayerInput playerInput;
    private Coroutine skillRoutine;

    [SerializeField]
    private GameObject skillPrefab_E;

    [SerializeField]
    private GameObject skillPrefab_R;


    [SerializeField]
    private GameObject[] skillPos;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
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
            else if (playerInput.isSkill_T)
            {
                //skillRoutine = StartCoroutine(CastSkill_T());
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
        yield return new WaitForSeconds(1.8f);
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

        /*
    private IEnumerator CastSkill_T()
    {
        animator.SetBool("isSkillT", true);
        yield return new WaitForSeconds(1.5f);
        Instantiate(skillPrefab[1], this.transform);

        yield return new WaitForSeconds(skillCoolTime[1] - 1.5f);
        StopSkill_T();
    }

    private void StopSkill_T()
    {
        if (skillRoutine != null)
        {
            StopCoroutine(skillRoutine);
            playerInput.isSkill_T = false;
            playerInput.isSkillAttack = false;
            animator.SetBool("isSkillT", false);
            skillRoutine = null;
        }
    }
    */
    /*******************************************************************************************************************/

    private IEnumerator CastSkill_E()
    {
        animator.SetBool("isSkillE", true);
        yield return new WaitForSeconds(1.7f);

        Instantiate(skillPrefab_E, this.transform);

        yield return new WaitForSeconds(2.1f);      
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
        Instantiate(skillPrefab_R, this.transform);
        yield return new WaitForSeconds(2.3f);
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

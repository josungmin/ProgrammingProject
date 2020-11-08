using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private PlayerInput playerInput;
    private Coroutine skillRoutine;

    [SerializeField]
    private GameObject[] skillPrefab;
    [SerializeField]
    private GameObject[] skillPos;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if(skillRoutine == null)
        {
            if(playerInput.isSkill_1)
            {
                skillRoutine = StartCoroutine(CastSkill_1());
            }
            else if(playerInput.isSkill_2)
            {
                skillRoutine = StartCoroutine(CastSkill_2());
            }
        }
    }

    /*******************************************************************************************************************/

    private IEnumerator CastSkill_1()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject skill = skillPrefab[0];
        Skill_1 s = Instantiate(skill, skillPos[0].transform.position, skill.transform.rotation).GetComponent<Skill_1>();

        yield return new WaitForSeconds(1.333f); 

        StopSkill_1();
    }

    private void StopSkill_1()
    {
        if (skillRoutine != null)
        {
            StopCoroutine(skillRoutine);
            playerInput.isSkill_1 = false;
            playerInput.isSkillAttack = false;
            skillRoutine = null;
        }
    }

    /*******************************************************************************************************************/

    private IEnumerator CastSkill_2()
    {
        yield return new WaitForSeconds(1.2f);

        GameObject skill = skillPrefab[1];
        Skill_2 s = Instantiate(skill, skillPos[1].transform.position, skill.transform.rotation).GetComponent<Skill_2>();

        yield return new WaitForSeconds(0.8f);

        GameObject skill2 = skillPrefab[2];
        Skill_2 s2 = Instantiate(skill2, skillPos[2].transform.position, skill2.transform.rotation).GetComponent<Skill_2>();

        yield return new WaitForSeconds(0.9f);

        StopSkill_2();
    }

    private void StopSkill_2()
    {
        if (skillRoutine != null)
        {
            StopCoroutine(skillRoutine);
            playerInput.isSkill_2 = false;
            playerInput.isSkillAttack = false;
            skillRoutine = null;
            //animator.SetBool("isCastSpell_1", false);
        }
    }

    /*******************************************************************************************************************/
}

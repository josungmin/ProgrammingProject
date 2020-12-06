using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    Dictionary<KeyCode, Action> keyDictionary;

    // 이동
    private float horizontal = 0.0f;
    private float vertical = 0.0f;
    private float rotation = 0.0f;
  
    public float MyHorizontal { get { return horizontal; } }
    public float MyVertical { get { return vertical; } }
    public float MyRotation { get { return rotation; } }

    public bool IsMoving { get { return (vertical != 0 || horizontal != 0) ? true : false; } }

    // 대쉬
    public bool isDash { get; set; }

    // 공격
    public bool isAttack { get; set; }
    public bool isAttackCool { get; set; }

    // 스킬
    public bool isSkillAttack { get; set; }
    public bool isSkill_Q { get; set; }
    public bool isSkill_E { get; set; }
    public bool isSkill_R { get; set; }
    public bool isSkill_T { get; set; }

    // Start is called before the first frame update
    void Start()
    {      
        keyDictionary = new Dictionary<KeyCode, Action>
        {
            { KeyCode.Q, Skill_Q },
            { KeyCode.E, Skill_E },
            { KeyCode.R, Skill_R },
            { KeyCode.T, Skill_T }
        };     
    }

    // Update is called once per frame
    void Update()
    {
        inputMovement();
        inputAttack();
        inputSkill();
    }

    private void inputMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Mouse X");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDash = true;
        }
    }

    private void inputAttack()
    {
        if (Input.GetMouseButtonDown(0) && !isAttack && !isAttackCool && !isSkillAttack)
        {
            isAttack = true;
            isAttackCool = true;
        }
    }

    private void inputSkill()
    {      
        if (Input.anyKeyDown)
        {
            foreach (var dic in keyDictionary)
            {
                if (Input.GetKeyDown(dic.Key) && !isSkillAttack && !isAttack)
                {
                    isSkillAttack = true;
                    dic.Value();
                }
            }
        }
    }

    private void Skill_Q()
    {
        isSkill_Q = true;
    }

    private void Skill_T()
    {
        isSkill_T = true;
    }

    private void Skill_E()
    {
        isSkill_E = true;
    }

    private void Skill_R()
    {
        isSkill_R = true;
    }
}

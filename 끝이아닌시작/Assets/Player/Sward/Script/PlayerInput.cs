using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    Dictionary<KeyCode, Action> keyDictionary;

    public Vector3 movePoint { get; private set; }
    public bool IsMoving { get; set; }
    public bool isDash { get; set; }
    public bool isAttack { get; set; }

    public bool isSkillAttack { get; set; }
    public bool isSkill_1 { get; set; }
    public bool isSkill_2 { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        keyDictionary = new Dictionary<KeyCode, Action>
        {
            { KeyCode.Q, Skill_1 },
            { KeyCode.W, Skill_2 }
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
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                movePoint = hit.point;
                IsMoving = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isDash = true;
        }
    }

    private void inputAttack()
    {
        if (Input.GetMouseButtonDown(0) && !isAttack)
        {
            isAttack = true;
        }
    }

    private void inputSkill()
    {
        if (Input.anyKeyDown)
        {
            foreach (var dic in keyDictionary)
            {
                if (Input.GetKeyDown(dic.Key))
                {
                    isSkillAttack = true;
                    dic.Value();
                }
            }
        }
    }

    private void Skill_1()
    {
        isSkill_1 = true;
    }

    private void Skill_2()
    {
        isSkill_2 = true;
    }
}

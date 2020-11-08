using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GauntletsPlayerInput : MonoBehaviour
{
    Dictionary<KeyCode, Action> keyDictionary;
    private GameObject enemy;
    public GameObject _enemy { get { return enemy; } }

    public Vector3 movePoint { get; private set; }
    public bool IsMoving { get; set; }
    public bool isDash { get; set; }
    public bool isAttack { get; set; }
    public bool isAttackCool { get; set; }

    public bool isSkillAttack { get; set; }
    public bool isSkill_Q { get; set; }
    public bool isSkill_W { get; set; }
    public bool isSkill_E { get; set; }
    public bool isSkill_R { get; set; }

    // Start is called before the first frame update
    void Start()
    {      
        keyDictionary = new Dictionary<KeyCode, Action>
        {
            { KeyCode.Q, Skill_Q },
            { KeyCode.W, Skill_W },
            { KeyCode.E, Skill_E },
            { KeyCode.R, Skill_R }
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

            if (Physics.Raycast(ray, out hit) && !isAttack)
            {
                movePoint = hit.point;
                IsMoving = true;
            }
        }
    }

    private void inputAttack()
    {
        if (Input.GetMouseButtonDown(0) && !isAttack && !isAttackCool)
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
                if (Input.GetKeyDown(dic.Key) && !isSkillAttack)
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

    private void Skill_W()
    {
        isSkill_W = true;
    }

    private void Skill_E()
    {
        isSkill_E = true;
    }

    private void Skill_R()
    {
        isSkill_R = true;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("적 충돌");
            enemy = col.gameObject;
        }
        else
        {
            enemy = null;
        }
    }
}

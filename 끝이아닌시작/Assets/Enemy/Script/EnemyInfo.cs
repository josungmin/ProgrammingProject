using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfo : MonoBehaviour
{
    private float MAX_HP;         // HP 최대치.
    public float c_HP;           // 현재 HP.
    public float p_HP;

    public float Attack_Range = 4.0f; // 공격상태 범위
    public float Idle_Range = 20.0f;  // 기본상태 범위
    public bool isAttack = false;
    public GameObject firePos;

    public float velocity = 0.3f;     // 이동 속도

    public void Awake()
    {
        c_HP = MAX_HP;
        p_HP = c_HP;
    }

    public void Update()
    {

    }

    public void isAttackFalse()
    {
        isAttack = false;
    }
}

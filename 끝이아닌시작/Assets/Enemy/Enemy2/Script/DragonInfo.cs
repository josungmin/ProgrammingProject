using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonInfo : MonoBehaviour
{
    [SerializeField]
    public SliderBar Hp;
    [SerializeField]
    private float initHp;

    public float Attack_Range = 4.0f; // 공격상태 범위
    public float Idle_Range = 20.0f;  // 기본상태 범위

    public GameObject[] firePos;
    public GameObject[] skillPrefab;

    public int attackNum = 0;

    public void Start()
    {
        Hp.Init(initHp, initHp);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Hp.currentValue -= 10;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Hp.currentValue += 10;
        }
    }

    void OnDrawGizmos()
    {
        // 기모 색 설정
        Gizmos.color = Color.red;

        // attackRange 기즈모
        Gizmos.DrawWireSphere(this.transform.position, Attack_Range);

        // 기모 색 설정
        Gizmos.color = Color.white;

        // idleRange 기즈모
        Gizmos.DrawWireSphere(this.transform.position, Idle_Range);
    }
}

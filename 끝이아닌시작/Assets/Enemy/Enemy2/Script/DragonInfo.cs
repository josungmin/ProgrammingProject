using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonInfo : MonoBehaviour
{
    public float Attack_Range = 4.0f; // 공격상태 범위
    public float Idle_Range = 20.0f;  // 기본상태 범위

    public int attackCount = 0;

    public GameObject firePos;
    public GameObject skillPrefab;

    public float velocity = 0.3f;     // 이동 속도

    public void Awake()
    {

    }

    public void Update()
    {

    }
}

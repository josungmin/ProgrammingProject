using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // 이동
    [SerializeField]
    private float moveSpeed;
    public float MyMoveSpeed { get { return moveSpeed; } }

    // 회전
    [SerializeField]
    private float rotateSpeed;
    public float MyRotateSpeed { get { return rotateSpeed; } }

    // 데쉬
    [SerializeField]
    private float dashSpeed;
    [SerializeField]
    private float dashTime;

    public float MyDashSpeed { get { return dashSpeed; } }
    public float MyDashTime { get { return dashTime; } }
}

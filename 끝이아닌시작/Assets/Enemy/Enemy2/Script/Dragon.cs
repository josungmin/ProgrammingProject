﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public DragonInfo dragonInfo;

    private DragonState currentState;

    void Awake()
    {
        SetState(new DragonIdleState());
    }

    void Update()
    {
        currentState.Update();
    }

    public void SetState(DragonState nextState)
    {
        // 다음 state로 이동구현
        if (currentState != null)
        {
            // 기존의 상태가 존재했다면 OnExit()호출
            currentState.OnExit();
        }

        // 다음state 시작
        currentState = nextState;
        currentState.OnEnter(this);
    }

    public DragonState GetState()
    {
        Debug.Log(currentState);
        return this.currentState;
    }

    public void Skiil_1_Start()
    {
        Instantiate(dragonInfo.skillPrefab[0], new Vector3(dragonInfo.firePos[0].transform.position.x, 0, dragonInfo.firePos[0].transform.position.z), dragonInfo.firePos[0].transform.rotation);
    }

    public void Skiil_1_End()
    {
        Instantiate(dragonInfo.skillPrefab[1], new Vector3(dragonInfo.firePos[0].transform.position.x, 0, dragonInfo.firePos[0].transform.position.z), dragonInfo.firePos[0].transform.rotation);
    }

    public void Skiil_3()
    {
        Instantiate(dragonInfo.skillPrefab[2], dragonInfo.firePos[1].transform.position, dragonInfo.firePos[1].transform.rotation);
    }
}
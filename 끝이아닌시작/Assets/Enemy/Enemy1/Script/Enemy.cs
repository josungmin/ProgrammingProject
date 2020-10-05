using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyInfo enemyInfo;

    private State currentState;

    void Awake()
    {
        SetState(new IdleState());
    }

    void Update()
    {
        currentState.Update();
    }

    public void SetState(State nextState)
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

    public State GetState()
    {
        Debug.Log(currentState);
        return this.currentState;
    }
}
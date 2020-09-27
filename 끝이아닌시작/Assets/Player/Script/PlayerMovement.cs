using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private NavMeshAgent agent;
    
    // 이동
    [SerializeField]
    private float moveSpeed;
    private float defaultSpeed;

    // 데쉬
    [SerializeField]
    private float dashSpeed;
    [SerializeField]
    private float dashTime;
    private float currentDashTime;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        agent = GetComponent<NavMeshAgent>();

        defaultSpeed = moveSpeed;
        agent.speed = defaultSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!playerInput.isDash)
            Move();

        Desh();
    }

    private void Move()
    {
        if (agent.velocity.magnitude == 0.0f)
        {
            playerInput.IsMoving = false;
        }

        agent.SetDestination(playerInput.movePoint);
    }

    private void Desh()
    {
        if (currentDashTime <= 0)
        {
            defaultSpeed = moveSpeed;
            agent.speed = defaultSpeed;

            if (playerInput.isDash)
            {
                //animator.SetTrigger("isDash");
                currentDashTime = dashTime;
            }
        }
        else
        {
            currentDashTime -= Time.deltaTime;
            agent.speed = dashSpeed;
        }
        playerInput.isDash = false;
    }
}

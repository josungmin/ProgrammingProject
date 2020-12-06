using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInfo playerInfo;

    private float defaultSpeed;
    private float currentDashTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInfo = GetComponent<PlayerInfo>();

        defaultSpeed = playerInfo.MyMoveSpeed;
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
        Vector3 moveDir = (Vector3.forward * playerInput.MyVertical) + (Vector3.right * playerInput.MyHorizontal);

        this.transform.Translate(moveDir.normalized * defaultSpeed * Time.deltaTime, Space.Self);

        this.transform.Rotate(Vector3.up * playerInfo.MyRotateSpeed * Time.deltaTime * playerInput.MyRotation);
    }

    private void Desh()
    {
        if (currentDashTime <= 0)
        {
            defaultSpeed = playerInfo.MyMoveSpeed;

            if (playerInput.isDash)
            {
                //animator.SetTrigger("isDash");
                currentDashTime = playerInfo.MyDashTime;
            }
        }
        else
        {
            currentDashTime -= Time.deltaTime;
            defaultSpeed = playerInfo.MyDashSpeed;
        }
        playerInput.isDash = false;
    }
}

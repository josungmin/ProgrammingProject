using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerInput playerInput;
    private Coroutine attackRoutine;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.isAttack && attackRoutine == null) 
            attackRoutine = StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        //animator.SetBool("isAttack", playerInput.isAttack);

        yield return new WaitForSeconds(1.667f); // 애니메이션 재생 시간

        StopAttack();
    }

    private void StopAttack()
    {
        if (attackRoutine != null)
        {
            Debug.Log("StopAttack()");

            StopCoroutine(attackRoutine);
            playerInput.isAttack = false;
            attackRoutine = null;
            //animator.SetBool("isAttack", playerInput.isAttack);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private PlayerInput playerInput;

    [SerializeField]
    private float attack1_coolTime;
    [SerializeField]
    private float attack2_coolTime;
    [SerializeField]
    private float attack3_coolTime;

    private bool isAttack1 = false;
    private bool isAttack2 = false;
    private bool isAttack3 = false;

    private bool isAttack1Done = false;
    private bool isAttack2Done = false;

    private Coroutine attackRoutine;
    private bool nextAttack = false;

    private Collision firstCol;
    private int colliderCount;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.isAttack && (attackRoutine == null) && !isAttack1 && !isAttack2 && !isAttack3)
        {
            attackRoutine = StartCoroutine(Attack1());
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    private IEnumerator Attack1()
    {
        float coolTime = attack1_coolTime;
        float currentTime = 0;

        nextAttack = false;
        isAttack1Done = false;

        isAttack1 = true;
        animator.SetBool("isAttack1", isAttack1);

        yield return null;

        while (true)
        {
            if (currentTime < coolTime)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    nextAttack = true;
                }
            }
            else
            {
                if (isAttack1Done)
                {
                    StopAttack1();
                    break;
                }
            }
            MoveFront();
            currentTime += Time.deltaTime;
            yield return null;
        }
    }

    private void StopAttack1()
    {
        if (!nextAttack)
        {
            isAttack1 = false;
            animator.SetBool("isAttack1", isAttack1);

            playerInput.isAttack = false;

            StopCoroutine(attackRoutine);
            attackRoutine = null;
        }
        else
        {
            isAttack1 = false;
            animator.SetBool("isAttack1", isAttack1);

            attackRoutine = StartCoroutine(Attack2());
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////

    // 연속 공격 
    private IEnumerator Attack2()
    {
        float coolTime = attack2_coolTime;
        float currentTime = 0;

        nextAttack = false;
        isAttack2Done = false;

        isAttack2 = true;
        animator.SetBool("isAttack2", isAttack2);

        yield return null;

        while (true)
        {
            if (currentTime < coolTime)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    nextAttack = true;
                }
            }
            else
            {
                if (isAttack2Done)
                {
                    StopAttack2();
                    break; ;
                }
            }

            MoveFront();
            currentTime += Time.deltaTime;
            yield return null;
        }
    }

    private void StopAttack2()
    {
        if (!nextAttack)
        {
            isAttack1 = false;
            animator.SetBool("isAttack1", isAttack1);

            isAttack2 = false;
            animator.SetBool("isAttack2", isAttack2);

            playerInput.isAttack = false;

            StopCoroutine(attackRoutine);
            attackRoutine = null;
        }
        else
        {
            isAttack1 = false;
            animator.SetBool("isAttack1", isAttack1);

            isAttack2 = false;
            animator.SetBool("isAttack2", isAttack2);

            attackRoutine = StartCoroutine(Attack3());
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private IEnumerator Attack3()
    {
        isAttack3 = true;
        animator.SetBool("isAttack3", isAttack3);

        MoveFront();
        yield return new WaitForSeconds(attack3_coolTime);

        StopAttack3();

        yield return new WaitForSeconds(0.2f);

        StopAttack3Cool();
    }

    private void StopAttack3()
    {
        isAttack1 = false;
        animator.SetBool("isAttack1", isAttack1);

        isAttack2 = false;
        animator.SetBool("isAttack2", isAttack2);

        isAttack3 = false;
        animator.SetBool("isAttack3", isAttack3);

        playerInput.isAttack = false;
    }

    private void StopAttack3Cool()
    {
        playerInput.isAttackCool = false;

        StopCoroutine(attackRoutine);
        attackRoutine = null;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////

    private void MoveFront()
    {
        this.transform.Translate(Vector3.forward * 1.0f * Time.deltaTime, Space.Self);
    }

    public void SetAttack1()
    {
        isAttack1Done = true;
    }

    public void SetAttack2()
    {
        isAttack2Done = true;
    }

    public void EnemyAttack()
    {
        
        if (firstCol != null && firstCol.gameObject.tag == "Enemy")
        {
            Debug.Log("적 공격");
            firstCol.gameObject.GetComponent<EnemyInfo>().TakeDamage(10);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (firstCol == null)
                firstCol = col;

            colliderCount++;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            colliderCount--;

            if (colliderCount == 0)
                firstCol = null;
        }
    }
}

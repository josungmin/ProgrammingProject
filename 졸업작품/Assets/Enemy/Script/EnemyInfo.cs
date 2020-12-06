using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfo : MonoBehaviour
{
    [SerializeField]
    private SliderBar Hp;
    [SerializeField]
    private float initHp;   

    public float attackRange = 2.0f; // 공격상태 범위
    public float idleRange = 10.0f;  // 기본상태 범위
    public float speed = 0.3f;     // 이동 속도
    public float defaltSpeed;

    private bool isAttack;
    public bool isDamaged;
    public Transform initPos;

    public bool isAlive
    {
        get
        {
            return Hp.currentValue > 0;
        }
    }

    private Collider firstCol;
    private int colliderCount;

    private void Awake()
    {
        Hp.Init(initHp, initHp);
        defaltSpeed = speed;

        colliderCount = 0;
        firstCol = null;
        initPos = this.transform;
    }

    private void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        isDamaged = true;
        Hp.currentValue -= damage;

        if (Hp.currentValue <= 0)
        {
            defaltSpeed = 0;
        }
    }

    public void Attack()
    {
        if(isAttack)
        {
            //player.GetComponent<PlayerInfo>().TakeDamage(10);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            if (firstCol == null)
                firstCol = col;

            colliderCount++;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            colliderCount--;

            if (colliderCount == 0)
                firstCol = null;
        }
    }

    public void dead()
    {
        Destroy(this.gameObject);
    }

    private void OnDrawGizmos()
    {
        // 기모 색 설정
        Gizmos.color = Color.red;

        // Enable 기즈모
        Gizmos.DrawWireSphere(this.transform.position, attackRange);

        // 기모 색 설정
        Gizmos.color = Color.yellow;

        // Enable 기즈모
        Gizmos.DrawWireSphere(this.transform.position, idleRange);
    }
}

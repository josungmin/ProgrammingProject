using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    public SliderBar Hp;
    [SerializeField]
    private SliderBar Mp;
    [SerializeField]
    private float initHp;
    [SerializeField]
    private float initMp;

    // Start is called before the first frame update
    void Start()
    {
        Hp.Init(initHp, initHp);
        Mp.Init(initMp, initMp);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        Hp.currentValue -= damage;

        if (Hp.currentValue <= 0)
        {
            // 게임 오버
        }
    }
}

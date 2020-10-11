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
        if(Input.GetKeyDown(KeyCode.O))
        {
            Hp.currentValue -= 10;
            Mp.currentValue -= 10;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Hp.currentValue += 10;
            Mp.currentValue += 10;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkill_1 : MonoBehaviour
{
    private Transform FirePos;

    // Start is called before the first frame update
    void Start()
    {
        FirePos = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyInfo>().firePos.transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = FirePos.position;
        this.transform.rotation = FirePos.rotation;
    }
}

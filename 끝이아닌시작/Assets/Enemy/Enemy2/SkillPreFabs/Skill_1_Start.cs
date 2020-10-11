using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1_Start : MonoBehaviour
{
    public bool isAttack = true;

    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player") && isAttack == true)
        {
            Debug.Log("Damaged");
            other.gameObject.GetComponent<PlayerInfo>().Hp.currentValue -= 10;
            isAttack = false;
        }
    }
}

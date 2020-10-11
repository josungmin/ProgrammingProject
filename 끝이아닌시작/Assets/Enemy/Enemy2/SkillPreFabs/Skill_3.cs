using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_3 : MonoBehaviour
{
    public bool isAttack = true;

    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player") && isAttack == true)
        {
            Debug.Log("Damaged");
            isAttack = false;
            other.gameObject.GetComponent<PlayerInfo>().Hp.currentValue -= 10;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1_Start : MonoBehaviour
{
    public bool isAttacked = true;

    void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player") && isAttacked == true)
        {
            Debug.Log("Damaged");
            other.gameObject.GetComponent<PlayerInfo>().Hp.currentValue -= 10;
            isAttacked = false;
        }
    }
}

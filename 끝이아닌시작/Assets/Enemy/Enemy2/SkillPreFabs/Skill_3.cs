using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_3 : MonoBehaviour
{
    public bool isAttacked = true;

    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player") && isAttacked == true)
        {
            Debug.Log("Damaged");
            isAttacked = false;
            other.gameObject.GetComponent<PlayerInfo>().Hp.currentValue -= 10;
        }
    }
}

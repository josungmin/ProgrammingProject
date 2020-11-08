using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolTime : MonoBehaviour
{
    public bool isCoolTime = false;

    public IEnumerator StartCoolTime(float time)
    {
        isCoolTime = true;
        yield return new WaitForSeconds(time);
        isCoolTime = false;
        StopCoroutine(StartCoolTime(time));
    }
}

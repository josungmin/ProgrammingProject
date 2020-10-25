using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    SbjAchievement h = new SbjAchievement();

    // Start is called before the first frame update
    void Start()
    {   
        h.Attach(new ObsEnemyKill(h));
    }

    // Update is called once per frame
    void Update()
    {
        // 몬스터에 붙이는 코드
        // if(enemyHp <= 0)
        if(Input.GetKeyDown(KeyCode.P))
        {
            h.enemyKill++;
            h.Notify();
        }
    }
}

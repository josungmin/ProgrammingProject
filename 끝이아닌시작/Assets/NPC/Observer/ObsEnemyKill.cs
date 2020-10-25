using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsEnemyKill : Observer
{
    private SbjAchievement achievement;

    public ObsEnemyKill(SbjAchievement achieve)
    {
        achievement = achieve;
    }

    public override void Update()
    {
        Debug.Log("몬스터를 죽인 횟수 : " + achievement.enemyKill);
    }
}

//https://minhyeokism.tistory.com/41
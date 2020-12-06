using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SbjAchievement : Subject
{
    // 몬스터 킬
    private int _enemyKill = 0;
    public int enemyKill
    {
        get { return _enemyKill; }
        set { _enemyKill = value; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu (fileName = "Quest", menuName = "Quest/QuestInfo")]
[Serializable]
public class Quest : ScriptableObject
{
    [SerializeField]
    private string questName;

    [SerializeField]
    private string questContents;

    [SerializeField]
    private int goal;

    [SerializeField]
    private bool isClear;

    public string MyQuestName { get { return questName; } }
    public string MyQuestContents { get { return questContents; } }
    public int MyGoal { get { return goal; } }
    public bool MyIsClear { get { return isClear; } set { isClear = value; } }
}

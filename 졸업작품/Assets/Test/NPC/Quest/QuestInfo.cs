using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu (fileName = "QuestInfo", menuName = "Quest/QuestInfo")]
public class QuestInfo : ScriptableObject
{
    [SerializeField]private int id;
    public int progress;
    [SerializeField]private int goal;
    public bool isClear = false;
    [TextArea (1, 3)]
    [SerializeField]private string text;

    public int MyId { get { return id; } }
    public int MyGoal { get { return goal; } }
    public string MyText { get { return text; } }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NpcInfo", menuName = "NPC/NpcInfo")]
[System.Serializable]
public class NpcInfo : ScriptableObject
{
    [SerializeField]private string npcName;
    //[SerializeField]private QuestInfo quest;

    public string MyNpcName { get { return npcName;} }
    //public QuestInfo MyQuest { get {return quest; } }
}
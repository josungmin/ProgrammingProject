using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField]
    private NpcInfo npcInfo;

    [SerializeField]
    private int id;

    [SerializeField]
    private int clearId;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float dialoggueDist;

    [SerializeField]
    private Dialoggue initDialoggue;

    [SerializeField]
    private Dialoggue goalDialoggue;

    [SerializeField]
    private Dialoggue clearDialoggue;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, this.transform.position);

        if (Input.GetKeyDown(KeyCode.G))
        {
            if(distance < dialoggueDist)
            {
                if(QuestManager.MyInstance.GetCurrentQuest(clearId) != null)
                {
                    DialogueManager.MyInstance.SetDialogue(clearDialoggue, clearId);
                }
                else
                {
                    if(QuestManager.MyInstance.GetCurrentQuest(id).isClear)
                    {
                        DialogueManager.MyInstance.SetDialogue(goalDialoggue, id);
                    }
                    else
                    {
                        DialogueManager.MyInstance.SetDialogue(initDialoggue, id);
                    }
                }    
            }
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            QuestManager.MyInstance.GetCurrentQuest(id).isClear = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private Dialoggue initDialoggue;

    [SerializeField]
    private Dialoggue goalDialoggue;

    public DialogueManager dialogueManager;

    public float dialoggueDist;

    [SerializeField]
    private Quest quest;

    private bool isTalk = false;

    // Start is called before the first frame update
    void Start()
    {
        //quest.MyIsClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        Transform target = GameObject.FindGameObjectWithTag("Player").transform; // 플레이어 테그 설정 Player로
        float distance = Vector3.Distance(target.position, this.transform.position);

        if (Input.GetKeyDown(KeyCode.F)) // 대화 거는 키 이거로 바꿔
        {
            if(distance < dialoggueDist && !dialogueManager.isTalk)// && !quest.MyIsClear)
            {
                isTalk = true;
                dialogueManager.SetDialogue(initDialoggue);
            }
            /*
            if (distance < dialoggueDist && !dialogueManager.isTalk && quest.MyIsClear)
            {
                isTalk = true;
                dialogueManager.SetDialogue(goalDialoggue);
            }
            */
        }

        if(isTalk && !dialogueManager.isTalk)
        {
            isTalk = false;
            QuestManager.MyInstance.Accept(quest);
        }
    }

    private void OnDrawGizmos()
    {
        // 기모 색 설정
        Gizmos.color = Color.red;

        // Enable 기즈모
        Gizmos.DrawWireSphere(this.transform.position, dialoggueDist);
    }
}

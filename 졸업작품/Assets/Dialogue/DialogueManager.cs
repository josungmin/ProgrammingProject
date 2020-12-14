using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    public static DialogueManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DialogueManager>();
            }
            return instance;
        }
    }

    private List<string> listSentences = new List<string>();

    public GameObject TextBox;
    public Text text;
    public bool isTalk = false;
    private int count = 0;
    private int id;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
        TextBox.SetActive(false);
    }

    void Update()
    {
        //Debug.Log(isTalk);

        if (isTalk)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                count++;
                //Debug.Log(count);

                if(count >= listSentences.Count)
                {
                    Debug.Log("대화 종료");
                    isTalk = false;
                    StopDialogue();
                    StopCoroutine(StartDialogue());
                }
                else
                {
                    StartCoroutine(StartDialogue());
                }
            }
        }
    }

    public void SetDialogue(Dialoggue dialoggue, int id)
    {
        listSentences.Clear();
        isTalk = true;
        this.id = id;
        
        for (int i = 0; i < dialoggue.sentences.Length; i++)
        {
            listSentences.Add(dialoggue.sentences[i]);
        }
        StartCoroutine(StartDialogue());
    }

    IEnumerator StartDialogue()
    {
        text.text = "";
        TextBox.SetActive(true);

        if(count < listSentences.Count)
        {
            for (int i = 0; i < listSentences[count].Length; i++)
            {
                text.text += listSentences[count][i];
                yield return new WaitForSeconds(0.02f);
            }
        }
    }

    void StopDialogue()
    {
        if(QuestManager.MyInstance.GetCurrentQuest(id).isClear)
        {
            QuestManager.MyInstance.DeleteQuest(id);
        }
        else
        {
            QuestManager.MyInstance.AddQuest(id);
        }

        id = -1;
        count = 0;
        listSentences.Clear();
        TextBox.SetActive(false);
    }
}

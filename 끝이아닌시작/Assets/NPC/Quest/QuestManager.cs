using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public List<Quest> questList = new List<Quest>();
    public GameObject questListPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Quest prime in questList)
        {
            questListPanel.transform.FindChild("Text").GetComponent<Text>().text = prime.questName;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            IsActive();
        }
    }

    public void addList(Quest quest)
    {
        questList.Add(quest);
    }

    public void IsActive()
    {
        if (questListPanel.active == true)
        {
            questListPanel.SetActive(false);
        }
        else
        {
            questListPanel.SetActive(true);
        }
    }
}

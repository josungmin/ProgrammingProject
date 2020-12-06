using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;

    public static QuestManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<QuestManager>();
            }
            return instance;
        }
    }

    private Dictionary<Quest, GameObject> questDictionary = new Dictionary<Quest, GameObject>();

    [SerializeField]
    private Transform parent;

    [SerializeField]
    private GameObject questBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Accept(Quest quest)
    {      
        GameObject go = Instantiate(questBox);

        questDictionary.Add(quest, go);

        RectTransform pos = go.GetComponent<RectTransform>();

        go.transform.parent = parent;
        //pos.position = new Vector3(parent.position.x, parent.position.y, 0);

        go.transform.FindChild("Title").GetComponent<Text>().text = quest.MyQuestName;
        go.transform.FindChild("Contents").GetComponent<Text>().text = quest.MyQuestContents;
        go.transform.FindChild("Goal").GetComponent<Text>().text = quest.MyGoal.ToString() + " / 0";
    }

    public void Clear(Quest quest)
    {
        foreach(KeyValuePair<Quest, GameObject> data in questDictionary)
        {
            if(data.Key == quest)
            {
                Destroy(data.Value);
                questDictionary.Remove(data.Key);
            }
        }
    }
}

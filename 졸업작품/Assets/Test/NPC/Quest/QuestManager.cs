using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;
    public static QuestManager MyInstance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<QuestManager>();
            }
            return instance;
        }
    }

    public Dictionary<int, QuestInfo> questDic = new Dictionary<int, QuestInfo>();

    [SerializeField]
    private List <QuestInfo> currentQuest = new List<QuestInfo>();

    [SerializeField]
    private List<QuestInfo> quests = new List<QuestInfo>();

    [SerializeField]
    private Transform parent;

    [SerializeField]
    private GameObject questBox;

    public bool isTlak = false;

    SbjAchievement h = new SbjAchievement();

    void Awake()
    {
        h.Attach(new ObsEnemyKill(h));

        foreach(var data in quests)
        {
            questDic.Add(data.MyId, data);
        }
    }

    void Update()
    {
        ProgressQuest();
    }

    public QuestInfo GetCurrentQuest(int id)
    {
        foreach(KeyValuePair<int, QuestInfo> data in questDic)
        {
            if(data.Key == id)
                return data.Value;
        } 

        return null;
    }

    public void AddQuest(int id)
    {
        foreach(KeyValuePair<int, QuestInfo> data in questDic)
        {
            if(data.Key == id && !currentQuest.Contains(data.Value))
            {
                currentQuest.Add(data.Value);
                UpdateQuest();
            }
        }     
    }

    public void DeleteQuest(int id)
    {
        foreach(KeyValuePair<int, QuestInfo> data in questDic)
        {
            if(data.Key == id && data.Value.isClear)
            {
                currentQuest.Remove(data.Value);
                UpdateQuest();
            }          
        } 
    }

    private void ProgressQuest()
    {
        foreach(var data in currentQuest)
        {
            if(data.MyId == 1000 && data.progress < data.MyGoal)
            {
                if(h.enemyKill == data.MyGoal)
                {
                    questDic[data.MyId].isClear = true;
                }
            }

            if(data.MyId == 2000 && data.progress < data.MyGoal)
            {
                if(h.enemyKill == data.MyGoal)
                {
                    questDic[data.MyId].isClear = true;
                }
            }
        }
    }

    private void UpdateQuest()
    {
        foreach (Transform child in parent) 
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach(var data in currentQuest)
        {
            GameObject go = Instantiate(questBox);

            RectTransform pos = go.GetComponent<RectTransform>();

            go.transform.parent = parent;
            //go.transform.position = parent.position;
            pos.position = new Vector3(parent.position.x, parent.position.y, 0);

            go.transform.GetChild(0).GetComponent<Text>().text = data.MyText;
            go.transform.GetChild(1).GetComponent<Text>().text = "진행도 : " 
                                + data.MyGoal.ToString() + " / " + data.progress.ToString();
        }
    }
}

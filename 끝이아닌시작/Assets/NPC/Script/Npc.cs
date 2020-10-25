using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    [SerializeField]
    private Quest quest;

    public QuestManager questManager;
    public GameObject player;
    public GameObject questPanel;

    // 대화 가능 거리
    private float enableDistance = 3.0f;
    private bool isEnable = false;

    // 옵저버
    SbjAchievement h = new SbjAchievement();

    // Start is called before the first frame update
    void Start()
    {
        quest.questAccept = false;
        quest.questClear = false;

        h.Attach(new ObsEnemyKill(h));
    }

    // Update is called once per frame
    void Update()
    {
        Eable();

        if (Input.GetKeyDown(KeyCode.G) && isEnable)
        {
            Enter();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            h.enemyKill++;
            h.Notify();
        }

        if (h.enemyKill >= 10)
        {
            quest.questClear = true;
        }
    }

    private void Eable()
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);

        if(distance <= enableDistance)
        {
            isEnable = true;
        }
        else
        {
            isEnable = false;
        }
    }

    private void Enter()
    {
        // 퀘스트 내용 설정
        questPanel.transform.FindChild("QuestContent").GetComponent<Text>().text = quest.questContent;
        // 보상 설정
        questPanel.transform.FindChild("RewardText").GetComponent<Text>().text = quest.questReward;

        questPanel.SetActive(true);

        // 카메라 위치 지정
        // 플레이어 못움직이게하기
    }

    private void Atction()
    {

    }

    public void Exit()
    {
        if(quest.questAccept)
        {
            questManager.addList(quest);
            questPanel.SetActive(false);
        }
        else
        {
            questPanel.SetActive(false);
        }
    }

    void OnDrawGizmos()
    {
        // 기모 색 설정
        Gizmos.color = Color.red;

        // Enable 기즈모
        Gizmos.DrawWireSphere(this.transform.position, enableDistance);
    }
}

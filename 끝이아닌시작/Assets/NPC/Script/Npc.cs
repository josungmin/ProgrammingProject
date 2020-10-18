using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    public GameObject player;
    public GameObject questPanel;

    // 대화 가능 거리
    private float enableDistance = 3.0f;
    private bool isEnable = false;

    // 퀘스트 내용
    private string questContent = "드래곤족 몬스터\n10마리를 사냥 하라\n\n목표 : 드레곤족 몬스터 처치\n0 / 10";

    // 보상 내용
    private string reward = "보상 : 200 골드";

    // 퀘스트 수락
    public bool isAccept = false;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Eable();

        if (Input.GetKeyDown(KeyCode.G) && isEnable)
        {
            Enter();
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
        questPanel.transform.FindChild("QuestContent").GetComponent<Text>().text = questContent;
        // 보상 설정
        questPanel.transform.FindChild("RewardText").GetComponent<Text>().text = reward;

        questPanel.SetActive(true);

        // 카메라 위치 지정
        // 플레이어 못움직이게하기
    }

    private void Atction()
    {

    }

    public void Exit()
    {
        if(isAccept)
        {
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

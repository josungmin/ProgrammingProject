using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 프로그래스바 
public class SliderBar : MonoBehaviour
{
    private Slider bar;
    [SerializeField]
    private Text text;
    public float maxValue { get; set; }
    public float currentValue;

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Slider>();     
    }

    // Update is called once per frame
    void Update()
    {
        // 상태 전환
        if (bar.value != currentValue)
        {
            bar.value = currentValue / maxValue;
            text.text = maxValue.ToString() + " / " + currentValue.ToString();
        }          
    }

    // 초기화
    public void Init(float MaxValue, float CurrentValue)
    {
        maxValue = MaxValue;
        currentValue = CurrentValue;
        text.text = maxValue.ToString() + " / " + currentValue.ToString();
    }
}

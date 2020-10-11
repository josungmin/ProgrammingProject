using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    private Slider bar;
    [SerializeField]
    private Text text;
    public float maxValue { get; set; }
    public float currentValue { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Slider>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (bar.value != currentValue)
        {
            bar.value = currentValue / maxValue;
            text.text = maxValue.ToString() + " / " + currentValue.ToString();
        }          
    }

    public void Init(float MaxValue, float CurrentValue)
    {
        maxValue = MaxValue;
        currentValue = CurrentValue;
        text.text = maxValue.ToString() + " / " + currentValue.ToString();
    }
}

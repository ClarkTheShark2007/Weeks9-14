using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerValue = 0;
    public float timerMaxValue = 10;
    public Slider timerSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerSlider.maxValue = timerMaxValue;
    }

    // Update is called once per frame
    void Update()
    {
        timerValue += Time.deltaTime;

        if(timerValue > timerMaxValue)
        {
            timerValue = 0;
        }

        timerSlider.value = timerValue;
    }
}

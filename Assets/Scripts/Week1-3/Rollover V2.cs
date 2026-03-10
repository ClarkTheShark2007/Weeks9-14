using UnityEngine;
using UnityEngine.InputSystem;

public class RolloverV2 : MonoBehaviour
{
    public bool TimerIsRunning;
    public float Timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        float distance = Vector2.Distance(mousePos, transform.position);

        if (distance < 1)
        {
            TimerIsRunning = true;
            Timer = Timer + Time.deltaTime;
        }
        else
        {
            TimerIsRunning = false;
            Timer = 0;
        }
    }
}

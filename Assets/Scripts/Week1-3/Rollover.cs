using UnityEngine;
using UnityEngine.InputSystem;

public class Rollover : MonoBehaviour
{
    public RotateMe roateScript;
    public bool mouseIsOverMe = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        float distance = Vector2.Distance(mousePos, transform.position);

        if(distance < 1)
        {
            mouseIsOverMe = true;
            roateScript.Speed = 0;
            
        }
        else
        {
            mouseIsOverMe = false;
            roateScript.Speed = 100;
        }
    }
}

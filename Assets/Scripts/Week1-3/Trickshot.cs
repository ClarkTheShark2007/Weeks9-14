using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Trickshot : MonoBehaviour
{
    public AnimationCurve curve;

    public float movement = 6f;

    Vector2 bottomLeft;
    Vector2 topRight;

    public bool timerIsRunning;
    public float Timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        checkForTrickshot();

        if(timerIsRunning == true) 
        {
            Timer += 0.1f * Time.deltaTime;
            transform.position += Vector3.one * curve.Evaluate(Timer);
        }

        if(Timer >= 0.110f) 
        { 
            timerIsRunning = false;
            Timer = 0;
        }


        Vector2 newPosistion = transform.position;
        newPosistion.x += movement * Time.deltaTime;

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x < 0) //Left Edge 
        {
            newPosistion.x = bottomLeft.x;
            movement = movement * -1;
        }

        if (screenPos.x > Screen.width) //Right Edge
        {
            newPosistion.x = topRight.x;
            movement = movement * -1;
        }

        transform.position = newPosistion;
    }
    void checkForTrickshot()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame) 
        {
            timerIsRunning = true;
        }
    }
}

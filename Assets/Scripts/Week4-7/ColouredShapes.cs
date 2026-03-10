using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColouredShapes : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float Timer;
    public float TimerLegnth = 0;
    public List<Sprite> Shapes;
    public int Index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += 1*Time.deltaTime;

        if(Timer >= TimerLegnth)
        {
            RandomColour();
            Timer = 0;
        }

        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            ChangeSprite();
        }
    }

    public void RandomColour()
    {
        spriteRenderer.color = Random.ColorHSV();
    }

    public void ChangeSprite()
    {
        if (Index > Shapes.Count)
        {
            Index = 0;
        }
        else
        {
            Index++;
        }

        spriteRenderer.sprite = Shapes[Index];
    }

    public void RandomTimer() 
    {
        TimerLegnth = Random.Range(0, 6);
    }
}

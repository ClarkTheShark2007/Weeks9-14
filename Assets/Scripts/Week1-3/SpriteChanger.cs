using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteChanger : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Color colorwheel;
    public List<Sprite> Pibbles;
    public int randomNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.color = Color.green;
        pickARandomSprite();
        randomNumber = Random.Range(0, Pibbles.Count);

    }

    // Update is called once per frame
    void Update()
    {
        //pickARandomColour();

        pickARandomSprite();

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (spriteRenderer.bounds.Contains(mousePos))
        {
            spriteRenderer.color = colorwheel;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame && Pibbles.Count > 1)
        {
            Pibbles.RemoveAt(0);
            randomNumber = Random.Range(0, Pibbles.Count);
        }
    }

    void pickARandomColour()
    {

        //if(Keyboard.current.leftArrowKey.wasPressedThisFrame)
        //{
        //    spriteRenderer.color = Random.ColorHSV();
        //}

        //if(Keyboard.current.rightArrowKey.wasPressedThisFrame)
        //{
        //    spriteRenderer.color = colorwheel;
        //}

    }

    void pickARandomSprite()
    {
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            if(Pibbles.Count > 0)
            {
                randomNumber = Random.Range(0, Pibbles.Count);
                Debug.Log("Working");
            }
        }

        //spriteRenderer.sprite = Burger;

        spriteRenderer.sprite = Pibbles[randomNumber];

    }
}

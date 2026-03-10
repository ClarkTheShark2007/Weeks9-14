using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EInteract : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public List<Sprite> Sprites;
    public int Index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer.sprite = Sprites[Index];
    }

    // Update is called once per frame
    void Update()
    {
        //spriteRenderer.sprite = Sprites[Index];
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            Index++;
            if (Index == Sprites.Count)
            {
                Index = 0;
            } 
            spriteRenderer.sprite = Sprites[Index];
        }
    }
}

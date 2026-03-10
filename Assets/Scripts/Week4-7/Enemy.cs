using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer sr;
    public float health = 5;
    public TextMeshProUGUI healthValue;
    public AlienSpawner alienSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        healthValue.text = health.ToString();

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (Mouse.current.leftButton.wasPressedThisFrame && sr.bounds.Contains(mousePos) == true)
        {
            health--;
        }

        if(health == 0)
        {
            Destroy(gameObject);

        }
    }
}

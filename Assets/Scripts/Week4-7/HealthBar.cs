using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public SpriteRenderer player;
    public int health = 10;
    public AudioSource audioSource;
    public AudioClip chompSoundSFX;
    public AudioClip DeathSoundSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.maxValue = health;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (player.bounds.Contains(mousePos) == true && Mouse.current.leftButton.wasPressedThisFrame == true)
        {
            health -= 1;
            if (health <= 0)
            {
                audioSource.clip = DeathSoundSFX;
                audioSource.Play();
                gameObject.SetActive(false);
            }
            else 
            {
                audioSource.clip = chompSoundSFX;
                audioSource.Play();
            }
        }

        healthBar.value = health;
    }

    public void Heal()
    {
        healthBar.maxValue = health;
        health = (int)healthBar.maxValue;
        gameObject.SetActive(true);
    }
}

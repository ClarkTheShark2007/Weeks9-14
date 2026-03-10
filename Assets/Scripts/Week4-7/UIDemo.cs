using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIDemo : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Image pibbleImage;
    public int howManyClicks = 0;
    public TextMeshProUGUI score;
    public Slider slider;
    public TextMeshProUGUI sliderValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        score.text = howManyClicks.ToString();

        slider.wholeNumbers = true;
        slider.minValue = 0;
        slider.maxValue = 10;
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue.text = slider.value.ToString();

        if(Keyboard.current.anyKey.wasPressedThisFrame == true) { 
        
            changeColour();
        }
    }

    public void changeColour()
    {
        spriteRenderer.color = Random.ColorHSV();
        pibbleImage.color = spriteRenderer.color;
    }

    public void SetScale(float scale)
    {
        transform.localScale = Vector3.one * scale;
    }

    public void AddToTheNumber()
    {
        howManyClicks++;
        score.text = howManyClicks.ToString();
    }
}

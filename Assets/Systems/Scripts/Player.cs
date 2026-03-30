using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Player : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    float speed;
    float maxSpeed = 5f;
    bool isSlippery;
    bool acceleratePlayer;
    public Vector2 movement;
    Vector2 slipperyMovement;
    public float HP = 99;
    float maxHP = 99;
    public Slider HPSlider;
    public TextMeshProUGUI HPValue;
    float t;
    public AudioSource hitAudio;
    public AudioSource healAudio;
    bool canTakeDamage = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        HPSlider.wholeNumbers = true;
        HPSlider.minValue = 0;
        HPSlider.maxValue = maxHP;
    }

    void Update()
    {
        HPSlider.value = HP;
        HPValue.text = HP + "/" + maxHP;

        if (HP >= maxHP)
        {
            HP = maxHP;
        }

        if(t <= 0) 
        {
            isSlippery = false;
        } 
        else
        {
            t -= Time.deltaTime;
        }

        if(isSlippery)
        {
            SlipperyPlayerMovement();
            spriteRenderer.color = Color.cyan;
        } else
        {
            transform.position += (Vector3) movement * speed * Time.deltaTime;
            spriteRenderer.color = Color.red;
        }
    }

    public void SlipperyPlayerMovement()
    {
        transform.position += (Vector3) slipperyMovement * speed * Time.deltaTime;
        if(acceleratePlayer)
        {
            speed += Time.deltaTime;
            slipperyMovement = movement;
            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
        } else
        {
            speed -= Time.deltaTime * 2.5f;
            if (speed <= 0)
            {
                speed = 0;
            }
        }
    }

    public void slipperyEffect()
    {
        isSlippery = true;
        t = 5f;
    }

    public void ModifyHP(int modifyAmount)
    {
        if (modifyAmount > 0)
        {
            healAudio.Play();
            HP = HP + modifyAmount;
        }
        if (modifyAmount < 0 && canTakeDamage)
        {
            hitAudio.Play();
            HP = HP + modifyAmount;
            StartCoroutine(invincibleTime());
            canTakeDamage = false;
        }
    }

    IEnumerator invincibleTime()
    {
        yield return new WaitForSeconds(0.75f);
        canTakeDamage = true;
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        movement = context.ReadValue<Vector2>();
        if(isSlippery)
        {
            acceleratePlayer = true;
            if(context.canceled)
            {
                acceleratePlayer = false;
            }

        } else
        {
            speed = maxSpeed;
        }
    }

}

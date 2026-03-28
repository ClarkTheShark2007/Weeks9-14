using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
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

    void Start()
    {
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
        } else
        {
            transform.position += (Vector3) movement * speed * Time.deltaTime;
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
        HP = HP + modifyAmount;
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

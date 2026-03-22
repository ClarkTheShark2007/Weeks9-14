using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    float speed;
    float maxSpeed = 5f;
    bool isSlippery;
    bool acceleratePlayer;
    Vector2 movement;
    Vector2 slipperyMovement;

    void Update()
    {
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

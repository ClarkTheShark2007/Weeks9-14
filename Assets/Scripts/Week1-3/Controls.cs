using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{

    public bool leftMouseIsPressed = false;
    public bool rightMouseIsPressed = false;

    public bool anyKeyIsPressed = false;

    public float Speed = 3;
    public float Rotation = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //isPressed is true all the time
        leftMouseIsPressed = Mouse.current.leftButton.isPressed;
        rightMouseIsPressed = Mouse.current.rightButton.isPressed;

        if (Mouse.current.leftButton.wasPressedThisFrame) 
        {
            Debug.Log("Hello world!");
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Honk!");
        }

        anyKeyIsPressed = Keyboard.current.anyKey.isPressed;

        if(Keyboard.current.leftArrowKey.isPressed)
        {
            /*
            Vector2 newPos = transform.position;
            newPos.x -= Speed * Time.deltaTime;
            transform.position = newPos;
            */

            Vector3 newRotation = transform.eulerAngles;
            newRotation.z += Rotation * Time.deltaTime;
            transform.eulerAngles = newRotation;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            /*
            Vector2 newPos = transform.position;
            newPos.x += Speed * Time.deltaTime;
            transform.position = newPos;
            */

            Vector3 newRotation = transform.eulerAngles;
            newRotation.z -= Rotation * Time.deltaTime;
            transform.eulerAngles = newRotation;

        }

        if (Keyboard.current.upArrowKey.isPressed)
        {
            //Vector2 newPos = transform.position;
            //newPos.y += Speed * Time.deltaTime;
            //transform.position = newPos;
            transform.position += transform.up * Speed * Time.deltaTime;
        }

        if (Keyboard.current.downArrowKey.isPressed)
        {
            //Vector2 newPos = transform.position;
            //newPos.y -= Speed * Time.deltaTime;
            //transform.position = newPos;

            transform.position -= transform.up * Speed * Time.deltaTime;
        }


    }
}

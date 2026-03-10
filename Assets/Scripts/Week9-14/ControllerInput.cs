using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerInput : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 movement;
    public AudioSource soundEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += (Vector3) movement * speed * Time.deltaTime;
        transform.position = movement;
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnAttatck(InputAction.CallbackContext context)
    {

        Debug.Log("I was pushed :(" + context.phase);
        if(context.performed == true)
        {
            soundEffect.Play();
        }
}

    public void OnPoint(InputAction.CallbackContext context)
    {
        movement = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>()); //Mouse Pos
    }
}

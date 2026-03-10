using UnityEngine;

public class DirectionalMovement : MonoBehaviour
{
    public float Speed = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Speed * Time.deltaTime; //Like new vector(1,0,0)& Dont transform.forward
        
    }
}

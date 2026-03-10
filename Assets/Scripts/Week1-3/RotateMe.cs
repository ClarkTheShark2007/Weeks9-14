using UnityEngine;

public class RotateMe : MonoBehaviour
{

    public float Speed = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRotation = transform.eulerAngles;
        newRotation.z += Speed * Time.deltaTime;
        transform.eulerAngles = newRotation;
    }
}

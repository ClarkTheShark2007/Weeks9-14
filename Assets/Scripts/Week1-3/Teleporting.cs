using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public float Timer;
    public Vector2 Location;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Location = (Vector2)transform.position + Random.insideUnitCircle*5;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += 0.5f*Time.deltaTime;

        if (Timer >= 3)
        {
            Timer = 0;
            transform.position = Location;
            Location = (Vector2)transform.position + Random.insideUnitCircle * 5;

            if (Location.y >= 6)
            {
                Location.y = 6;
            } else if (Location.y <= -6) 
                {
                Location.y = -6;
            }
        }
    }
}

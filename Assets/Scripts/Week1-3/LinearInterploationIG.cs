using UnityEngine;

public class LinearInterploationIG : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float t;
    public AnimationCurve curve;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        t += 0.5f*Time.deltaTime;
        if(t >= 1)
        {
            t = 0;
        }
        //transform.position = Vector2.Lerp(start.position, end.position, t);
        transform.position = Vector2.Lerp(start.position, end.position, curve.Evaluate(t));
    }
}

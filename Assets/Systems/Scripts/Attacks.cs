using System.Collections;
using UnityEngine;

public class Attacks : MonoBehaviour
{
   public int attackIndex; //1: Bubble, 2: Droplet, 3: Soap Block
    Vector2 bottomLeft;
    Vector2 topRight;
    float t = 0;
    bool Wiggle;
    public AnimationCurve curve;

    void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        if(attackIndex == 1)
        {
            transform.position = new Vector3(Random.Range(-5.4f, 5.4f), bottomLeft.y, 0);
        }
        else if(attackIndex == 2)
        {
            
        }
        else if(attackIndex == 3)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(attackIndex == 1)
        {
            transform.position += Vector3.up * Time.deltaTime*2f;
            Vector3 newPos  = transform.position;
            newPos.x = 1f * curve.Evaluate(t);
            transform.position = newPos;
        }
        else if(attackIndex == 2)
        {
            
        }
        else if(attackIndex == 3)
        {
            
        }
    }

}

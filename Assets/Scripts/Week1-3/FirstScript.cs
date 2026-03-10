using UnityEngine;

public class FirstScript : MonoBehaviour
{
    public SpriteRenderer Body;
    public float movement = 0f;

    Vector2 bottomLeft;
    Vector2 topRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //movement = Random.Range(0.1f, 5f);
        //transform.position = (Vector2)transform.position + Random.insideUnitCircle * 5;

        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 newPosistion = transform.position;
        newPosistion.x += movement * Time.deltaTime;

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if(screenPos.x < 0) //Left Edge 
        {
            newPosistion.x = bottomLeft.x;
            movement = movement * -1;
        } 
        
        if (screenPos.x > Screen.width) //Right Edge
        {
            newPosistion.x = topRight.x;
            movement = movement * -1;
        }

        transform.position = newPosistion;
    }
}

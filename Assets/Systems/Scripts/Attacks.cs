using System.Collections;
using UnityEngine;

public class Attacks : MonoBehaviour
{
   public int attackIndex; //1: Bubble, 2: Hose, 3: Soap Block, 4: Water Droplets (Spawned by Hose)
    Vector2 bottomLeft;
    Vector2 topRight;
    float t = 0;
    float speed;
    float scale;
    bool attackBool = true;
    public Transform Player;
    public AnimationCurve curve;
    public GameObject waterDropletPrefab;
    public bool activeAttack = true;

    void Start()
    {
        if(activeAttack == true)
        {
            activeAttack = false;
        } else if(activeAttack == false)
        {
            activeAttack = true;
        }

        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        scale = Random.Range(0.7f, 1.2f);
        speed = Random.Range(0.5f, 1.2f);


        if(attackIndex == 1)
        {
            transform.localScale = new Vector2(scale, scale);
            transform.position = new Vector3(Random.Range(-5.4f, 5.4f), bottomLeft.y, 0);
        }
        else if(attackIndex == 2)
        {
            transform.position = new Vector3(Random.Range(-7.21f, 7.21f), Random.Range(0.16f, -4.53f));
            if(transform.position.x < 0)
            {
                transform.position = new Vector3(-7.21f, transform.position.y, 0);

            } else
            {
                transform.position = new Vector3(7.21f, transform.position.y, 0);
                transform.localScale = new Vector2(transform.localScale.x*-1, transform.localScale.y);
            }
        }
        else if(attackIndex == 3)
        {
            
        }
        else if(attackIndex == 4)
        {
            transform.localScale = new Vector2(scale, scale*-1);
        }

        if(activeAttack == false)
        {
            transform.position = new Vector3(1000, 1000, 0);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if(attackIndex == 1)
        {
            BouncyMovement();
            transform.position += Vector3.up * Time.deltaTime*2f;
            Vector3 newPos  = transform.position;
            newPos.x = 1f * curve.Evaluate(t);
            transform.position = new Vector3 (transform.position.x + newPos.x, transform.position.y, 0f);
        }
        else if(attackIndex == 2)
        {
            spawnWaterDroplets();
        }
        else if(attackIndex == 3)
        {
            
        }

        else if(attackIndex == 4)
        {
            Vector2 rotationDirection = (Vector2)Player.position - (Vector2)transform.position;
            transform.up = rotationDirection * Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, Player.position, speed * Time.deltaTime);
            StartCoroutine(DestroyAfterTime());
        }
    }

    void BouncyMovement()
    {
            if(attackBool)
            {
                t += Time.deltaTime;
                if(t > 1f)                
                {
                    t = 1f;
                    attackBool = false;
                }
            }
            if(!attackBool)
            {
                t -= Time.deltaTime;
                attackBool = false;
                if(t < 0f)                
                {
                    t = 0f;
                    attackBool = true;
                }

            }
    }

    void spawnWaterDroplets()
    {
        t += Time.deltaTime;
        if(t >= 1f)
        {
            t = 0f;
            Instantiate(waterDropletPrefab, transform.position, Quaternion.identity);
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}

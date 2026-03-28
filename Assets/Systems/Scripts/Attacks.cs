using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Attacks : MonoBehaviour
{
   public int attackIndex; //1: Bubble, 2: Hose, 3: Soap Block, 4: Water Droplets (Spawned by Hose), 5: Soap Particles (Spawned by Soap Block)
    Vector2 bottomLeft;
    Vector2 topRight;
    float t = 0;
    float speed;
    float scale;
    bool attackBool = true;
    public Transform Player;
    public AnimationCurve curve;
    public GameObject objectPrefabs;
    public bool activeAttack = true;
    public List<GameObject> prefabsSpawned;
    public GameObject spawnedObject;
    int spawnLocation; //1: Top left, 2: Top right, 3: Bottom left, 4: Bottom right

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
        speed = Random.Range(0.5f, 2f);


        if(attackIndex == 1)
        {
            transform.localScale = new Vector2(scale, scale);
            transform.position = new Vector3(Random.Range(-5.4f, 5.4f), bottomLeft.y, 0);
        }
        else if(attackIndex == 2 && activeAttack)
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
            spawnLocation = Random.Range(1, 5);
            if(spawnLocation == 1)
            {
                transform.position = new Vector3(bottomLeft.x, topRight.y, 0);
            }
            else if(spawnLocation == 2)
            {
                transform.position = new Vector3(topRight.x, topRight.y, 0);
                transform.localScale = new Vector2(scale*-1, scale);
            }
            else if(spawnLocation == 3)
            {
                transform.position = new Vector3(bottomLeft.x, bottomLeft.y, 0);
                transform.localScale = new Vector2(scale, scale);
            }
             else if(spawnLocation == 4)
            {
                transform.position = new Vector3(topRight.x, bottomLeft.y, 0);
                transform.localScale = new Vector2(scale*-1, scale);
            }
        }
        else if(attackIndex == 4)
        {
            transform.localScale = new Vector2(scale, scale*-1);
        }

        if(activeAttack == false)
        {
            transform.position = new Vector3(1000, 1000, 0);
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if(attackIndex == 1)
        {
            transform.position += Vector3.up * Time.deltaTime*speed;
        }
        else if(attackIndex == 2)
        {
            if(activeAttack)
            {
                spawnPrefabs();
            }
        }
        else if(attackIndex == 3)
        {
            if(activeAttack)
            {
                spawnPrefabs();
                if(spawnLocation == 1)
                {
                    transform.position += new Vector3(1, -1, 0) * Time.deltaTime*speed;
                }
                else if(spawnLocation == 2)
                {
                    transform.position += new Vector3(-1, -1, 0) * Time.deltaTime*speed;
                }
                else if(spawnLocation == 3)
                {
                    transform.position += new Vector3(1, 1, 0) * Time.deltaTime*speed;
                }
                else if(spawnLocation == 4)
                {
                    transform.position += new Vector3(-1, 1, 0) * Time.deltaTime*speed;
                }
            }
        }

        else if(attackIndex == 4)
        {
            Vector2 rotationDirection = (Vector2)Player.position - (Vector2)transform.position;
            transform.up = rotationDirection * Time.deltaTime;
            if(activeAttack)
            {
                StartCoroutine(DestroyAfterTime());
                transform.position = Vector2.Lerp(transform.position, Player.position, speed * Time.deltaTime);
            }
        } 
        else if(attackIndex == 5)
        {
            t += 0.5f * Time.deltaTime;
            if(t > 1)
            {
                t = 0;
            }
            float y = curve.Evaluate(t); 
            transform.localScale = Vector3.one * curve.Evaluate(t);

            if(activeAttack)
            {
                StartCoroutine(DestroyAfterTime());
            }
        }
    }

    void spawnPrefabs()
    {
        t += Time.deltaTime;
        if(t >= 1f)
        {
            t = 0f;
            spawnedObject = Instantiate(objectPrefabs, transform.position, Quaternion.identity);
            prefabsSpawned.Add(spawnedObject);
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(5f);
        destoryAttack();
    }

    public void destoryAttack()
    {
        for (int i = prefabsSpawned.Count - 1; i >= 0; i--)
        {
            GameObject droplet = prefabsSpawned[i];
            prefabsSpawned.Remove(droplet);
            Destroy(droplet);
        }
        Destroy(gameObject);
    }
}

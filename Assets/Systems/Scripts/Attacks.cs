using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    //Varibles
    public int attackIndex; //1: Bubble, 2: Hose, 3: Soap Block, 4: Water Droplets (Spawned by Hose), 5: Soap Particles (Spawned by Soap Block)
    float t = 0; //Used for Soap Block and Hose when spawning prefabs
    float speed;
    float scale;
    int spawnLocation; //Only used for Bubbles! 1: Top left, 2: Top right, 3: Bottom left, 4: Bottom right
    public bool activeAttack = true; //Used for prefabs in the scene to make they do not get destoryed

    //Refernces
    public Transform Player;
    public AnimationCurve curve;
    public GameObject objectPrefabs;
    public List<GameObject> prefabsSpawned;
    public GameObject spawnedObject;

    //Vectors
    Vector2 bottomLeft;
    Vector2 topRight;


    void Start()
    {
        if(activeAttack == true) //Allows for prefabs to be setup, bools checked in spawning more prefabs
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


        //Spawn Locations / Scale for Each Attack
        if(attackIndex == 1) //Bubbles
        {
            transform.localScale = new Vector2(scale, scale);
            transform.position = new Vector3(Random.Range(-5.4f, 5.4f), bottomLeft.y, 0);
        }
        else if(attackIndex == 2 && activeAttack) //Hose
        {
            //Changes the Scale of X to make it face the player DEPENDING what side of the box it spawn
            transform.position = new Vector3(Random.Range(-7.21f, 7.21f), Random.Range(0.16f, -4.53f));
            if(transform.position.x < 0)
            {
                transform.position = new Vector3(-7.21f, transform.position.y, 0); //Left Side

            } else
            {
                transform.position = new Vector3(7.21f, transform.position.y, 0); //Right Side
                transform.localScale = new Vector2(transform.localScale.x*-1, transform.localScale.y);
            }
        }
        else if(attackIndex == 3) //Soap Block
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
        else if(attackIndex == 4) //Water Droplets 
        {
            transform.localScale = new Vector2(scale, scale*-1); //Rotates the sprite Y scale to make the bottom of droplet face the player
        }
        else if (attackIndex == 5) //Soap Particles
        {
            transform.localScale = new Vector2(scale, scale);
        }

        if (activeAttack == false) //Moves off screen and resets any transform scale from the above scale
        {
            transform.position = new Vector3(1000, 1000, 0);
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        //Differment patterns for each attack depending on coresponding Index
        if(attackIndex == 1) //Bubbles
        {
            transform.position += Vector3.up * Time.deltaTime*speed;
        }
        else if(attackIndex == 2) //Hose
        {
            if(activeAttack)
            {
                spawnPrefabs();
            }
        }
        else if(attackIndex == 3) //Soap Block
        {
            if(activeAttack)
            {
                spawnPrefabs();
                
                //Differnemnt movement pattern based on spawn location
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

        else if(attackIndex == 4) //Water Droplets
        {
            Vector2 rotationDirection = (Vector2)Player.position - (Vector2)transform.position;
            transform.up = rotationDirection * Time.deltaTime;
            if(activeAttack)
            {
                StartCoroutine(DestroyAfterTime());
                transform.position = Vector2.Lerp(transform.position, Player.position, speed * Time.deltaTime); //Moves towards the player based on the speed and transform position
            }
        } 
        else if(attackIndex == 5) //Soap Particles
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

    void spawnPrefabs() //Used by Hose and Soap Block, spawns prefab refernce depending on the attack and add it to the list.
    {
        t += Time.deltaTime;
        if(t >= 1f)
        {
            t = 0f;
            spawnedObject = Instantiate(objectPrefabs, transform.position, Quaternion.identity);
            prefabsSpawned.Add(spawnedObject);
        }
    }

    IEnumerator DestroyAfterTime() //Used by Water Droplets and Soap Particles, waits for 5 seconds then destroys itself.
    {
        yield return new WaitForSeconds(5f);
        destoryAttack();
    }

    public void destoryAttack() //Removes and Destroyes all prefabs spawned by the attack, called by when a new round is started
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

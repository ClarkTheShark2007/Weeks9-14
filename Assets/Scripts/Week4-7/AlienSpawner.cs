using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public int AlienCount;
    public GameObject AliensPrefab;
    public List<GameObject> Aliens;
    public GameObject spawnedAlien;
    public GameObject winText;
    public AudioSource winSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < AlienCount; i++)
        {
            Vector2 spawnPos = Random.insideUnitCircle * 5;
            spawnedAlien = Instantiate(AliensPrefab, spawnPos, Quaternion.identity);
            Aliens.Add(spawnedAlien);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Aliens.Count == 0)
        {
            Debug.Log("YOu Win");
            winSound.Play();
            winText.SetActive(true);
        }
    }

    public void RemoveAlien()
    {


        Aliens.Remove(spawnedAlien);

        //        Debug.Log("Pibble is hurt! " + i);
        //        GameObject tank = tanks[i];
        //        tanks.Remove(tank);
        //        Destroy(tank);
    }
}

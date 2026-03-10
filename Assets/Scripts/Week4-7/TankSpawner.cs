using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankSpawner : MonoBehaviour
{

    public GameObject TankPrefab;
    public int TankID = 0;
    public GameObject spawnedTank;

    public FirstScript TankScript;

    public List<GameObject> tanks;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            SpawnObject();
        }

        if(Mouse.current.rightButton.wasPressedThisFrame)
        {
            tanks.Remove(spawnedTank);
            Destroy(spawnedTank);
        }

        //for (int i = tanks.Count - 1; i >= 0; i--)
        //{
        //    float distance = Vector2.Distance(tanks[i].transform.position, pibble.position);
        //    if (distance < 1f)
        //    {
        //        Debug.Log("Pibble is hurt! " + i);
        //        GameObject tank = tanks[i];
        //        tanks.Remove(tank);
        //        Destroy(tank);

        //    }
        //}

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Instantiate(TankPrefab, transform);
        }
    }

    public void SpawnObject()
    {
        //Instantiate(TankPrefab);
        //Instantiate(TankPrefab, transform.position, transform.rotation);

        Vector2 spawnPos = Random.insideUnitCircle * 3;
        //Identiy mean 0 rotation
        spawnedTank = Instantiate(TankPrefab, spawnPos, Quaternion.identity);

        TankScript = spawnedTank.GetComponent<FirstScript>();

        TankID++;

        //TankScript.movement = TankID;

        //TankScript.Body.color = Random.ColorHSV();

        tanks.Add(spawnedTank);


        for (int i = 0; i < tanks.Count; i++)
        {
            FirstScript ts = tanks[i].GetComponent<FirstScript>();
            //ts.movement = TankID;
        }
    }
}

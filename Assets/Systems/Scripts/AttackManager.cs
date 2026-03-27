using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    GameObject attack;
    public GameObject soapBlock;
    //public GameObject dropplets;
    //public GameObject bubbles;
    public List<GameObject> activeAttacks;
    public Attacks attackPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void startAttack()
    {
        Debug.Log("Attack Started");
        attack = Instantiate(soapBlock, transform.position, Quaternion.identity);
        activeAttacks.Add(attack);
    }

    public void removeAttacks()
    {
        for(int i = 0; i < activeAttacks.Count; i++)
        {
            attack = activeAttacks[i];
            Attacks attackScript = activeAttacks[i].GetComponent<Attacks>();
            attackScript.destoryAttack();
        }
        activeAttacks.Clear();
    }
}

using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    GameObject attack;
    public List<GameObject> attackPrefabs;
    public List<GameObject> activeAttacks;

    public void startAttack() //Instaniates a random prefab from the list (Bubbles, Hose or Soap Block) and adds it to the activeAttacks list
    {
        int randomAttack = Random.Range(0, attackPrefabs.Count);
        attack = Instantiate(attackPrefabs[randomAttack], transform.position, Quaternion.identity);
        activeAttacks.Add(attack);
    }

    public void removeAttacks() //Goes through each active attack in the list, calling it built in destory function, allowing to destory itself and spawned prefabs. Clears  the list for the next round.
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

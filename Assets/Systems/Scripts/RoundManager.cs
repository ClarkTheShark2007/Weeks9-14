using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundManager : MonoBehaviour
{
    float currentRound = 0;
    public TextMeshProUGUI roundText;
    public AttackManager attackManager;
    public Pibble pibble;
    public Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startNewRound();
    }

    IEnumerator roundTimer()
    {
        yield return new WaitForSeconds(5f + currentRound);
        startNewRound();
    }

    IEnumerator spawnAttack()
    {
        yield return new WaitForSeconds(Random.Range(0f, currentRound+1));
        attackManager.startAttack();
    }

    void startNewRound()
    {
        currentRound++;
        pibble.newPibbleReaction();
        roundText.text = currentRound.ToString();
        attackManager.removeAttacks();
        for(int i = 0; i < currentRound; i++)
        {
            StartCoroutine(spawnAttack());
        }
        StartCoroutine(roundTimer());
    }

    void Update()
    {
        if(player.HP <= 0)
        {
            currentRound = 0;
            player.HP = 99;
            if (roundTimer() != null)
            {
                StopCoroutine(roundTimer());
            }

            if (spawnAttack() != null)
            {
                StopCoroutine(spawnAttack());
            }
        }   
    }

    
}

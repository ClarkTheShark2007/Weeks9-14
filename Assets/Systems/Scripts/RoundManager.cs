using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundManager : MonoBehaviour
{
    //Varibles
    float currentRound = 0;

    //References
    public TextMeshProUGUI roundText;
    public AttackManager attackManager;
    public Pibble pibble;
    public Player player;

    void Start()
    {
        startNewRound();
    }

    IEnumerator roundTimer() //Waits for 5 seconds + currnet round, then starts a new round
    {
        yield return new WaitForSeconds(5f + currentRound);
        startNewRound();
    }

    IEnumerator spawnAttack() //Spawns an attack within the 0 to the current round + 1 secconds. This spaces out the attacks so they dont all spawn at once. Call attack manager to spawn attack.
    {
        yield return new WaitForSeconds(Random.Range(0f, currentRound+1));
        attackManager.startAttack();
    }

    void startNewRound()  //Call all functions need run to start a new round
    {
        //Increases the current round by 1 (Updates the UI on the sign), calls a new pibble reaction, calls for the removal of all current attacks, spawns attacls based on round number and starts a new round timer.
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

    void Update() //Checks to see if the game should be restarted if the player HP is 0. Stops all active Coroutines to prevent multiple attacks spawningf rom the previous round after the game is restarted.
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

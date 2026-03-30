using UnityEngine;

public class Pibble : MonoBehaviour
{
    //Varibles
    public int reactionIndex;
    
    //References
    public GameObject sleepingReaction;
    public GameObject tauntingReaction;

    void Update()
    {
        if (reactionIndex == 1) //Idle
        {
            sleepingReaction.SetActive(false);
            tauntingReaction.SetActive(false);
        }
        else if (reactionIndex == 2) //Sleeping
        {
            sleepingReaction.SetActive(true);
            tauntingReaction.SetActive(false);
        }
        else if (reactionIndex == 3) //Taunting
        {
            sleepingReaction.SetActive(false);
            tauntingReaction.SetActive(true);
        }
    }

    public void newPibbleReaction() //Called at start of each round from RoundManager, sets to 1 to reset the current reaction
    {
        reactionIndex = 1;
        reactionIndex = Random.Range(1, 4);
        Debug.Log("Pibble Reaction: " + reactionIndex);
    }
}

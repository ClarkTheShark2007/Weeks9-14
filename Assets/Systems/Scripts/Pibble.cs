using UnityEngine;

public class Pibble : MonoBehaviour
{
    public int reactionIndex;
    public GameObject sleepingReaction;
    public GameObject tauntingReaction;

    void Update()
    {
        if (reactionIndex == 1)
        {
            sleepingReaction.SetActive(false);
            tauntingReaction.SetActive(false);
        }
        else if (reactionIndex == 2)
        {
            sleepingReaction.SetActive(true);
            tauntingReaction.SetActive(false);
        }
        else if (reactionIndex == 3)
        {
            sleepingReaction.SetActive(false);
            tauntingReaction.SetActive(true);
        }
    }

    public void newPibbleReaction()
    {
        reactionIndex = 1;
        reactionIndex = Random.Range(1, 4);
        Debug.Log("Pibble Reaction: " + reactionIndex);
    }
}

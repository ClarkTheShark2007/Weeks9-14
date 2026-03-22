using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundManager : MonoBehaviour
{
    float currentRound = 0;
    public TextMeshProUGUI roundText;
    public AttackManager attackManager;

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

    void startNewRound()
    {
        currentRound++;
        roundText.text = currentRound.ToString();
        StartCoroutine(roundTimer());
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TurnBasedBattle : MonoBehaviour
{
    public Transform duckie;
    public Transform pibble;
    public AnimationCurve curve;
    float t = 0;
    bool isStriking = false;
    bool isStriking2 = false;
    Coroutine Battle1Coroutine;
    Coroutine Battle2Coroutine;

    public GameObject button1;
    public GameObject button2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartCoroutine(BattleAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBattleAnimation()
    {
        if(!isStriking)
        {
            isStriking = true;
            StartCoroutine(BattleTracker());
        }
    }

    public void otherButton()
    {
        isStriking2 = true;
        StartCoroutine(BattleTracker());
    }

    IEnumerator BattleTracker()
    {
        if(isStriking)
        {
            yield return Battle1Coroutine = StartCoroutine(BattleAnimation());
            button1.SetActive(false);
            button2.SetActive(true);
        }
        //Debug.Log("Players 2 Turn!");
        if(isStriking2)
        {
            yield return Battle2Coroutine = StartCoroutine(BattleAnimation2());
            button1.SetActive(true);
            button2.SetActive(false);
        }
    }


    IEnumerator BattleAnimation()
    {
        Debug.Log("Strike Started!");
        Vector3 newPosistion = duckie.position;
        while(t < 1 && isStriking)
        {
            t += Time.deltaTime;
            float y = curve.Evaluate(t); 
            newPosistion.x = 1f * curve.Evaluate(t);
            duckie.position += new Vector3(newPosistion.x/2, 0, 0);
            yield return null;
            //yield return new WaitForSeconds(1f);
        }
        Debug.Log("Strike Finished!");

        if(t >= 1)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(ResetAnimation());
        }
    }

    IEnumerator ResetAnimation()
    {
        Debug.Log("Retreat!");
        Vector3 newPosistion = duckie.position;
        while(t > 0)
        {
            t -= Time.deltaTime;
            float y = curve.Evaluate(t); 
            newPosistion.x = 1f * curve.Evaluate(t);
            duckie.position -= new Vector3(newPosistion.x/2, 0, 0);
            yield return null;
        }
        Debug.Log("Safe!");
        isStriking = false;
    }

    IEnumerator BattleAnimation2()
    {
        Debug.Log("Strike Started! 2");
        Vector3 newPosistion = pibble.position;
        while(t < 1)
        {
            t += Time.deltaTime;
            float y = curve.Evaluate(t); 
            newPosistion.x = 1f * curve.Evaluate(t);
            pibble.position -= new Vector3(newPosistion.x/2, 0, 0);
            yield return null;
            //yield return new WaitForSeconds(1f);
        }
        Debug.Log("Strike Finished! 2");

        yield return new WaitForSeconds(1f);
        StartCoroutine(ResetAnimation2());
    }

    IEnumerator ResetAnimation2()
    {
        Debug.Log("Retreat! 2");
        Vector3 newPosistion = pibble.position;
        while(t > 0)
        {
            t -= Time.deltaTime;
            float y = curve.Evaluate(t); 
            newPosistion.x = 1f * curve.Evaluate(t);
            pibble.position += new Vector3(newPosistion.x/2, 0, 0);
            yield return null;
        }
        Debug.Log("Safe! 2");
        isStriking2 = false;
    }
}

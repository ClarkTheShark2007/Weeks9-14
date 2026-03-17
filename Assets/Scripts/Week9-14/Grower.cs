using System.Collections;
using UnityEngine;

public class Grower : MonoBehaviour
{
    public Transform treeTransform;
    public Transform appleTransform;
    public float appleDelay = 1f;

    Coroutine theGrowingCoroutine;
    Coroutine theTreeCoroutine;
    Coroutine theAppleCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //StartCoroutine(GrowTree());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTreeGrowing()
    {
        if (theGrowingCoroutine != null)
        {
            StopCoroutine(theGrowingCoroutine);
        }

        if (theTreeCoroutine != null)
        {
            StopCoroutine(theTreeCoroutine);
        }

        if(theAppleCoroutine != null)
        {
            StopCoroutine(theAppleCoroutine);
        }

        theGrowingCoroutine = StartCoroutine(StartTheGrowing());
        //StartCoroutine(GrowTree());
        //StartCoroutine(GrowApple());
    }

    IEnumerator StartTheGrowing()
    {
        Debug.Log("Starting the growing process...");
        yield return theTreeCoroutine = StartCoroutine(GrowTree());
        Debug.Log("Tree has finished growing. Apple growwwwww...");

        yield return new WaitForSeconds(appleDelay);

        yield return theAppleCoroutine = StartCoroutine(GrowApple());
        Debug.Log("Apple has finished growing.");
    }

    IEnumerator GrowTree()
    {
        Debug.Log("Started the Tree");
        float t = 0;
        treeTransform.localScale = Vector2.zero;
        appleTransform.localScale = Vector2.zero;

        while(t < 1)
        {
            t += Time.deltaTime;
            treeTransform.localScale = Vector2.one * t;
            yield return null;
            //yield return new WaitForSeconds(appleDelay);
        }
        Debug.Log("Finished growing Tree");

        //yield return new WaitForSeconds(appleDelay);
        //StartCoroutine(GrowApple());
        
    }

    IEnumerator GrowApple()
    {
        Debug.Log("Apple started");
        float t = 0;
        appleTransform.localScale = Vector2.zero;

        while(t < 1)
        {
            t += Time.deltaTime;
            appleTransform.localScale = Vector2.one * t;
            yield return null;
        }
        Debug.Log("Apple finished growing");
    }
}

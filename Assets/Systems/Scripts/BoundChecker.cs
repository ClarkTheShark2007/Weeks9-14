using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoundChecker : MonoBehaviour
{

//Taken and modified from the Deadly Dungeon Example, from the slate unity package. 
    public List<SpriteRenderer> boundSr; 
    bool isTouchingBounds = false;
    public UnityEvent OnEnterBound;
    bool wasInBoundLastFrame;

    void Update()
    {
        wasInBoundLastFrame = isTouchingBounds;
        bool isInBoundThisFrame = false; 
        foreach(SpriteRenderer sr in boundSr) //Checks to see if sprite bounds are in the middle
        {
            if (sr.bounds.Contains(transform.position)) //Invokes Unity Event, allowing for diffrent function for each object
            {
                if (isTouchingBounds)
                {
                    isInBoundThisFrame = true;
                }
                else
                {
                    OnEnterBound.Invoke();
                    isTouchingBounds = true;
                    return;
                }
            }
        }
        if (wasInBoundLastFrame && !isInBoundThisFrame) //Leaving sprite bounds
        {
            isTouchingBounds = false;
        }
    }
}

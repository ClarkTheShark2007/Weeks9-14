using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoundChecker : MonoBehaviour
{
    public List<SpriteRenderer> boundsSrs;
    bool isTouchingBounds = false;
    public UnityEvent OnEnterBound;
    public UnityEvent OnExitBound;
    bool wasInBoundLastFrame;

//Cite code Here
    void Update()
    {
        wasInBoundLastFrame = isTouchingBounds;
        bool isInBoundThisFrame = false; 
        foreach(SpriteRenderer sr in boundsSrs)
        {
            if (sr.bounds.Contains(transform.position))
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
        if (wasInBoundLastFrame && !isInBoundThisFrame)
        {
            //just left the Bound
            OnExitBound.Invoke();
            isTouchingBounds = false;
        }
    }
}

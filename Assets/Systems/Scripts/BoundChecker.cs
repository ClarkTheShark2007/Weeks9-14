using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoundChecker : MonoBehaviour
{
    public List<SpriteRenderer> boundsSrs;
    public bool isTouchingBounds = false;
    public UnityEvent OnEnterHazard;
    public UnityEvent OnExitHazard;
    bool wasInHazardLastFrame;

    void Update()
    {
        wasInHazardLastFrame = isTouchingBounds;
        bool isInHazardThisFrame = false; 
        foreach(SpriteRenderer sr in boundsSrs)
        {
            if (sr.bounds.Contains(transform.position))
            {
                if (isTouchingBounds)
                {
                    isInHazardThisFrame = true;
                }
                else
                {
                    OnEnterHazard.Invoke();
                    isTouchingBounds = true;
                    return;
                }
            }
        }
        if (wasInHazardLastFrame && !isInHazardThisFrame)
        {
            //just left the hazard
            OnExitHazard.Invoke();
            isTouchingBounds = false;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistanceChecker : MonoBehaviour
{
    public List<Transform> transforms;
    public float distanceToCheck = 1f;
    bool isTouchingObject = false;
    public UnityEvent touchingObject;
    public UnityEvent notTouchingObject;
    bool wasInHazardLastFrame;

    void Update()
    {
        wasInHazardLastFrame = isTouchingObject;
        bool isInHazardThisFrame = false; 

        foreach(Transform pos in transforms)
        {
            float distance = Vector2.Distance(transform.position, pos.position);
            if (distance <= distanceToCheck)
            {
                if (isTouchingObject)
                {
                    isInHazardThisFrame = true;
                }
                else
                {
                    touchingObject.Invoke();
                    isTouchingObject = true;
                    return;
                }
            }
        }
        if (wasInHazardLastFrame && !isInHazardThisFrame)
        {
            //just left the hazard
            notTouchingObject.Invoke();
            isTouchingObject = false;
        }
    }
}

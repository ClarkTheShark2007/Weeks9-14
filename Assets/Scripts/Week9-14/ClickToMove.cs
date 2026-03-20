using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    public LineRenderer lR;
    public List<Vector2> points;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       points = new List<Vector2>();
       points.Add(transform.position);

       UpdateLineRenderer();
    }

    // Update is called once per frame
    void Update()
    {

        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            points.Add(mousePos);
            UpdateLineRenderer();
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            points.RemoveAt(0);
            UpdateLineRenderer();
        }
    }

    private void UpdateLineRenderer()
    {
        lR.positionCount = points.Count;
        for (int i = 0; i < points.Count; i++)
        {
            lR.SetPosition(i, points[i]);
        }
    }

}

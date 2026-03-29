using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BetterClickToMove : MonoBehaviour
{
    public LineRenderer lR;
    public List<Vector2> points;
    public Vector2 mousePos;
    float t;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        points = new List<Vector2>();
        points.Add(transform.position);
        points.Add(mousePos);
        points.Add(mousePos);
        //UpdateLine();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLine();
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
       mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log("I did stuff");
        points[2] = mousePos;
        StartCoroutine(MovePlayer());
    }

    IEnumerator MovePlayer()
    {
        t = 0;
        Vector2 moveTransform = points[2];
        while (t < 1)
        {
            t += Time.deltaTime * 0.5f;
            transform.position = Vector2.Lerp(transform.position, moveTransform, t);
            yield return null;
        }
        t = 0;
        yield return new WaitForSeconds(0f);

    }

    private void UpdateLine()
    {
        lR.positionCount = points.Count;
        lR.SetPosition(0, transform.position);
        lR.SetPosition(1, mousePos);
        lR.SetPosition(2, mousePos);
    }
}

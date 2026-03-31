using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class TIleMapGrassToucher : MonoBehaviour
{
    public Tilemap tilemap;
    public Transform highlight;

    public Tile grass;
    Vector3Int cellPos;
    Vector3 pos;

    public GameObject pibble;
    float t;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {

    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        cellPos = tilemap.WorldToCell(mousePos);
        pos = tilemap.GetCellCenterWorld(cellPos);

        //Debug.Log(mousePos +" Is at cell: " + cellPos);
        highlight.position = pos;
    }

    public void Click(InputAction.CallbackContext context)
    {
        Debug.Log(tilemap.GetTile(cellPos));

        if(tilemap.GetTile(cellPos) != grass)
        {
            Debug.Log("AHHHHHHHHHHHH");
            //pibble.transform.position = pos;
            t = 0;
            StartCoroutine(LerpMove());
        }
    }

    IEnumerator LerpMove()
    {
        Vector3 endPos = pos;
        Vector3 startPos = pibble.transform.position;
        while (t <= 1)
        {
            t += Time.deltaTime*0.5f;
            Debug.Log(t);

            pibble.transform.position = Vector2.Lerp(startPos, endPos, t);
            yield return null;
        }
    }
}

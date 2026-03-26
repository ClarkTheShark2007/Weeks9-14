using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class TIleMapStuff : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Tilemap tilemap;
    public Transform highlight;

    public Tile flower;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3Int cellPos = tilemap.WorldToCell(mousePos);
        Vector3 pos = tilemap.GetCellCenterWorld(cellPos);

        //Debug.Log(mousePos +" Is at cell: " + cellPos);
        highlight.position = pos;
        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log(tilemap.GetTile(cellPos));
            tilemap.SetTile(cellPos, flower);
        }
    }
}

using UnityEngine;
using UnityEngine.Tilemaps;

public class Dot : MonoBehaviour
{
    public Tilemap dotMap;
    public Tile dotTile;
    public Tilemap wallMap;
    private Tile empty;

    public void Init()
    {
        dotMap = GetComponent<Tilemap>();
        wallMap = GameObject.FindGameObjectWithTag("wall").GetComponent<Tilemap>();
        for (int x = -30; x < 30; x++)
        {
            for (int y = -30; y < 30; y++)
            {
                var coord = new Vector3Int(x, y, 0);
                dotMap.SetTile(coord, wallMap.GetTile(coord));
            }
        }
        dotMap.BoxFill(new Vector3Int(0, 3, 0), dotTile, -14, -15, 13, 13);
        for (int x = -30; x < 30; x++)
        {
            for (int y = -30; y < 30; y++)
            {
                var coord = new Vector3Int(x, y, 0);
                if (dotMap.GetTile(coord) != dotTile)
                {
                    dotMap.SetTile(coord, empty);
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
using UnityEngine;
using UnityEngine.Tilemaps;
public class ground : MonoBehaviour
{
    [Header("Tilemaps")]
    public Tilemap groundTilemap;   // Stone
    public Tilemap pathTilemap;     // Dirt

    [Header("Tiles")]
    public TileBase grassPathTile;
    public TileBase dirtPathTile;

    [Header("2x2 Block Tiles")]
    public TileBase tile1; // linksboven
    public TileBase tile2; // rechtsboven
    public TileBase tile3; // linksonder
    public TileBase tile4; // rechtsonder

    [Header("Map Size")]
    public int width = 50;
    public int height = 50;

    [Header("Path Settings")]
    public int dirtPathLength = 150;
    public int grassPathLength = 80;

    void Start()
    {
        GenerateGround();
        GenerateDirtPath();
        GenerateGrassPath();
    }

    void GenerateGround()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                PlaceBlock(x * 2, y * 2);
            }
        }
    }

    void PlaceBlock(int x, int y)
    {
        groundTilemap.SetTile(new Vector3Int(x, y + 1, 0), tile1); // 1
        groundTilemap.SetTile(new Vector3Int(x + 1, y + 1, 0), tile2); // 2
        groundTilemap.SetTile(new Vector3Int(x, y, 0), tile3); // 3
        groundTilemap.SetTile(new Vector3Int(x + 1, y, 0), tile4); // 4
    }

    void GenerateDirtPath()
    {
        Vector3Int pos = new Vector3Int(width / 2, height / 2, 0);

        for (int i = 0; i < dirtPathLength; i++)
        {
            pathTilemap.SetTile(pos, dirtPathTile);
            MoveRandom(ref pos);
        }
    }

    void GenerateGrassPath()
    {
        Vector3Int pos = new Vector3Int(Random.Range(0, width), Random.Range(0, height), 0);

        for (int i = 0; i < grassPathLength; i++)
        {
            // Alleen plaatsen als er nog niets ligt
            if (pathTilemap.GetTile(pos) == null)
                pathTilemap.SetTile(pos, grassPathTile);

            MoveRandom(ref pos);
        }
    }

    void MoveRandom(ref Vector3Int pos)
    {
        int dir = Random.Range(0, 4);
        switch (dir)
        {
            case 0: pos += Vector3Int.up; break;
            case 1: pos += Vector3Int.down; break;
            case 2: pos += Vector3Int.left; break;
            case 3: pos += Vector3Int.right; break;
        }

        pos.x = Mathf.Clamp(pos.x, 0, width - 1);
        pos.y = Mathf.Clamp(pos.y, 0, height - 1);
    }
}

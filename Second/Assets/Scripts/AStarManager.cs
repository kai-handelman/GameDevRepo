using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AStarManager : MonoBehaviour
{
    [SerializeField] Tilemap walkableTilemap;
    [SerializeField] Transform NPC;
    // [SerializeField] Transform highlight;

    //Note: In C#, variables without an access modifier are private by default
    Vector3Int[,] walkableArea;
    Astar astar;
    BoundsInt bounds;
    Vector2[] newPath;
    public Vector2Int GridPositionofTarget(Vector2 target)
    {
        
        return (Vector2Int)walkableTilemap.WorldToCell(target);
      
    }
    

    public Vector2Int GridPositionOfNPC
    {
        get
        {
            return (Vector2Int)walkableTilemap.WorldToCell(NPC.position);
            
        }
    }

    public Vector2 celltoWorldConvert(Spot Path)
    {

        Vector2 temp = walkableTilemap.CellToWorld(new Vector3Int(Path.X, Path.Y, 0));
        temp.x += 0.5f;
        temp.y += 0.5f;
        return temp;
    }

    private void Start()
    {
        //Trims any empty cells from the edges of the tilemap
        walkableTilemap.CompressBounds();
        bounds = walkableTilemap.cellBounds;

        CreateGrid();
        astar = new Astar(walkableArea, bounds.size.x, bounds.size.y);
    }

    private void CreateGrid()
    {
        walkableArea = new Vector3Int[bounds.size.x, bounds.size.y];
        for (int x = bounds.xMin, i = 0; i < (bounds.size.x); x++, i++)
        {
            for (int y = bounds.yMin, j = 0; j < (bounds.size.y); y++, j++)
            {
                if (walkableTilemap.HasTile(new Vector3Int(x, y, 0)))
                {
                    walkableArea[i, j] = new Vector3Int(x, y, 0);
                }
                else
                {
                    walkableArea[i, j] = new Vector3Int(x, y, 1);
                }
            }
        }
    }

    public List<Spot> getPath(Vector2Int curPos,Vector2Int target)
    {
        return astar.CreatePath(walkableArea, curPos, target);
    }
}

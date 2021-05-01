using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard
{
    public enum eDir
    {
        Up = 1 << 0,
        Right = 1 << 1,
        Left = 1 << 2,
        Down = 1 << 3,
        UpLeft = Up | Left,
        DownLeft = Down | Right,
        DownRight = Down | Right,
        UpRight = Up | Right
    }

    public uint GridHeight { get; private set; }
    public uint GridWidth { get; private set; }

    int NegHalfHeight => GridHeight % 2 == 1 ? (int)-((GridHeight / 2) + 1) : (int)-(GridHeight / 2); 
    int NegHalfWidth => GridWidth % 2 == 1 ? (int)-((GridWidth / 2) + 1) : (int)-(GridWidth / 2); 

    List<Tile> Tiles;

    public GameBoard(uint gridWidth, uint gridHeight)
    {
        GridHeight = gridHeight;
        GridWidth = gridWidth;
        Tiles = new List<Tile>();
    }

    public void AddTile(Tile tile)
    {
        Tiles.Add(tile);
    }

    public Tile GetTile(int index)
    {
        if (index >= Tiles.Count || index < 0)
        {
            return null;
        }
        return Tiles[index];
    }

    public Tile GetTile(Vector2Int coords)
    {
        return GetTile(GetIndexFromCoords(coords));
    }

    public Vector2Int GetCoordsFromIndex(int index)
    {
        int x = (int)(index % GridWidth) + NegHalfWidth;
        int y = (int)(index / GridWidth) + NegHalfHeight;

        return new Vector2Int(x, y);
    }

    public int GetIndexFromCoords(Vector2Int coords)
    {
        return (coords.y - NegHalfHeight) * (int)GridWidth + (coords.x - NegHalfWidth);
    }

    public Tile GetTileInDir(Vector2Int startCoords, eDir dir)
    {
        Vector2Int coords = startCoords + GetDirAsCoords(dir);
        return GetTile(coords);
    }

    public Tile GetTileInDir(int tileIndex, eDir dir)
    {
        return GetTileInDir(GetCoordsFromIndex(tileIndex), dir);
    }

    Vector2Int GetDirAsCoords(eDir dir)
    {

        Vector2Int output = new Vector2Int();

        if (dir.HasFlag(eDir.Up))
        {
            output.y = 1;
        }
        else if (dir.HasFlag(eDir.Down))
        {
            output.y = -1;
        }

        if (dir.HasFlag(eDir.Right))
        {
            output.x = 1;
        }
        else if (dir.HasFlag(eDir.Left))
        {
            output.x = -1;
        }

        return output;
    }

    public void Destroy()
    {
        Tiles.Clear();
    }
}

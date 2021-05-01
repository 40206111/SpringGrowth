using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard
{
    public uint GridHeight { get; private set; }
    public uint GridWidth { get; private set; }

    List<Tile> Tiles;

    public GameBoard(uint gridHeight, uint gridWidth)
    {
        GridHeight = gridHeight;
        GridWidth = GridWidth;
    }

    public void Destroy()
    {
        foreach (Tile t in Tiles)
        {
            t.IsActive = false;
        }
    }
}

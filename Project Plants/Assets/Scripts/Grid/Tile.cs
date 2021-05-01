using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public enum eLandType
    {
        None = 0,
        Lawn,
        Farm,
        Paving,
        TotalTypes
    }

    public bool IsActive = false;
    public eLandType LandType { get; private set; }

    public Tile(eLandType type)
    {
        LandType = type;
        IsActive = true;
    }
    
}

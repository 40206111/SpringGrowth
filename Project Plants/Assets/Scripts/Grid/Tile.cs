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
    eLandType LandType = eLandType.None;
    
}

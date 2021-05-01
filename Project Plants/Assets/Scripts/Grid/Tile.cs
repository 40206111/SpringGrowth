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

    public int DefaultMoisture;
    public int DefaultNutrients;
    public int DefaultSun;

    public int CurrentMoisture;
    public int CurrentNutrients;
    public int CurrentSun;

    public Tile(eLandType type)
    {
        LandType = type;
        IsActive = true;
        SetTileDetails();
    }

    void SetTileDetails()
    {
        switch (LandType)
        {
            case eLandType.Lawn:
                GameBoardManager.GetInstance.LawnDefaults.CalculateValues(out DefaultMoisture, out DefaultNutrients, out DefaultSun);
                break;
            case eLandType.Farm:
                GameBoardManager.GetInstance.FarmDefaults.CalculateValues(out DefaultMoisture, out DefaultNutrients, out DefaultSun);
                break;
            case eLandType.Paving:
                GameBoardManager.GetInstance.PavingDefaults.CalculateValues(out DefaultMoisture, out DefaultNutrients, out DefaultSun);
                break;
        }
    }
    
}

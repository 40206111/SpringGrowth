using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTileDefaults", menuName = "ProjectPlants/TileDefaultValues")]
public class SOTileDefaults : ScriptableObject
{
    public Vector2Int MoistureRange = new Vector2Int();
    public Vector2Int NutrientsRange = new Vector2Int();
    public Vector2Int SunRange = new Vector2Int();

    public void CalculateValues(out int moisture, out int nutrients, out int sun)
    {
        moisture = Random.Range(MoistureRange.x, MoistureRange.y + 1);
        nutrients = Random.Range(NutrientsRange.x, NutrientsRange.y + 1);
        sun = Random.Range(SunRange.x, SunRange.y + 1);
    }
}

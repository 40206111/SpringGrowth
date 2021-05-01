using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewTileSpriteList", menuName = "ProjectPlants/TileSprites")]
public class SOTileSprites : ScriptableObject
{
    /* List in order of enum
     * None
     * Lawn
     * Farm
     */
    public List<TileBase> TileAesthetic;
}

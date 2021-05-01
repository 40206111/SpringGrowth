using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameBoardManager : MonoBehaviour
{
    [SerializeField]
    Tilemap TheTileMap;
    [SerializeField]
    SOTileSprites TileSprites;

    [HideInInspector]
    public GameBoard Board;

    private void Awake()
    {
        GenerateGameBoard(22, 10);
    }

    void GenerateGameBoard(uint gridWidth, uint gridHeight)
    {
        //Do in coroutine to avoid game hanging
        StartCoroutine(CoGenerateGameBoard(gridWidth, gridHeight));
    }

    IEnumerator<YieldInstruction> CoGenerateGameBoard(uint gridWidth, uint gridHeight)
    {
        Random.InitState((int)Time.time);

        if (Board != null)
        {
            Board.Destroy();
            Board = null;
        }

        Board = new GameBoard(gridWidth, gridHeight);

        int halfWidth = (int)gridWidth / 2;
        int halfheight = (int)gridHeight / 2;

        int negWidth = gridWidth % 2 == 1 ? -(halfWidth + 1) : -halfWidth;
        int negHeight = gridHeight % 2 == 1 ? -(halfheight + 1) : -halfheight;

        int counter = 0;

        for (int x = negWidth; x < halfWidth; x++)
        {
            for (int y = negHeight; y < halfheight; y++)
            {
                int landType = Random.Range(1, (int)(Tile.eLandType.TotalTypes));

                TheTileMap.SetTile(new Vector3Int(x, y, 0), TileSprites.TileAesthetic[landType]);

                counter++;
            }
            yield return null;
        }
    }

}

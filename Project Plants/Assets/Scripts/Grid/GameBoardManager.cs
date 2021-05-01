using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameBoardManager : MonoBehaviour
{
    static GameBoardManager Instance;
    public static GameBoardManager GetInstance
    {
        get
        {
            return Instance;
        }
        private set { }
    }

    [SerializeField]
    Tilemap TheTileMap;
    [SerializeField]
    SOTileSprites TileSprites;

    
    [SerializeField]
    public SOTileDefaults LawnDefaults;
    [SerializeField]
    public SOTileDefaults FarmDefaults;
    [SerializeField]
    public SOTileDefaults PavingDefaults;

    [HideInInspector]
    public GameBoard Board;
    readonly int RandomPadding = 10;

    private void Awake()
    {
        Instance = this;
        GenerateGameBoard(22, 10);
    }

    void GenerateGameBoard(uint gridWidth, uint gridHeight)
    {
        //Do in coroutine to avoid game hanging
        StartCoroutine(CoGenerateGameBoard(gridWidth, gridHeight));
    }

    IEnumerator<YieldInstruction> CoGenerateGameBoard(uint gridWidth, uint gridHeight)
    {
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

        for (int y = negHeight; y < halfheight; y++)
        {
            for (int x = negWidth; x < halfWidth; x++)
            {
                Vector2Int coords = new Vector2Int(x, y);

                Tile left = Board.GetTileInDir(coords, GameBoard.eDir.Left);
                Tile downLeft = Board.GetTileInDir(coords, GameBoard.eDir.DownLeft);
                Tile down = Board.GetTileInDir(coords, GameBoard.eDir.Down);

                List<Tile.eLandType> randomList = new List<Tile.eLandType>();
                if (left != null)
                {
                    for (int i = 0; i < RandomPadding; ++i)
                    {
                        randomList.Add(left.LandType);
                    }
                }
                if (downLeft != null)
                {
                    for (int i = 0; i < RandomPadding; ++i)
                    {
                        randomList.Add(downLeft.LandType);
                    }
                }
                if (down != null)
                {
                    for (int i = 0; i < RandomPadding; ++i)
                    {
                        randomList.Add(down.LandType);
                    }
                }

                //if (randomList.Count == 0)
                {
                    for (int i = 1; i < (int)Tile.eLandType.TotalTypes; i++)
                    {
                        randomList.Add((Tile.eLandType)i);
                    }
                }


                int index = Random.Range(0, randomList.Count);
                Tile.eLandType landType = randomList[index];

                TheTileMap.SetTile(new Vector3Int(x, y, 0), TileSprites.TileAesthetic[(int)landType]);
                Tile newTile = new Tile(landType);
                Board.AddTile(newTile);
            }
            yield return null;
        }
    }

}

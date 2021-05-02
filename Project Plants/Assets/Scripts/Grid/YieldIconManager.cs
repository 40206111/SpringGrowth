using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class YieldIconManager : MonoBehaviour
{
    [SerializeField]
    RectTransform YieldsPrefab;
    [SerializeField]
    RectTransform Container;

    private static YieldIconManager instance = null;
    public static YieldIconManager GetInstance { get { return instance; } }

    Camera GameCamera;
    Vector2Int LastCamPos = new Vector2Int(int.MinValue, int.MaxValue);
    [SerializeField]
    int ActiveRadius;

    bool FullyLoaded = false;
    GameObject[,] Yields;
    List<GameObject> Actives = new List<GameObject>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateYieldIcons());
        GameCamera = Camera.main;
    }


    private void Update()
    {
        if(FullyLoaded && LastCamPos != GetGridPos(GameCamera.transform.position + GameBoardManager.GetInstance.BoardOffset))
        {
            LastCamPos = GetGridPos(GameCamera.transform.position + GameBoardManager.GetInstance.BoardOffset);

            List<GameObject> newActives = new List<GameObject>();
            List<GameObject> stayActives = new List<GameObject>();

            float radius = ActiveRadius + 0.5f;
            float radiusSq = radius * radius;

            for(int y = -ActiveRadius; y <= ActiveRadius; ++y)
            {
                for(int x = -ActiveRadius; x <= ActiveRadius; ++x)
                {
                    if(!InsideGrid(LastCamPos + new Vector2Int(x, y)))
                    {
                        continue;
                    }

                    Vector2Int tileOffset = new Vector2Int(x, y);
                    Vector2Int tilePos = LastCamPos + tileOffset;
                    Vector2Int arrayPos = ArrayFromPosition(tilePos);

                    if (tileOffset.sqrMagnitude > radiusSq)
                    {
                        continue;
                    }

                    if(!Actives.Contains(Yields[arrayPos.x, arrayPos.y]))
                    {
                        newActives.Add(Yields[arrayPos.x, arrayPos.y]);
                    }
                    else
                    {
                        stayActives.Add(Yields[arrayPos.x, arrayPos.y]);
                    }
                }
            }

            List<GameObject> deActives = new List<GameObject>();

            foreach(GameObject go in Actives)
            {
                if (!stayActives.Contains(go))
                {
                    deActives.Add(go);
                }
            }

            foreach (GameObject go in deActives)
            {
                go.SetActive(false);
                Actives.Remove(go);
            }

            foreach(GameObject go in newActives)
            {
                go.SetActive(true);
                Actives.Add(go);
            }
        }
    }

    private bool InsideGrid(Vector2Int pos)
    {
        GameBoard grid = GameBoardManager.GetInstance.Board;
        return pos.x >= grid.MinCorner.x && pos.x <= grid.MaxCorner.x &&
            pos.y >= grid.MinCorner.y && pos.y <= grid.MaxCorner.y;
    }

    private Vector2Int GetGridPos(Vector3 pos)
    {
        return new Vector2Int(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y));
    }

    private IEnumerator CreateYieldIcons()
    {
        while (GameBoardManager.GetInstance == null || !GameBoardManager.GetInstance.BoardFullyLoaded)
        {
            yield return null;
        }

        DateTime lastFrameTime = DateTime.Now;
        double maxTime = 1 / 120.0;

        GameBoard board = GameBoardManager.GetInstance.Board;

        Yields = new GameObject[board.GridWidth, board.GridHeight];


        for (int y = board.MinCorner.y; y <= board.MaxCorner.y; ++y)
        {
            for (int x = board.MinCorner.x; x <= board.MaxCorner.x; ++x)
            {
                if ((DateTime.Now - lastFrameTime).TotalSeconds >= maxTime)
                {
                    yield return null;
                    lastFrameTime = DateTime.Now;
                }

                Vector2Int arrayPos = ArrayFromPosition(new Vector2Int(x, y));
                Yields[arrayPos.x, arrayPos.y] = Instantiate(YieldsPrefab, new Vector3(x, y, 0), Quaternion.identity, Container).gameObject;
            }
        }
        FullyLoaded = true;
    }

    private Vector2Int ArrayFromPosition(Vector2Int pos)
    {
        return new Vector2Int(pos.x - GameBoardManager.GetInstance.Board.MinCorner.x, pos.y - GameBoardManager.GetInstance.Board.MinCorner.y);
    }

    /// Return true if icons are showing.
    public bool ToggleIcons()
    {
        Container.gameObject.SetActive(!Container.gameObject.activeInHierarchy);
        return Container.gameObject.activeInHierarchy;
    }

}

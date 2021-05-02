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



        for (int y = board.MinCorner.y; y <= board.MaxCorner.y; ++y)
        {
            for (int x = board.MinCorner.x; x <= board.MaxCorner.x; ++x)
            {
                if ((DateTime.Now - lastFrameTime).TotalSeconds >= maxTime)
                {
                    yield return null;
                    lastFrameTime = DateTime.Now;
                }

                Instantiate(YieldsPrefab, new Vector3(x, y, 0), Quaternion.identity, Container);
            }
        }
    }

    /// Return true if icons are showing.
    public bool ToggleIcons()
    {
        Container.gameObject.SetActive(!Container.gameObject.activeInHierarchy);
        return Container.gameObject.activeInHierarchy;
    }

}

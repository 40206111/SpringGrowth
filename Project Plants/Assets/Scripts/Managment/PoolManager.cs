using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //Manager
    static PoolManager Instance;
    public static PoolManager GetInstance {
        get
        {
            if (Instance == null)
            {
                Instance = new PoolManager();
            }
            return Instance;
        }
        private set { }
    }

    //Prefabs
    [SerializeField]
    GameObject WeedPrefab;

    //Pools
    List<GameObject> Weeds;

    //Parents
    GameObject WeedParent;

    public void CreateGameBoardPools(int gridWidth, int gridHeight)
    {
        if (Weeds == null)
        {
            Weeds = new List<GameObject>();
        }
        if (WeedParent == null)
        {
            WeedParent = new GameObject("WeedParent");
            WeedParent.transform.parent = transform;
        }

        for (int i = Weeds.Count; i < gridWidth * gridHeight; i++)
        {
            Weeds.Add(Instantiate(WeedPrefab, WeedParent.transform));
            Weeds[Weeds.Count - 1].name = $"Weed_{i}";
        }
    }

}

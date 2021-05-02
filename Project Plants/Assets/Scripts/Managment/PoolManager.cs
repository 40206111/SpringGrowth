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

    public void Awake()
    {
        Instance = this;
    }

    public void CreateGameBoardPools(uint gridWidth, uint gridHeight)
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
            Weeds[Weeds.Count - 1].SetActive(false);
        }
    }

    public GameObject GetWeed()
    {
        foreach (GameObject w in Weeds)
        {
            if (!w.activeSelf)
            {
                return w;
            }
        }

        return null;
    }
}

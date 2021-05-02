using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    [SerializeField]
    Transform Selector;

    FollowMouseSnapGrid SelectorInfo;

    public bool UpgradeOpen = false;

    //Manager
    static GameManagement Instance;
    public static GameManagement GetInstance
    {
        get
        {
            return Instance;
        }
        private set { }
    }

    public void Awake()
    {
        Instance = this;
        SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Tree", LoadSceneMode.Additive);
        SelectorInfo = Selector.GetComponent<FollowMouseSnapGrid>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && SelectorInfo.Plantable)
        {
            if (Player.GetPlayer.Seeds > 0)
            {
                Player.GetPlayer.Seeds--;
                GameObject weed = PoolManager.GetInstance.GetWeed();
                weed.SetActive(true);
                weed.transform.position = Selector.position;
            }
        }
    }

    public enum eStage
    {
        Normal,
        Flowering,
        Seeding,
    }

    public eStage GameStage = eStage.Normal;

    public void NextStage()
    {
        switch (GameStage)
        {
            case eStage.Normal:
                GameStage = eStage.Flowering;
                break;
            case eStage.Flowering:
                GameStage = eStage.Seeding;
                break;
            case eStage.Seeding:
                GameStage = eStage.Normal;
                break;
        }
    }
}

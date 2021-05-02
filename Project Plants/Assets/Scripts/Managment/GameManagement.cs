using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
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

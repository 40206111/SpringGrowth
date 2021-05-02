using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    static Player Instance;
    public static Player GetPlayer
    {
        get
        {
            if (Instance == null)
            {
                Instance = new Player();
            }
            return Instance;
        }
        private set { }
    }

    public int Seeds = 1;
    public int NeededWater = 30;
    public int NeededNutrients = 30;
    public int NeededSun = 30;
    public float SeedingTime = 15;
    public int Money = 0;
    public int MoneyPerSec = 1;
    public float FloweringTime = 15;

    public void Init(int neededWater, int neededNutrients, int neededSun, int seedingTime)
    {
        Seeds = 1;
        NeededWater = neededWater;
        NeededNutrients = neededNutrients;
        NeededSun = neededSun;
        SeedingTime = seedingTime;
    }

}

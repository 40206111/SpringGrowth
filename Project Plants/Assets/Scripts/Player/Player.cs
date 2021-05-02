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

    public enum eUpgrades
    {
        None = 0,
        LongStalk = 1 << 0,
    }

    public eUpgrades Upgrades = eUpgrades.None;

    public int Seeds = 1;
    public int NeededWater = 10;
    public int NeededNutrients = 10;
    public int NeededSun = 10;
    public float SeedingTime = 5;
    public int Money = 0;
    public int MoneyPerSec = 1;
    public float FloweringTime = 5;
    public float TimePlanted = 5;
    public float SeedLife = 10;
    public float WaterPercent = 0.5f;
    public float NutrientsPercent = 0.2f;
    public float SunPercent = 0.6f;

    public void Init(int neededWater, int neededNutrients, int neededSun, int seedingTime)
    {
        Seeds = 1;
        NeededWater = neededWater;
        NeededNutrients = neededNutrients;
        NeededSun = neededSun;
        SeedingTime = seedingTime;
    }

}

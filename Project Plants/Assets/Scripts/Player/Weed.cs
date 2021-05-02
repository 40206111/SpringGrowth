using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weed : MonoBehaviour
{
    enum eState
    {
        Planted,
        Budding,
        Flowering,
        NoSeeds,
        Seeds
    }

    int NeededWater = 30;
    int NeededNutrients = 30;
    int NeededSun = 30;

    float SeedingTime = 30;
    float FloweringTime = 30;
    float TimeInState = 0;

    float seedProduceTime = 3;
    int moneyPerSec = 1;
    float waitedTime = 0;

    eState State = eState.Planted;

    public void Initialise()
    {
        NeededWater = Player.GetPlayer.NeededWater;
        NeededNutrients = Player.GetPlayer.NeededNutrients;
        NeededSun = Player.GetPlayer.NeededSun;
        SeedingTime = Player.GetPlayer.SeedingTime;
        FloweringTime = Player.GetPlayer.FloweringTime;
        moneyPerSec = Player.GetPlayer.MoneyPerSec;
        State = eState.Planted;
    }

    private void OnEnable()
    {
        waitedTime = 0;
        TimeInState = 0;
        Initialise();
    }

    // Update is called once per frame
    void Update()
    {
        if (State == eState.Seeds)
        {
            if (TimeInState >= SeedingTime)
            {
                ChangeState(eState.NoSeeds);
            }

            CalculateSeedProduce();
            if (waitedTime >= seedProduceTime)
            {
                Player.GetPlayer.Seeds += 1;
                waitedTime = 0;
            }
            else
            {
                waitedTime += Time.deltaTime;
            }
        }

        if (State == eState.Flowering)
        {
            if (TimeInState >= FloweringTime)
            {
                return;
            }

            if (waitedTime >= 1)
            {
                Player.GetPlayer.Money += moneyPerSec;
                waitedTime = 0;
            }
            else
            {
                waitedTime += Time.deltaTime;
            }
        }

        TimeInState += Time.deltaTime;
    }

    void ChangeState(eState newState)
    {
        if (newState == State)
        {
            return;
        }

        TimeInState = 0;
        waitedTime = 0;
        State = newState;
    }

    void CalculateSeedProduce()
    {
        Tile tile = GameBoardManager.GetInstance.Board.GetTile(new Vector2Int((int)transform.position.x, (int)transform.position.y));

        int waterDelta = NeededWater - tile.CurrentMoisture;
        int nutrientDelta = NeededNutrients - tile.CurrentNutrients;
        int sunDelta = NeededSun - tile.CurrentSun;

        seedProduceTime = (Mathf.Abs(waterDelta) + Mathf.Abs(nutrientDelta) + Mathf.Abs(sunDelta)) / 2;
    }
}

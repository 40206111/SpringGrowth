using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    [SerializeField]
    TMP_Text ValueField;

    [SerializeField]
    int AbilityCost;

    [SerializeField]
    float Change;

    [SerializeField]
    Button TheButton;

    [SerializeField]
    List<Ability> Dependants;

    public bool Bought = false;

    void Awake()
    {
        ValueField.text = AbilityCost.ToString();
    }

    private void Update()
    {
        if (Player.GetPlayer.Money >= AbilityCost && DependantsUsed() && !Bought)
        {
            TheButton.interactable = true;
        }
        else
        {
            TheButton.interactable = false;
        }
    }

    bool DependantsUsed()
    {
        bool output = true;

        foreach (Ability a in Dependants)
        {
            output &= a.Bought;
        }

        return output;
    }

    public void IncreaseSeedLifeSpan()
    {
        if (Player.GetPlayer.Money < AbilityCost)
        {
            return;
        }

        Player.GetPlayer.Money -= AbilityCost;
        Player.GetPlayer.SeedLife += Change;
    }

    public void DecreaseWater()
    {
        if (Player.GetPlayer.Money < AbilityCost)
        {
            return;
        }

        Player.GetPlayer.Money -= AbilityCost;
        Player.GetPlayer.NeededWater -= (int)Change;
    }


    public void IncreaseMoneyPerSec()
    {
        if (Player.GetPlayer.Money < AbilityCost)
        {
            return;
        }

        Player.GetPlayer.Money -= AbilityCost;
        Player.GetPlayer.MoneyPerSec += (int)Change;
    }


    public void DecreaseNutrients()
    {
        if (Player.GetPlayer.Money < AbilityCost)
        {
            return;
        }

        Player.GetPlayer.Money -= AbilityCost;
        Player.GetPlayer.NeededNutrients -= (int)Change;
    }


    public void DecreaseSun()
    {
        if (Player.GetPlayer.Money < AbilityCost)
        {
            return;
        }

        Player.GetPlayer.Money -= AbilityCost;
        Player.GetPlayer.NeededSun -= (int)Change;
    }


    public void IncreaseSeedingDuration()
    {
        if (Player.GetPlayer.Money < AbilityCost)
        {
            return;
        }

        if (!Player.GetPlayer.Upgrades.HasFlag(Player.eUpgrades.LongStalk))
        {
            Player.GetPlayer.Upgrades |= Player.eUpgrades.LongStalk;
        }
        Player.GetPlayer.Money -= AbilityCost;
        Player.GetPlayer.SeedingTime += Change;
    }


    public void IncreaseFloweringDuration()
    {
        if (Player.GetPlayer.Money < AbilityCost)
        {
            return;
        }

        Player.GetPlayer.Money -= AbilityCost;
        Player.GetPlayer.FloweringTime += Change;
    }

    public void IncreaseWaterPercent()
    {
        if (Player.GetPlayer.Money < AbilityCost)
        {
            return;
        }

        Player.GetPlayer.Money -= AbilityCost;
        Player.GetPlayer.WaterPercent += Change;
        Player.GetPlayer.WaterPercent = Mathf.Clamp01(Player.GetPlayer.WaterPercent);
    }


    public void IncreaseNutrientPercent()
    {
        if (Player.GetPlayer.Money < AbilityCost)
        {
            return;
        }

        Player.GetPlayer.Money -= AbilityCost;
        Player.GetPlayer.NutrientsPercent += Change;
        Player.GetPlayer.NutrientsPercent = Mathf.Clamp01(Player.GetPlayer.NutrientsPercent);
    }


    public void IncreaseSunPercent()
    {
        if (Player.GetPlayer.Money < AbilityCost)
        {
            return;
        }

        Player.GetPlayer.Money -= AbilityCost;
        Player.GetPlayer.SunPercent += Change;
        Player.GetPlayer.SunPercent = Mathf.Clamp01(Player.GetPlayer.SunPercent);
    }

}

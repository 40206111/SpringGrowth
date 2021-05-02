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

        Player.GetPlayer.Money -= AbilityCost;
        Player.GetPlayer.SeedingTime += Change;
    }
}

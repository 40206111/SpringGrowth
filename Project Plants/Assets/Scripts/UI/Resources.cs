using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resources : MonoBehaviour
{
    enum eResource
    {
        Water,
        Nutrients,
        Sun,
        Seeds,
        Money
    }

    [SerializeField]
    eResource trackingResource;

    TMP_Text Text;

    void Awake()
    {
        Text = GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        switch (trackingResource)
        {
            case eResource.Water:
                Text.text = Player.GetPlayer.NeededWater.ToString();
                break;
            case eResource.Nutrients:
                Text.text = Player.GetPlayer.NeededNutrients.ToString();
                break;
            case eResource.Sun:
                Text.text = Player.GetPlayer.NeededSun.ToString();
                break;
            case eResource.Seeds:
                Text.text = Player.GetPlayer.Seeds.ToString();
                break;
            case eResource.Money:
                Text.text = Player.GetPlayer.Money.ToString();
                break;
        }
    }
}

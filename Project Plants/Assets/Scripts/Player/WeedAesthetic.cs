using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedAesthetic : MonoBehaviour
{
    [SerializeField]
    Weed MyWeed;

    [SerializeField]
    Player.eUpgrades RequiredUpgrades;

    [SerializeField]
    Player.eUpgrades IgnoreWhenUpgrade;

    [SerializeField]
    Weed.eState WeedState;

    SpriteRenderer Visual;

    private void Awake()
    {
        Visual = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Visual.enabled)
        {
            if (MyWeed.State != WeedState && WeedState != Weed.eState.None)
            {
                Visual.enabled = false;
                return;
            }

            if (MyWeed.Upgrades.HasFlag(IgnoreWhenUpgrade) && IgnoreWhenUpgrade != Player.eUpgrades.None)
            {
                Visual.enabled = false;
                return;
            }
        }
        else
        {
            if (MyWeed.Upgrades.HasFlag(IgnoreWhenUpgrade) && IgnoreWhenUpgrade != Player.eUpgrades.None)
            {
                return;
            }

            if ((MyWeed.State == WeedState || WeedState == Weed.eState.None) &&
                MyWeed.Upgrades.HasFlag(RequiredUpgrades))
            {
                Visual.enabled = true;
            }

        }
    }
}

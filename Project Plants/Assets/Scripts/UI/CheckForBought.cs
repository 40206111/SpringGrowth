using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForBought : MonoBehaviour
{
    [SerializeField]
    Ability MyAbility;

    CanvasGroup Group;

    private void Awake()
    {
        Group = GetComponent<CanvasGroup>();
    }


    void Update()
    {
        if (MyAbility.Bought)
        {
            Group.alpha = 0.5f;
        }
    }
}

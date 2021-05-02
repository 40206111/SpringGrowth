using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTree : MonoBehaviour
{
    public static CloseTree Instance;
    CanvasGroup Group;


    private void Awake()
    {
        Group = GetComponent<CanvasGroup>();
        HideTree();
        Instance = this;
    }


    public void HideTree()
    {
        GameManagement.GetInstance.UpgradeOpen = false;
        Group.alpha = 0;
        Group.interactable = false;
        Group.blocksRaycasts = false;
    }

    public void ShowTree()
    {
        GameManagement.GetInstance.UpgradeOpen = true;
        Group.alpha = 1;
        Group.interactable = true;
        Group.blocksRaycasts = true;
    }
}

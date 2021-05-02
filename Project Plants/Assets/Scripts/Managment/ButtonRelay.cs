using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRelay : MonoBehaviour
{
    public void ToggleYieldsButtonCall()
    {
        YieldIconManager.GetInstance?.ToggleIcons();
    }

    public void NextStageButtonCall()
    {
        GameManagement.GetInstance?.NextStage();
    }

    public void OpenUpgrades()
    {
        Debug.Log("Show Tree");
        CloseTree.Instance?.ShowTree();
    }
}

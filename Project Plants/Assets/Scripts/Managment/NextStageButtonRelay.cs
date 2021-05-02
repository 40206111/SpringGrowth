using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStageButtonRelay : MonoBehaviour
{
    public void NextStageButtonCall()
    {
        GameManagement.GetInstance.NextStage();
    }
}

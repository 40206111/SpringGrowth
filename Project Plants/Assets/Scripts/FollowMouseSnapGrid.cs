using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseSnapGrid : MonoBehaviour
{
    SpriteRenderer SR;
    public bool Plantable;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos += new Vector3(0.5f, 0.5f, 0);

        pos.x = Mathf.FloorToInt(pos.x);
        pos.y = Mathf.FloorToInt(pos.y);

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);

        Tile tile = GameBoardManager.GetInstance.Board.GetTile(new Vector2Int((int)pos.x, (int)pos.y));

        if (tile == null)
        {
            return;
        }

        int waterDelta = Mathf.Abs(Player.GetPlayer.NeededWater - tile.CurrentMoisture);
        int nutrientsDelta = Mathf.Abs(Player.GetPlayer.NeededNutrients - tile.CurrentNutrients);
        int sunDelta = Mathf.Abs(Player.GetPlayer.NeededSun - tile.CurrentSun);

        float waterPercent = (float)waterDelta / (float)Player.GetPlayer.NeededWater;
        float nutrientsPercent = (float)nutrientsDelta / (float)Player.GetPlayer.NeededNutrients;
        float sunPercent = (float)sunDelta / (float)Player.GetPlayer.NeededSun;

        Plantable = waterPercent >= Player.GetPlayer.WaterPercent && nutrientsPercent >= Player.GetPlayer.NutrientsPercent && sunPercent >= Player.GetPlayer.SunPercent;
        
        SR.color = Plantable ? Color.green : Color.red;

    }
}

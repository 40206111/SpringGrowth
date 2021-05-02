using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileIcons : MonoBehaviour
{

    [SerializeField]
    GameObject Water;
    [SerializeField]
    GameObject Nutrients;
    [SerializeField]
    GameObject Sun;

    TMP_Text WaterText;
    TMP_Text NutrientsText;
    TMP_Text SunText;


    void Awake()
    {
        WaterText = Water.GetComponentInChildren<TMP_Text>();
        NutrientsText = Nutrients.GetComponentInChildren<TMP_Text>();
        SunText = Sun.GetComponentInChildren<TMP_Text>();
    }

    void Start()
    {
        Vector3 pos = transform.position + GameBoardManager.GetInstance.BoardOffset;
        pos.x = Mathf.FloorToInt(pos.x);
        pos.y = Mathf.FloorToInt(pos.y);

        Vector2Int coords = new Vector2Int((int)pos.x, (int)pos.y);

        Tile tile = GameBoardManager.GetInstance.Board.GetTile(coords);
        if (tile == null)
        {
            return;
        }
        WaterText.text = tile.CurrentMoisture.ToString();
        NutrientsText.text = tile.CurrentNutrients.ToString();
        SunText.text = tile.CurrentSun.ToString();

        gameObject.SetActive(false);
    }
}

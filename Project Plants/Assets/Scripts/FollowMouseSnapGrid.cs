using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseSnapGrid : MonoBehaviour
{
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos += new Vector3(0.5f, 0.5f, 0);

        pos.x = Mathf.FloorToInt(pos.x);
        pos.y = Mathf.FloorToInt(pos.y);

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}

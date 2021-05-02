using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    [SerializeField]
    float speed;


    void Update()
    {
        if (GameManagement.GetInstance.UpgradeOpen)
        {
            return;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = transform.position;
            pos.x -= Input.GetAxis("Mouse X") * speed * Time.deltaTime;
            pos.y -= Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
            transform.position = pos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            transform.position = Camera.main.transform.position;
        }
    }
}

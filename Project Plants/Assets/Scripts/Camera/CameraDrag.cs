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

#if UNITY_ANDROID && !UNITYEDITOR
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector3 pos = transform.position;
            pos.x -=  Input.GetTouch(0).deltaPosition.x * speed * Time.deltaTime;
            pos.y -=  Input.GetTouch(0).deltaPosition.y * speed * Time.deltaTime;
            transform.position = pos;
        }

        if (Input.touchCount <= 0)
        {
            transform.position = Camera.main.transform.position;
        }
#else
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
#endif
    }
}

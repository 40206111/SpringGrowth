using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float AndroidSpeed;

    void Update()
    {
        if (GameManagement.GetInstance.UpgradeOpen)
        {
            return;
        }

#if UNITY_ANDROID && !UNITY_EDITOR
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector3 pos = transform.position;
            pos.x -=  Input.GetTouch(0).deltaPosition.x * AndroidSpeed * Time.deltaTime;
            pos.y -=  Input.GetTouch(0).deltaPosition.y * AndroidSpeed * Time.deltaTime;
            transform.position = pos;
        }

        if (Input.touchCount <= 0)
        {
            Vector3 pos = Camera.main.transform.position;
            pos.z = 0;
            transform.position = pos;
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
            Vector3 pos = Camera.main.transform.position;
            pos.z = 0;
            transform.position = pos;
        }
#endif
    }
}

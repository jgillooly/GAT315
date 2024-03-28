using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    Vector3 preaxis = Vector3.zero;
    Vector3 rotation = Vector3.zero;
    [SerializeField] float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        

        preaxis.y = Input.GetAxis("Mouse X");
        preaxis.x = -Input.GetAxis("Mouse Y");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 axis = Vector3.zero;
        axis.y = Input.GetAxis("Mouse X") - preaxis.y;
        axis.x = -Input.GetAxis("Mouse Y") - preaxis.x;

        rotation.x += axis.x * speed;
        rotation.y += axis.y * speed;

        rotation.x = Mathf.Clamp(rotation.x, -40, 40);
        rotation.y = Mathf.Clamp(rotation.y, -40, 40);

        Quaternion qyaw = Quaternion.AngleAxis(rotation.y * speed, Vector3.up);
        Quaternion qpitch = Quaternion.AngleAxis(rotation.x * speed, Vector3.right);
        
        transform.localRotation = (qyaw * qpitch);
    }
}

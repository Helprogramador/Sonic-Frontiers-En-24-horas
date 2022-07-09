using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_control : MonoBehaviour
{   
    public float speedH;
    public float speedV;

    float yaw;
    float pitch = 180.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles= new Vector3(pitch, 0, 180.0f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch += speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles= new Vector3(pitch, yaw, 180f);
    }
}

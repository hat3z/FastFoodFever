
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerLook : MonoBehaviour
{

    public float speedH;
    public float speedV;

    public bool useCursor;

    private float yaw = 0.0f;
    private float pitch = 0.0f;


    private void Start()
    {
        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 0.0f);
    }

    private void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        Cursor.visible = useCursor;

    }

}
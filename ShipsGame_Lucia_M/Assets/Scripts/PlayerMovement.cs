using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;


    public Camera cam;

    public float speed = 2f;
    float speedH;
    float speedV;

    float axisX;
    float axisY;

    private Rigidbody rb;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();

        speedH = speed;
        speedV = speed;
        cam = Camera.main;
    }

    void Update()
    {
        // Movimiento constante hacia adelante
        //rb.AddForce(transform.forward * playerSpeed);

        

        MousePosition();
    }

    public void MousePosition()
    {
        /*axisY += speedH * Input.GetAxis("Mouse X");
        axisX += speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(-axisX, axisY, 90.0f);*/

        /*Vector3 direction = Input.mousePosition - cam.WorldToScreenPoint(transform.position);
        float angulo = Vector3.SignedAngle(Vector3.up, direction, Vector3.zero);
        transform.rotation = (Quaternion.AngleAxis(angulo, Vector3.forward));*/
    }
}



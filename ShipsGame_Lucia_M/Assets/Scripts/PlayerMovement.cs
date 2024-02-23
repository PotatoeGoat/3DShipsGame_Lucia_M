using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;


    public float speed = 2f;
    float speedH;
    float speedV;

    

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        speedH = speed;
        speedV = speed;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Movimiento constante hacia adelante
        rb.velocity = transform.forward * playerSpeed; 
        

        MousePosition();
    }

    public void MousePosition()
    {
        //rotar hacia la posición del ratón
        float h = speedH * Input.GetAxis("Mouse X");
        float v = speedV * Input.GetAxis("Mouse Y");

        transform.Rotate(-v, h, 0);
    }
}



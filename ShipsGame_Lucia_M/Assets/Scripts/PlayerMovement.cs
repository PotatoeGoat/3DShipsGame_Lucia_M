using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    float minPlayerSpeed = 10f;

    public float speed = 2f;
    float speedH;
    float speedV;

    //acelerar

    public float maxPlayerSpeed = 50f;
    public float acelerationSpeed = 100f;
    float desacelerationSpeed;
    public float desacelerationIndex = 4f;


    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        speedH = speed;
        speedV = speed;

        desacelerationSpeed = acelerationSpeed / desacelerationIndex;
    }

    void Update()
    {
        MousePosition();

        PlayerMovements();

        //Debug.Log(playerSpeed);


    }

    public void MousePosition()
    {
        //rotar hacia la posición del ratón
        float h = speedH * Input.GetAxis("Mouse X");
        float v = speedV * Input.GetAxis("Mouse Y");

        transform.Rotate(-v, h, 0f);
    }

    public void PlayerMovements()
    {
        // Movimiento constante hacia adelante
        rb.velocity = transform.forward * playerSpeed;

        //mecanica para acelerar y desacelerar
        if (Input.GetKey("w"))
        {
            // acelera
            playerSpeed += acelerationSpeed * Time.deltaTime;
        }
        else 
        {
            // en cuanto se deja de apretar la w, empieza a desacelerar hasta llegar al minimo
            playerSpeed -= desacelerationSpeed * Time.deltaTime;
        }

        // mantener el player speed dentro del rango permitido, min y max
        //Mathf.Clamp(value, min, max)
        playerSpeed = Mathf.Clamp(playerSpeed, minPlayerSpeed, maxPlayerSpeed);

    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    float minPlayerSpeed = 5f;

    public float speed = 2f;
    float speedH;
    float speedV;

    //acelerar

    public float maxPlayerSpeed = 20f;
    bool applyAceleration = false;

    public float acelerationSpeed = 4f;
    

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        speedH = speed;
        speedV = speed;

        applyAceleration = false;
        

    }

    void Update()
    {
        MousePosition();

        PlayerMovements();

        Debug.Log(playerSpeed);


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

        if (Input.GetKeyDown("w"))
        {
            applyAceleration = true;
            if (applyAceleration == true)
            {
                playerSpeed += (acelerationSpeed * Time.deltaTime);
            }

        }

        if (Input.GetKeyUp("w"))
        {
            playerSpeed -= (acelerationSpeed * Time.deltaTime);
            applyAceleration = false;

            if (playerSpeed >= maxPlayerSpeed)
            {
                playerSpeed = minPlayerSpeed;
            }
        }

    }
}



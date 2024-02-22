using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float rotationSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento constante hacia adelante
        rb.AddForce(transform.forward * forwardSpeed);

        // Obtener la posición del puntero del ratón en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Ajustar la Z para que coincida con la nave

        // Calcular la dirección hacia el puntero del ratón desde la posición de la nave
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Calcular la rotación hacia la dirección del puntero del ratón
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Rotar suavemente hacia la dirección del puntero del ratón
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

/*public float initialSpeed = 5f; // Velocidad inicial
    public float maxSpeed = 10f; // Velocidad máxima
    public float acceleration = 2f; // Aceleración
    public float deceleration = 5f; // Deceleración

    private Rigidbody rb;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = initialSpeed;
    }

    void Update()
    {
        // Acelerar progresivamente si se presiona la tecla W o la flecha hacia arriba
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
        }
        else // Decelerar progresivamente si no se presiona la tecla
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, initialSpeed, deceleration * Time.deltaTime);
        }

        // Mover la nave hacia adelante con la velocidad actual
        rb.velocity = transform.forward * currentSpeed;

        // Obtener la posición del puntero del ratón en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Ajustar la Z para que coincida con la nave

        // Calcular la dirección hacia el puntero del ratón desde la posición de la nave
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Calcular la rotación hacia la dirección del puntero del ratón
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Rotar suavemente hacia la dirección del puntero del ratón
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);*/

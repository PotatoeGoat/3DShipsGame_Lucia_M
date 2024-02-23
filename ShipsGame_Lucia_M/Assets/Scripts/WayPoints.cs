using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    //creo un array que contenga los puntos que quiero que sigan los enemigos
    public Transform[] waypoints;

    //creo una variable para la velocidad de estos enemigos
    public float enemySpeed = 20f;

    //variable para saber a que punto se dirige el enemigo actualmente
    private int currentWaypointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        // El enemigo se mueve al siguiente punto
        //posición actual = función que sirve para mover un objeto desde su posición actual hasta una determinada, a cierta velocidad (Vector3.MoveTowards): (posición actual, punto de destino, velocidad)
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, enemySpeed * Time.deltaTime);

        // Calculo si la distancia entre el punto actual y el siguiente punto es menor de 0.1

        //funcion que calcula la distancia entre dos puntos(Vector3.Distance): (posición actual del enemigo, posición del siguiente punto del array) < 0.1
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // Pasar al siguiente punto, le sumamos 1 a la variable que lleva la cuenta y el operador % controla que el limite siempre se mantenga dentro del array 
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

            // Hacer que el objeto mire hacia el siguiente punto, diciendo si el siguiente punto es menor que la longitud del array, entonces: haz esto
            if (currentWaypointIndex < waypoints.Length)
            {
                transform.LookAt(waypoints[currentWaypointIndex]);
            }
            else
            {
                transform.LookAt(waypoints[0]);
            }
        }
    }
}

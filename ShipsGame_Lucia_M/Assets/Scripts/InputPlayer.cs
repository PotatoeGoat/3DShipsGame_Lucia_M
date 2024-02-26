using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    BulletPool pool;

    public float bulletSpeed = 200f;

    float timeToShoot = 0.1f; // Tiempo entre cada disparo
    float timeSinceLastBullet = 0f; // Tiempo pasado desde el último disparo

    // Start is called before the first frame update
    void Awake()
    {
        pool = GetComponent<BulletPool>();
    }

    // Update is called once per frame
    void Update()
    {
        // Contar el tiempo transcurrido
        timeSinceLastBullet += Time.deltaTime;

        // Si el tiempo transcurrido es mayor a el tiempo propuesto y se presiona la tecla space
        if (timeSinceLastBullet >= timeToShoot && Input.GetKey("space"))
        {
            Shoot(); //Disparar
            timeSinceLastBullet = 0f; // Para reiniciar el tiempo
        }
    }

    void Shoot()
    {
        GameObject bullet = pool.GetBullet();

        if (bullet != null) // Verificar si se obtuvo una bala de la pool
        {
            Debug.Log("disparo");

            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        }
    }
}



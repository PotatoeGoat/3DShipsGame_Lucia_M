using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    // Prefab de la bala
    public GameObject bulletPrefab;

    // Número de balas en la pool
    public int poolSize = 50;

    // Lista de balas de la pool
    private Stack<GameObject> pool;

    public static BulletPool Instance;

    private void Awake()
    {
        //configurar singletone
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);

        }

    }
        void Start()
    {
        SetupPool();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void SetupPool()
    {
        //Inicializar la pool
        pool = new Stack<GameObject>();
        GameObject bullet = null;

        // Instanciar y desactivar todas las balas al inicio
        for (int i = 0; i < poolSize; i++)
        {
            bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            pool.Push(bullet);
        }
    }

    public GameObject GetBullet()
    {
        //si no hay balas

        GameObject newbullet = null;

        if (pool.Count == 0)
        {
            GameObject createdBullet = Instantiate(bulletPrefab);
            return createdBullet;
        }
        else //coger una de las ya creadas
        {
            newbullet = pool.Pop();
            newbullet.SetActive(true);
        }

        return newbullet;
    }

    public void ReturnBullet(GameObject returnedBullet)
    {
        //lo metemos en la pool otra vez
        pool.Push(returnedBullet);

        //hacemos que no se vea
        returnedBullet.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsPool : MonoBehaviour
{
    // Prefab del powerup
    public GameObject powerupPrefab;

    // Número de powerups en la pool
    public int powerUpPoolSize = 50;

    // Lista de powerups de la pool
    private Stack<GameObject> powerUpPool;

    public static PowerUpsPool powerUpInstance;

    private void Awake()
    {
        //configurar singletone
        if (powerUpInstance == null)
        {
            powerUpInstance = this;
        }
        else
        {
            Destroy(this.gameObject);

        }

    }
    void Start()
    {
        SetupPowerUpPool();
    }


    // Update is called once per frame
    void Update()
    {

    }

    void SetupPowerUpPool()
    {
        //Inicializar la pool
        powerUpPool = new Stack<GameObject>();
        GameObject bullet = null;

        // Instanciar y desactivarlos al inicio
        for (int i = 0; i < powerUpPoolSize; i++)
        {
            bullet = Instantiate(powerupPrefab);
            bullet.SetActive(false);
            powerUpPool.Push(bullet);
        }
    }

    public GameObject GetPowerUp()
    {
        //si no hay poerups

        GameObject newpowerup = null;

        if (powerUpPool.Count == 0)
        {
            GameObject createdPowerUp = Instantiate(powerupPrefab);
            return createdPowerUp;
        }
        else //coger uno de los ya creados
        {
            newpowerup = powerUpPool.Pop();
            newpowerup.SetActive(true);
        }

        return newpowerup;
    }

    public void ReturnPowerUp(GameObject returnedPowerUp)
    {
        //lo metemos en la pool otra vez
        powerUpPool.Push(returnedPowerUp);

        //hacemos que no se vea
        returnedPowerUp.SetActive(false);
    }
}


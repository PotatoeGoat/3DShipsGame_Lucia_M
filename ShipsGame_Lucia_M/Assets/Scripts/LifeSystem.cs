using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeSystem : MonoBehaviour
{

    public int lifePoints = 10;

    public int bulletDamage = 10;
    public int terrainDamage;

    public string deathCause1 = "bullet";
    public string deathCause2 = "bullet";

    public bool playerDie = false;


    public ActivateExplosion activatingExplosion;

    // Start is called before the first frame update
    void Start()
    {
        terrainDamage = bulletDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void DestroyEnemies(int damageCause)
    {
        lifePoints -= damageCause;
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == deathCause1)
        {
            DestroyEnemies(bulletDamage);

            if (lifePoints <= 0)
            {

                this.gameObject.SetActive(false);

                playerDie = true;

                activatingExplosion.ActivateExplosions();

                Debug.Log("muerto");
            }

            
        }

        if (collision.gameObject.tag == deathCause2)
        {
            DestroyEnemies(terrainDamage);

            if (lifePoints <= 0)
            {

                this.gameObject.SetActive(false);

                playerDie = true;
                activatingExplosion.ActivateExplosions();
                Debug.Log("muerto");
            }


        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{

    public int lifePoints = 10;

    public int bulletDamage = 10;

    public string deathCause = "bullet";

    //bool gameRestart = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyEnemies();
    }

    

    public void DestroyEnemies()
    {
        lifePoints -= bulletDamage;

        //this.gameObject.SetActive(false);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == deathCause)
        {
            if (lifePoints <= 0)
            {

                this.gameObject.SetActive(false);

                //gameRestart = true;

                Debug.Log("muerto");
            }
        }

       
    }
}

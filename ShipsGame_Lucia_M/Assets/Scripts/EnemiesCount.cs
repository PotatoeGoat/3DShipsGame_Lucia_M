using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCount : MonoBehaviour
{

    [SerializeField] GameObject nave1, nave2, nave3;
    public int enemiesCount = 3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShipsCount();
        Debug.Log(enemiesCount);
    }

    void ShipsCount()
    {
        enemiesCount--;
        CheckEnemies();
        Debug.Log("auch");
    }

    public void CheckEnemies()
    {
        if (enemiesCount == 0)
        {
            nave1.SetActive(false);
        }
        if (enemiesCount == 1)
        {
            nave2.SetActive(false);
        }
        if (enemiesCount == 2)
        {
            nave3.SetActive(false);
        }
    }
}

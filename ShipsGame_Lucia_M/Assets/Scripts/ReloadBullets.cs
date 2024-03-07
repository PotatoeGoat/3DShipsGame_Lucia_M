using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReloadBullets : MonoBehaviour
{
    //EXAMEN

    public string reloadingText = "RELOADING...";
    [SerializeField] TextMeshProUGUI chamberedBullets;

    public InputPlayer inputPlayer;

    public float timeToReload = 1f;
    public float timeToReloadAfterShooting = 2f;
    float timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if (inputPlayer.reloading == true)
        {
            UpdateShowBullets();
            
            if (inputPlayer.getKeySpace == true)
            {
                timer += Time.deltaTime;
                if (timer >= timeToReloadAfterShooting)
                {
                    
                    ReloadBullet();
                    
                    timer = 0;
                }
            }

            if (inputPlayer.getKeyE == true)
            {
                UpdateShowBullets();
                timer += Time.deltaTime;
                if (timer >= timeToReload)
                {
                    ReloadBullet();
                    
                    timer = 0;
                }
            }


            

        }
        else
        {
            
            UpdateShowBullets();
        }
    }

    void UpdateShowBullets()
    {
        if (inputPlayer.reloading == true)
        {
            chamberedBullets.text = reloadingText;
            
        }
        else if (inputPlayer.reloading == false)
        {
            chamberedBullets.text = (inputPlayer.shootedBullets + "/" + inputPlayer.initialBullets);
        }
        
    }

    void ReloadBullet()
    {
        inputPlayer.shootedBullets = inputPlayer.initialBullets;
        Debug.Log("Reloading");
        inputPlayer.reloading = false;
    }
}

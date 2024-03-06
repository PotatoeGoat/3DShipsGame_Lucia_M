using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SkipCinematic : MonoBehaviour
{
    public PlayableDirector timelinedirector;

    public GameObject canvasButton;

    public GameObject CinematicShip, CinematicEnemyShips, EnemyShips;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkipCinematics()
    {
        timelinedirector.Stop();
        canvasButton.SetActive(false);
        CinematicEnemyShips.SetActive(false);
        CinematicShip.SetActive(false);
        EnemyShips.SetActive(true);
        timelinedirector.gameObject.SetActive(false);
        
    }
}

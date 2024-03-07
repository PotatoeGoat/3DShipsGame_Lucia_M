using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public float countdownTime = 3;
    float timer = 0f;
    float oneSec = 1f;

    
    public TextMeshProUGUI countdownText;

    public GameObject countdownScreen;

    public LifeSystem lifeSystem;

    public PlayerMovement playerMovement;

    public GameObject player;
    public GameObject EndGameCanvas;

    public int enemiesCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        
        countdownScreen.SetActive(false);
        countdownText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeSystem.playerDie == true)
        {
            countdownScreen.SetActive(true);
            countdownText.gameObject.SetActive(true);
            timer += Time.deltaTime;
            if (timer >= oneSec)
            {
                timer -= 1f;
                countdownTime--;
                UpdateCountDown();
            }
        }

        if(enemiesCount <= 2)
        {
            EndGameCanvas.SetActive(true);
            playerMovement.enabled = false;

            player.SetActive(false);
            
        }
        
    }

   

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void UpdateCountDown()
    {


        if (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
        }
        else
        {
            
            RestartGame();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public EnemyX myScript;
    public FollowPlayer2 startCheck;
    public Button startButton;
    public Button hardModeButton;
    public EnemyPoint myEnemy;
    public EnemyPoint2 myEnemy2;
    public EnemyPoint3 myEnemy3;
    public AudioSource lightFx;
    void Start()
    {


    }

    void Update()
    {
        RestartButton();
        startButton.onClick.AddListener(StartGame);
        hardModeButton.onClick.AddListener(HardMode);

    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        
        startCheck.isGameActive = true;
        if(startCheck.isGameActive == true)
        {
            startButton.gameObject.SetActive(false);
            hardModeButton.gameObject.SetActive(false);
        }
    }

    public void HardMode()
    {
        myEnemy.speed =+ 200;
        myEnemy2.speed =+ 200;
        myEnemy3.speed =+ 200;

        startCheck.isGameActive = true;
        if (startCheck.isGameActive == true)
        {
            startButton.gameObject.SetActive(false);
            hardModeButton.gameObject.SetActive(false);
        }
    }

    public void RestartButton()
    {
        if (myScript.score == 1)
        {
            restartButton.gameObject.SetActive(true);
        }
        if (myScript.scoreEnemy == 1)
        {
            restartButton.gameObject.SetActive(true);
        }
    }
}

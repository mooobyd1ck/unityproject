using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyX : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreEnemyText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winnerText;
    public int score;
    private int updateScoreValue;
    public int scoreEnemy;
    public FollowPlayer2 playerControl;
  

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreEnemy = 0;
        gameOverText.gameObject.SetActive(false);
        winnerText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       
        UpdateScore(updateScoreValue);
        UpdateScoreEnemy(updateScoreValue);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Maing"))
        {
            UpdateScore(1);
            Debug.Log("Ebal");
            Destroy(gameObject);
            winnerText.gameObject.SetActive(true);
            playerControl.isGameActive = false;
            
        }

        if (other.gameObject.CompareTag("Maing1"))
        {
            Destroy(gameObject);
            UpdateScoreEnemy(1);
            gameOverText.gameObject.SetActive(true);
            playerControl.isGameActive = false;
        }
        if (other.gameObject.CompareTag("Maing3"))

        {
            Destroy(gameObject);
            UpdateScore(1);
            winnerText.gameObject.SetActive(true);
            playerControl.isGameActive = false;
        }
        if (other.gameObject.CompareTag("Main4"))
        {
            
            Destroy(gameObject);
            UpdateScore(1);
            winnerText.gameObject.SetActive(true);
            playerControl.isGameActive = false;
        }
    }
 

    void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    void UpdateScoreEnemy(int scoreEnemyToAdd)
    {
        scoreEnemy += scoreEnemyToAdd;
        scoreEnemyText.text = "Enemy Score: " + scoreEnemy;
    }
}

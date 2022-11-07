using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    private Vector3[] spawnPosition = new Vector3[2];
    [SerializeField] private Button endGameButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private FollowPlayer2 startCheck;
    [SerializeField] private Button startButton;
    [SerializeField] private Button hardModeButton;
    [SerializeField] private EnemyPoint myEnemy;
    [SerializeField] private EnemyPoint2 myEnemy2;
    [SerializeField] private EnemyPoint3 myEnemy3;
    [SerializeField] private AudioSource lightFx;
    [SerializeField] private Transform ball;
    [SerializeField] public Transform spawnedBall;
    [SerializeField] private GameObject ballon;
    [SerializeField] private FollowPlayer2 followPlayer;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreEnemyText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI winnerText;
    [SerializeField] private AudioSource winSound;
    public int score;
    public int updateScoreValue;
    public int scoreEnemy;
    private bool isWork = false;
    private float force = 60f;


    void Start()
    {
        winnerText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        score = 0;
        scoreEnemy = 0;
    }

    void FixedUpdate()
    {
        CreateFirstBall();
        UpdateScore(updateScoreValue);
        UpdateScoreEnemy(updateScoreValue);
        endGamesButton();
        startButton.onClick.AddListener(StartGame);
        hardModeButton.onClick.AddListener(HardMode);
        
    }

    private void CreateFirstBall()
    {
        if (isWork)
        {
            CreateBall();
            isWork = false;
        }

    }
    public void CreateBall()
    {
            ball = ballon.transform;
            spawnedBall = Instantiate(ball.transform, GenerateSpawnPosition(), Quaternion.identity);
            UseOfForce();
        
    }
    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void UseOfForce()
    {
     /* this code not working right
    Vector3 gektor = GenerateSpawnPosition();
    if (gektor == spawnPosition[0] || gektor == spawnPosition[1])
     */
         Vector3 posMove = new Vector3(50, 5, -40);
         Rigidbody ballRigidbody = spawnedBall.GetComponent<Rigidbody>();
         ballRigidbody.AddForce(posMove * force * Time.deltaTime, ForceMode.Impulse);
       
    }
   
    public void StartGame()
    { 
        startCheck.isGameActive = true;
        if(startCheck.isGameActive == true)
        {
            startButton.gameObject.SetActive(false);
            hardModeButton.gameObject.SetActive(false);
        }
            isWork = true;
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
            isWork = true;
    }
    Vector3 GenerateSpawnPosition()
    {
        float xPositionBallFirst = -50f;
        float yPositionBallFirst = 3f;
        float zPositionBallFirst = 69f;

        float xPositionBallSecond = 53f;
        float yPositionBallSecond = 3f;
        float zPositionBallSecond = -35f;

        Vector3 positionBallFirst = new Vector3(xPositionBallFirst, yPositionBallFirst, zPositionBallFirst);
        Vector3 positionBallSecond = new Vector3(xPositionBallSecond, yPositionBallSecond, zPositionBallSecond);
        spawnPosition[0] = positionBallFirst;
        spawnPosition[1] = positionBallSecond;

       // this spawns not working right :(
      /*  float xPositionBallThird = 50f;
        float yPositionBallThird = 3f;
        float zPositionBallThird = 60f;
        float xPositionBallFourth = -59f;
        float yPositionBallFourth = 3f;
        float zPositionBallFourth = -50f;
        Vector3 positionBallThird = new Vector3(xPositionBallThird, yPositionBallThird, zPositionBallThird);
        Vector3 positionBallFourth = new Vector3(xPositionBallFourth, yPositionBallFourth, zPositionBallFourth);
        spawnPosition[2] = positionBallThird;
        spawnPosition[3] = positionBallFourth;
       */
       
        return spawnPosition[Random.Range(0, spawnPosition.Length)];
 
    }
    

   public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
   public void UpdateScoreEnemy(int scoreEnemyToAdd)
    {
        scoreEnemy += scoreEnemyToAdd;
        scoreEnemyText.text = "Enemy Score: " + scoreEnemy;
    }
    public void endGamesButton()
    {
        if (score == 5)
        {
            winSound.gameObject.SetActive(true);
            winnerText.gameObject.SetActive(true);
            endGameButton.gameObject.SetActive(true);
            followPlayer.isGameActive = false;
            
        }   
        if (scoreEnemy == 5)
        {
            gameOverText.gameObject.SetActive(true);
            endGameButton.gameObject.SetActive(true);
            followPlayer.isGameActive = false;
        }
    }

}

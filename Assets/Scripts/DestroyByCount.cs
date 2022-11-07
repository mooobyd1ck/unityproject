using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DestroyByCount : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource getBallPoint;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball") && gameObject.CompareTag("Maing4"))
        {
            Destroy(other.gameObject);
            gameManager.UpdateScore(1);
            SpawnCondition();
            getBallPoint.Play();
        }
        if (other.gameObject.CompareTag("Ball") && gameObject.CompareTag("Maing3"))
        {
            Destroy(other.gameObject);
            gameManager.UpdateScore(1);
            SpawnCondition();
            getBallPoint.Play();
        }
        if (other.gameObject.CompareTag("Ball") && gameObject.CompareTag("Maing1"))
        {
            Destroy(other.gameObject);
            gameManager.UpdateScore(1);
            SpawnCondition();
            getBallPoint.Play();
        }
        if (other.gameObject.CompareTag("Ball") && gameObject.CompareTag("Maing"))
        {
            Destroy(other.gameObject);
            gameManager.UpdateScoreEnemy(1);
            SpawnCondition();
            getBallPoint.Play();
        }
    }
    
   private void SpawnCondition()
    {   
        if(gameManager.score != 5 && gameManager.scoreEnemy != 5)
        {
          gameManager.CreateBall();
        }   
    }
   
}
 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint2 : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource soundHit;
    [SerializeField] private GameObject keepHolding;
    [SerializeField] private GameObject myEnemy;
    private float stoppingDistance = 70;
    private float force = 5500f;
    public float speed = 140;
   
    void LateUpdate()
    {
        EnemyWalk2();
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Vector3 dir = gameManager.spawnedBall.position - transform.position;

        if (gameManager.spawnedBall)
        {
            soundHit.Play();
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force * Time.deltaTime;
        }
    }

    void EnemyWalk2()
    {

        float rangeX = Mathf.Clamp(transform.position.x, -65f, -65f);
        float rangeY = Mathf.Clamp(transform.position.y, 3.5f, 3.5f);
        float rangeZ = Mathf.Clamp(transform.position.z, -30, 63);

        myEnemy.transform.position = new Vector3(rangeX, rangeY, rangeZ);

        if (Vector3.Distance(keepHolding.transform.position, gameManager.spawnedBall.position) < stoppingDistance)
        {
            myEnemy.transform.position = Vector3.MoveTowards(myEnemy.transform.position, gameManager.spawnedBall.position, speed * Time.deltaTime);
        }
    }
}

    

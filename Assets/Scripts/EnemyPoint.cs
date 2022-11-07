using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    [SerializeField] public GameObject keepHolding;
    [SerializeField] public GameObject myEnemy;
    [SerializeField] public GameManager gameManager;
    [SerializeField] public AudioSource soundHit;
    private float stoppingDistance = 70;
    private float force = 5500f;
    public float speed = 140;
    // Update is called once per frame
    void LateUpdate()
    {
        EnemyWalk();
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 dir = gameManager.spawnedBall.position - transform.position;

        if (gameManager.spawnedBall)
        {
            soundHit.Play();
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force * Time.deltaTime;
        }

    }
    
    void EnemyWalk()
    {
        float rangeX = Mathf.Clamp(transform.position.x, -41, 46.5f);
        float rangeY = Mathf.Clamp(transform.position.y, 3.5f, 3.5f);
        float rangeZ = Mathf.Clamp(transform.position.z, -54.5f, -54.5f);

        myEnemy.transform.position = new Vector3(rangeX, rangeY, rangeZ);

        if (Vector3.Distance(keepHolding.transform.position, gameManager.spawnedBall.position) < stoppingDistance)
        {
            myEnemy.transform.position = Vector3.MoveTowards(myEnemy.transform.position, gameManager.spawnedBall.position, speed * Time.deltaTime);
        }

    }

}

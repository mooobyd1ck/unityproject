using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint2 : MonoBehaviour
{
    
    public float speed = 140;
    private Transform ball;
    public GameObject keepHolding;
    public GameObject myEnemy;
    private float stoppingDistance = 70;
    private float force = 5000f;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }
    void FixedUpdate()
    {
        EnemyWalk2();
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Vector3 dir = ball.position - transform.position;
        if (ball)
        {
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force * Time.deltaTime;
        }
    }

    void EnemyWalk2()
    {

        float rangeX = Mathf.Clamp(transform.position.x, -72, -72);
        float rangeY = Mathf.Clamp(transform.position.y, 5, 5);
        float rangeZ = Mathf.Clamp(transform.position.z, -40, 65);

        myEnemy.transform.position = new Vector3(rangeX, rangeY, rangeZ);

        if (Vector3.Distance(keepHolding.transform.position, ball.position) < stoppingDistance)
        {
            myEnemy.transform.position = Vector3.MoveTowards(myEnemy.transform.position, ball.position, speed * Time.deltaTime);
        }
    }
}

    

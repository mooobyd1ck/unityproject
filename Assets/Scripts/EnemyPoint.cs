using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{

    public float speed = 140;
    public Transform ball;
    private float stoppingDistance = 70;
    private float force = 5000f;
    public GameObject keepHolding;
    public GameObject myEnemy;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyWalk();
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 dir = ball.position - transform.position;
       
        if (ball)
        {
            other.GetComponent<Rigidbody>().velocity = dir.normalized * force * Time.deltaTime ;
        }
       
    }

    void EnemyWalk()
    {
        float rangeX = Mathf.Clamp(transform.position.x, -50, 65);
        float rangeY = Mathf.Clamp(transform.position.y, 5, 5);
        float rangeZ = Mathf.Clamp(transform.position.z, -58, -58);

        myEnemy.transform.position = new Vector3(rangeX, rangeY, rangeZ);

        if (Vector3.Distance(keepHolding.transform.position, ball.position) < stoppingDistance)
        {
            myEnemy.transform.position = Vector3.MoveTowards(myEnemy.transform.position, ball.position, speed * Time.deltaTime);
        }

    }
  
}

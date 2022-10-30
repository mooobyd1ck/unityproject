using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FollowPlayer2 : MonoBehaviour
{
    private float horizontalInput;
    private float xRange = 50;
    private float speed = 50f;
    private float turbospeed = 60f;
    private float myForceBall = 4000;
    private float radius = 40;
    public bool isGameActive;
    private Rigidbody myForce;
    public AudioSource lightFx;
    public ParticleSystem explosionParticle;
    
    void Start()
    {
        isGameActive = false;
    }

  
    void Update()
    {
        if(isGameActive == true)
        {
            PlayerControls();
        }

    }

    public void PlayerControls()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.right * Time.deltaTime * turbospeed * horizontalInput);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            lightFx.Play();
            BamBam();
        }
    }
    private void BamBam()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, radius);

        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            myForce = overlappedColliders[i].attachedRigidbody;

            if (myForce)
            {
                myForce.AddExplosionForce(myForceBall, transform.position, radius);
            }
        }

        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }

   
}

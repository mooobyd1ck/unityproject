using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowPlayer2 : MonoBehaviour
{
    private float horizontalInput;
    private float xRange = 42f;
    private float zRange = 85.5f;
    private float yRange = 3.5f;
    private float dopRange = 4f;
    private float speed = 70f;
    private float turbospeed = 60f;
    private float myForceBall = 5500;
    private float radius = 40;
    private Rigidbody myForce;
    [SerializeField] private AudioSource lightFx;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] public GameManager gameManager;
    [SerializeField] private AudioSource soundHit;
    private float forceTouch = 3f;
    private float currentTime = 0;
    private float timerTime = 4f;
    private bool reloadIsGameActive = false;
    private bool reloadIsNonActive = true;
    public bool isGameActive;
    void Start()
    {
        currentTime = timerTime;
        isGameActive = false;
    }

    void Update()
    {
        GameActiveControllers();
        Debug.Log(currentTime);
    }

    private void GameActiveControllers()
    {
        if (isGameActive == true)
        {
            PlayerControls();
            Explosion();
            
        }

        if (reloadIsGameActive == true)
        {
            StartCoroutine(startTimer());
        }
    }
    public void PlayerControls()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, yRange, zRange);
        }
        if (transform.position.x > (xRange + dopRange))
        {
            transform.position = new Vector3(xRange + dopRange, yRange, zRange);
        }
        transform.Translate(Vector3.right *  horizontalInput * Time.deltaTime * speed);

        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.right * Time.deltaTime * turbospeed * horizontalInput);
        }

    }

    private void Explosion()
    {
        //Если кнопка нажата, то происходит перезарядка в 4 секунды и потом кнопка становится активной
        if (reloadIsNonActive == true)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                reloadIsGameActive = true;
                if (reloadIsGameActive == true)
                {
                    lightFx.Play();
                    BamBam();
                    reloadIsNonActive = false;
                }
            }
        }
    }
    IEnumerator startTimer()
    {
        //Timer for reload
        currentTime -= 1 * Time.deltaTime;
        if (currentTime <= 0)
        {
            reloadIsNonActive = true;
            if (reloadIsNonActive == true)
            {
                currentTime = 4;
            }
            reloadIsGameActive = false;
        }
        if (currentTime <= 0) {
            yield break;
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            soundHit.Play();
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * forceTouch, ForceMode.Impulse);
        }
    }
}

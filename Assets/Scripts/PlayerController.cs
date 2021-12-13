using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
    
{
    public GameObject bullet;
    public Transform[] firePoints = new Transform[1];
    public float fireRate;
    public static int score;
    public Text scoreDisplay;

    private float nextFire;
    private Rigidbody playerRD;
    private float speed = 160.0f;
    private float zBound = 20;


    // Start is called before the first frame update
    void Start()
    {
        playerRD = GetComponent<Rigidbody>();
        nextFire = 1 / fireRate;
     
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();

    }



    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRD.AddForce(Vector3.forward * speed * verticalInput);
        playerRD.AddForce(Vector3.right * speed * horizontalInput);

        // Input controlls

        bool fireButton = Input.GetButton("Fire1");

        //Egnore sips collider

        Collider[] shipColliders = transform.GetComponentsInChildren<Collider>();
        /// Fire Mechanics
        if (fireButton)
        {
            nextFire -= Time.fixedDeltaTime;
            if (nextFire <= 0)
            {
                for (int i = 0; i < 1; i++)
                {
                    GameObject bulletClone = Instantiate(bullet, firePoints[i].position, Quaternion.Euler(0, 0, 0));

                    for (int x = 0; x < shipColliders.Length; x++)
                    {
                        Physics.IgnoreCollision(bulletClone.transform.GetComponent<Collider>(), shipColliders[x]);
                    }
                    nextFire += 1 / fireRate;
                }
            }
        }
    }

    void ConstrainPlayerPosition()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);

        }
       

    }
    //
        

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Rock"))
        {
            Debug.Log("Player has collided with rock");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Health"))
        {
            Destroy(other.gameObject);
        }
    }

  

}

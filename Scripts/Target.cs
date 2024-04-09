using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb; 
    private GameManager gameManager;

    private float minSpeed = 12.0f;
    private float maxSpeed = 17.0f;
    private float maxTorque = 10.0f;
    private float xSpawnPos = 4.0f;
    private float ySpawnPos = -2.0f;

    public ParticleSystem explosionParticle;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(AddForceToObject(), ForceMode.Impulse);
        targetRb.AddTorque(AddTorqueToObject(), AddTorqueToObject(), AddTorqueToObject(), ForceMode.Impulse);

        transform.position = SpawnPosition();

        


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
            
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    Vector3 AddForceToObject()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float AddTorqueToObject()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 SpawnPosition()
    {
        return new Vector3(Random.Range(-xSpawnPos, xSpawnPos), ySpawnPos);

    }
}

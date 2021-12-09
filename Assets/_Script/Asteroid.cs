using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class Asteroid : MonoBehaviour
{
    public float Rotation;
    public float minSpeed, maxSpeed,ScoreCounter;


    public GameObject asteroidExplosion;
    public GameObject PlayerExpolosion;

    public GameControllerScript GameController;


    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();

        Rigidbody asteroid = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * Rotation;
        asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameArea")
        {
            return;
        } if (other.gameObject.tag == "Player")
        {
            Instantiate(PlayerExpolosion, other.gameObject.transform.position, Quaternion.identity);

        }
        if (other.gameObject.tag == "Enemy")
        {
            return;
        }
        if (other.gameObject.tag == "Laser")
        {
            Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
            GameController.ScoreIncerase(10);

        }


        Destroy(other.gameObject);
        Destroy(gameObject);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

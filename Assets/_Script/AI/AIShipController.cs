using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class AIShipController : MonoBehaviour
{

    public float minSpeed, maxSpeed, ScoreCounter, minShootDel, maxShootDel;

    private float NextShot;


    public GameObject asteroidExplosion;
    public GameObject PlayerExpolosion;


    private Vector3 Way;

    public GameObject Laser;

    public Transform Gun;

    public GameControllerScript GameController;

    private int SelectedWaypoint;


    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();

        Rigidbody EnemyShip = GetComponent<Rigidbody>();

        SelectWayPoint();


    }

    // Update is called once per frame
    void Update()
    {
        Gun.transform.LookAt(Way);
        transform.LookAt(Way);
        transform.position = Vector3.MoveTowards(transform.position, Way, Time.deltaTime * Random.Range(minSpeed, maxSpeed));


        Shoot();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameArea")
        {
            return;
        } if (other.gameObject.tag == "EnemyShot")
        {
            return;
        }
        if (other.gameObject.tag == "Enemy")
        {
            return;
        }
        if (other.gameObject.tag == "Player")
        {
            Instantiate(PlayerExpolosion, other.gameObject.transform.position, Quaternion.identity);
            //GameController.DeathScreen();
        }
        if (other.gameObject.tag == "Laser")
        {
            GameController.ScoreIncerase(30);
            Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        }
        //  if (other.gameObject.tag != "Player")
        //{
        //  
        // }


        Destroy(other.gameObject);
        Destroy(gameObject);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    private void SelectWayPoint()
    {
        SelectedWaypoint = Random.Range(1, 6);


        switch (SelectedWaypoint)
        {
            case 1:
                Way = GameObject.Find("WP1").transform.position;
                break;

            case 2:
                Way = GameObject.Find("WP2").transform.position;
                break;

            case 3:
                Way = GameObject.Find("WP3").transform.position;
                break;
            case 4:
                Way = GameObject.Find("WP4").transform.position;
                break;
            case 5:
                Way = GameObject.Find("WP5").transform.position;
                break;
            case 6:
                Way = GameObject.Find("WP6").transform.position;
                break;

        }
        return;
    }

    private void Shoot()
    {
        if (Time.time >= NextShot)
        {
            Instantiate(Laser, Gun.position, Quaternion.identity);

            NextShot = Time.time + Random.Range(minShootDel, maxShootDel);
        }

    }

    

}

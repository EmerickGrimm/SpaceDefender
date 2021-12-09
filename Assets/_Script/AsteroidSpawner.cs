using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float asterMinDelay, asterMaxDelay,shipMaxDelay,shipMinDelay,shipLaunhcTime;
    public float spawnShipScore;
    private float nextLaunch;

    public GameObject Asteroid;
    public GameObject EnemyShip;
    public GameControllerScript GameController;
    public GameObject PlayScreen;

    private void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextLaunch)
        {
            float xPos = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            float yPos = transform.position.y;
            float zPos = transform.position.z;

            Instantiate(Asteroid, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            nextLaunch = Time.time + Random.Range(asterMinDelay, asterMaxDelay);
        }

        if (GameController.scoreCounter >= spawnShipScore)
        {
            
            _enemyShipSpawner();
        }
        
    }
   void _enemyShipSpawner()
   {

        asterMinDelay = (asterMinDelay + 1);
        asterMaxDelay = (asterMaxDelay + 1);

        shipMinDelay = (shipMinDelay - 1);
        shipMaxDelay = (shipMaxDelay - 1);

        if (shipMinDelay <= 1)
        {
            shipMinDelay = 1;
        } if (shipMaxDelay <= 1)
        {
            shipMaxDelay = 1;
        }

        if (Time.time > shipLaunhcTime)
        {

            float Xpos = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            float Ypos = transform.position.y;
            float Zpos = transform.position.z;

            Instantiate(EnemyShip, new Vector3(Xpos, Ypos, Zpos), Quaternion.identity);

            shipLaunhcTime = Time.time + Random.Range(shipMinDelay, shipMaxDelay);


        }
    }


}

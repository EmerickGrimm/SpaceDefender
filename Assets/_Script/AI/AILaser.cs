using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILaser : MonoBehaviour
{
    public float speed;
    public GameObject PlayerExpolosion, asteroidExplosion;
   // public GameControllerScript GameController;

    // Start is called before the first frame update
    void Start()
    {
       // GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
        GetComponent<Rigidbody>().velocity = Vector3.back * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameArea")
        {
            return;
        }
        if (other.gameObject.tag == "EnemyShot")
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


        Destroy(other.gameObject);
        Destroy(gameObject);

    }

   

}

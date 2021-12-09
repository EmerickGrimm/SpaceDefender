using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, tilt, xMin, xMax, zMin, zMax, shotDelay;

    public GameObject Explosion;
    public GameObject Laser;
    public Transform Gun,Gun2;
    private float nextShot;

    public AudioClip Blaster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Rigidbody Player = GetComponent<Rigidbody>();

        Player.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        Player.rotation = Quaternion.Euler(Player.velocity.z * tilt, 0, -Player.velocity.x * tilt);

        float xPosition = Mathf.Clamp(Player.position.x, xMin, xMax);
        float zPostion = Mathf.Clamp(Player.position.z, zMin, zMax);
        Player.position = new Vector3(xPosition, 0, zPostion);

        if (Time.time > nextShot && Input.GetButtonDown("Fire1"))
        {
            //Blaster.isReadyToPlay
            Instantiate(Laser, Gun.position, Quaternion.identity);
            //Instantiate(Laser, Gun2.position, Quaternion.identity);
            nextShot = Time.time + shotDelay;
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameArea")
        {
            return;
        }if (other.gameObject.tag == "Laser")
        {
            return;
        }
        //Debug.Log(other.gameObject.name + "Hited Player")
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

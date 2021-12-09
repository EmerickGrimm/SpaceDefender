using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerDeath : MonoBehaviour
{
    public GameControllerScript GameController;

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }

    private void OnDestroy()
    {
        GameController.DeathScreen();
    }
}

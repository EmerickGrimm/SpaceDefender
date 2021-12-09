using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControllerScript : MonoBehaviour
{
    public AsteroidSpawner AsteroidSpawner;

    public AIShipController AIShipController;

    public AILaser AILaser;

    public GameObject Player, Score,PlayScreen,DSobject,HighScoreObject,PauseScene;

    public Transform PlayerSpawnPoint;

    public Text DeathScore,HighScoreText;

    public int scoreCounter = 0;
    public int pauseCD,highScore, DefaultHighScore = 10;
    public bool inPauseMenu = false, newHighScore = false;

    private string ScoreKey = "ScoreKey2";

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(highScore);
        unPauseGame();
        LoadPlayerData();
        SpawnObjects();
        ScoreZero();
        SpawnerReset();

    }

    private void Update()
    {
       

        if (Input.GetButtonDown("Cancel"))
        {

            if (inPauseMenu == true)
            {
                unPauseGame();
            }
            if (inPauseMenu == false)
            {
                PauseGame();
            }
        }
    }
    public void ScoreIncerase(int increment)
    {
        scoreCounter += increment;
        Score.GetComponent<UnityEngine.UI.Text>().text = ("Score: " + scoreCounter);
        // Update is called once per frame
    }

   public void PauseGame()
    {
        PauseScene.SetActive(true);
        inPauseMenu = true;
        Time.timeScale = 0f;
        
    }
    public void unPauseGame()
    {
        PauseScene.SetActive(false);
        inPauseMenu = false;
        Time.timeScale = 1f;
        
    }

    public void DeathScreen()
    {
       
        PlayScreen.SetActive(false);
        LoadPlayerData();
        HighScoreManager();
        Debug.Log(highScore);
        Debug.Log(newHighScore);
        DeathScore.GetComponent<UnityEngine.UI.Text>().text = ("Score: " + scoreCounter);
        DSobject.SetActive(true);
        

        if (newHighScore == true)
        {
            HighScoreObject.SetActive(true);
            HighScoreText.GetComponent<UnityEngine.UI.Text>().text = ("Highest: " + highScore);
        }
        else HighScoreObject.SetActive(false);
    }

    public void Restart()
    {

        // DestroyAllEnemy();

        ReloadScene();

        SpawnerReset();

        ScoreZero();

        SpawnObjects();

        return;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SpawnerReset()
    {
        AsteroidSpawner.asterMinDelay = 1;
        AsteroidSpawner.asterMaxDelay = 2;
        AsteroidSpawner.shipMaxDelay = 5;
        AsteroidSpawner.shipMinDelay = 4;

    }

    public void ScoreZero()
    {
        scoreCounter = 0;
        Score.GetComponent<UnityEngine.UI.Text>().text = ("Score: " + scoreCounter);
    }

    public void SpawnObjects()
    {
        PlayScreen.SetActive(true);
        DSobject.SetActive(false);
        Instantiate(Player, PlayerSpawnPoint.position, Quaternion.identity);
        return;
    }


        

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    public void SavePlayerData()
    {

        PlayerPrefs.SetInt(ScoreKey, highScore);
        PlayerPrefs.Save();
    }

    public void LoadPlayerData()
    {
        highScore = PlayerPrefs.GetInt(ScoreKey);
    }

    public void HighScoreManager()
    {
        if (scoreCounter >= highScore && scoreCounter >= DefaultHighScore)
        {
            highScore = scoreCounter;
            SavePlayerData();
            HighScoreText.GetComponent<UnityEngine.UI.Text>().text = ("New Highest Score!");
        }
        else
        {
            LoadPlayerData();
            HighScoreText.GetComponent<UnityEngine.UI.Text>().text = ("Highest: " + highScore);
        }
        
    }


}

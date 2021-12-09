using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    public GameObject Credits, Menu, Env, Settings;
    public AudioMixer Mixer;
    public float p_volume, volume, empty;

    public bool p_isFullScreen, isFullScreen = true;

    private string FullScreenKey = "FsKey", VolumeKey = "VKey";
    private int FS_Int;

    private void Start()
    {
        empty = Random.Range(0, 100);
        LoadSettings();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        SaveSettings();
    }

    public void ShowCredits()
    {
        Menu.SetActive(false);
        Credits.SetActive(true);
        Env.SetActive(false);
    }

    public void OpenSettings()
    {
        if (Menu != null)
        {
            Menu.SetActive(false);
        }
        Settings.SetActive(true);
        Credits.SetActive(false);
        Env.SetActive(false);
        LoadSettings();
    }

    public void CloseCredtis()
    {
        Menu.SetActive(true);
        Settings.SetActive(false);
        Credits.SetActive(false);
        Env.SetActive(true);

        SaveSettings();
    }
    public void SetVolume(float p_volume)
    {
        volume = p_volume;
        Mixer.SetFloat("GlobalVolume", p_volume);
    }

    /*
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    */

    public void SetFullScreen(bool p_isFullScreen)
    {
        isFullScreen = p_isFullScreen;
        Screen.fullScreen = p_isFullScreen;
    }

    public void bool_to_int()
    {
        if (isFullScreen == true)
        {
            FS_Int = 1;
        }
        else
        {
            FS_Int = 0;
        }

    }

    public void int_to_bool()
    {
        if (FS_Int == 1)
        {
            isFullScreen = true;
        }
        else
        {
            isFullScreen = false;
        }


    }


    public void SaveSettings()
    {



        PlayerPrefs.SetFloat(VolumeKey, volume);


        bool_to_int();

        PlayerPrefs.SetInt(FullScreenKey, FS_Int);

        PlayerPrefs.Save();

    }

    public void LoadSettings()
    {
        //volume
        volume = PlayerPrefs.GetFloat(VolumeKey);

        Mixer.SetFloat("GlobalVolume", volume);

        p_volume = volume;

        //FullScreen
        PlayerPrefs.GetInt(FullScreenKey);
        int_to_bool();

        p_isFullScreen = isFullScreen;
        Screen.fullScreen = isFullScreen;


    }
}

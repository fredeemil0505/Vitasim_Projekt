using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class MenuScripts : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool IsTutorial = false;
    public AudioMixer audioMixer;
    public GameObject PauseMenu;
    
    private void Update()
    {
        if (GameIsPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }
    //Pauses time and activates pausemenu
    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    //Resumes time and deativates pausemenu
    void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    //Loads scene based on name given.
    public void PlayScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    //loads scene with tutorial
    public void PlaySceneWithTutorial(string name)
    {
        IsTutorial = true;
        SceneManager.LoadScene(name);
    }

    //Quits the application.S
    public void QuitGame()
    {
        Application.Quit();
    }

    //Sets the volume to the same value as a slider.
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    //Cnhanges the quality settings.
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}

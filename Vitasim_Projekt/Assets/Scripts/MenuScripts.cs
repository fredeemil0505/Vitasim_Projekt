using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuScripts : MonoBehaviour
{
    [SerializeField] public AudioMixer audioMixer;
    [SerializeField] public GameObject MainMenu;
    [SerializeField] public GameObject WinnerMenu;

    public static bool IsTutorial = true;
    public static bool isWinner = false;
    public static MenuScripts menuScripts;

    private void Start()
    {
        menuScripts = this;
    }
    //Loads scene based on name given.
    public void PlayScene(string name)
    {
        SceneManager.LoadScene(name);
        if (name == "Menu" && isWinner == true)
        {
            MainMenu.SetActive(false);
            WinnerMenu.SetActive(true);
        }
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

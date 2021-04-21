﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuScripts : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static bool IsTutorial = false;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopButtonTrigger : MonoBehaviour
{
    public static float timeSpent;
    public static bool winner = false;
    //When a controller hits the button it will set running to false and stop palying a sound.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameController")
        {
            DrillScripts.Running = false;
            if (DrillScripts.Percentage == 100)
            {
                winner = true;
                SceneManager.LoadScene("Menu");
                timeSpent = DrillScripts.startTime - Time.fixedTime;
            }
        }

    }
}

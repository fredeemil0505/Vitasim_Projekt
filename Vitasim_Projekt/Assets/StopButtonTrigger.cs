using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButtonTrigger : MonoBehaviour
{
    //When a controller hits the button it will set running to false and stop palying a sound.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameController")
        {
            Debug.Log("Stopping");
            DrillScripts.Running = false;
        }

    }
}

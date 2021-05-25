using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButtonTrigger : MonoBehaviour
{
    //When a controller hits the button it will set running to false and stop palying a sound.
    public void OnPress()
    {
       
            DrillScripts.Running = false;
            if (DrillScripts.Percentage == 100)
            {
                MenuScripts.isWinner = true;
                MenuScripts.menuScripts.PlayScene("Menu");
            }
        
    }
}

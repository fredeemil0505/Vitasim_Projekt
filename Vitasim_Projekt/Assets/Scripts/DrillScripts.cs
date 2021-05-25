using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class DrillScripts : MonoBehaviour
{
    public static bool Running = false;
    public static int Percentage;
    static int amount = 0;
    static bool firstdrill = true;
    [SerializeField]
    public Text percentagebar;
    public int numberOfHoles;
    public Text message;

    
    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "drill" && Running == true && OnselectedScript.GrabbedObject == null)
        {
            this.gameObject.SetActive(false);
            if (firstdrill == true)
            {
                message.CrossFadeAlpha(1, 0.0f, false);
                message.text = "When you drill the holes, the progressbar in the top right cornor will go up";
                message.color = new Color(0, 255, 0, 1);
                message.CrossFadeAlpha(0, 3.0f, false);
                firstdrill = false;
            }
            //Sets the % amount to the UI overlay
            amount++;
            Percentage = ((100 / numberOfHoles) * amount);
              percentagebar.text = Percentage.ToString() +"%";
        }
        else
        {
            if (other.gameObject.tag == "drill")
            {
if (Running == false && OnselectedScript.GrabbedObject != null)
            {
                    message.CrossFadeAlpha(1, 0.0f, false);
                    message.text = "Let go of the object and turn the machine on before drilling";
                message.color = new Color(255, 0, 0, 1);
                    message.CrossFadeAlpha(0, 3.0f, false);
            }
            else
            {
                if (Running == false)
                {
                        message.CrossFadeAlpha(1, 0.0f, false);
                        message.text = "Turn On Machine before drilling";
                    message.color = new Color(255, 0, 0, 1);
                    message.CrossFadeAlpha(0, 3.0f, false);
                }
                if (OnselectedScript.GrabbedObject != null)
                {
                        message.CrossFadeAlpha(1, 0.0f, false);
                        message.text = "Let go of the object before drilling";
                    message.color = new Color(255, 0, 0, 1);
                    message.CrossFadeAlpha(0, 3.0f, false);
                }
            }
            }
            
            
        }
        
    }

}

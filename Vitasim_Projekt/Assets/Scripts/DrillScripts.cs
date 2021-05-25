using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class DrillScripts : MonoBehaviour
{
    public static bool Running = false;
    public static float Percentage;
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
            
            if (firstdrill == true && MenuScripts.IsTutorial && TextScripts.guideStage == 4)
            {
                TextScripts.ChangeText(new Color(0, 255, 0, 1), 1, 0, "When you drill the holes, the progressbar in the top right cornor will go up", message);
                TextScripts.currentMessage = "When you drill the holes, the progressbar in the top right cornor will go up";
                firstdrill = false;
                TextScripts.guideStage = 5;
            }
            //Sets the % amount to the UI overlay
            amount++;
            Percentage = ((100 / numberOfHoles) * amount);
            if (amount == numberOfHoles)
            {
                Percentage = 100;
            }
              percentagebar.text = Percentage.ToString() +"%";
        }
        else
        {
            if (other.gameObject.tag == "drill")
            {
if (Running == false && OnselectedScript.GrabbedObject != null)
            {
                   StartCoroutine(TextChanger2(message));
            }
            else
            {
                if (Running == false)
                {
                       StartCoroutine(TextChanger3(message));
                }
                if (OnselectedScript.GrabbedObject != null)
                {
                      StartCoroutine(TextChanger4(message));
                }
            }
            }
            
            
        }
        
    }
    public IEnumerator TextChanger2(Text message)
    {

        TextScripts.ChangeText(new Color(255, 0, 0, 1), 1, 0, "Let go of the object and turn the machine on before drilling", message);
        message.CrossFadeAlpha(0, 3.0f, false);
        yield return new WaitForSeconds(3);
        TextScripts.ChangeText(new Color(255, 255, 255, 1), 1, 0, TextScripts.currentMessage, message);
    }
    public IEnumerator TextChanger3(Text message)
    {
        TextScripts.ChangeText(new Color(255, 0, 0, 1), 1, 0, "Turn On Machine before drilling", message);
        message.CrossFadeAlpha(0, 3.0f, false);
        yield return new WaitForSeconds(3);
        TextScripts.ChangeText(new Color(255, 255, 255, 1), 1, 0, TextScripts.currentMessage, message);
    }
    public IEnumerator TextChanger4(Text message)
    {
        TextScripts.ChangeText(new Color(255, 0, 0, 1), 1, 0, "Let go of the object before drilling", message);
        message.CrossFadeAlpha(0, 3.0f, false);
        yield return new WaitForSeconds(3);
        TextScripts.ChangeText(new Color(255, 255, 255, 1), 1, 0, TextScripts.currentMessage, message);
    }


}

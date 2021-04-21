using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrillScripts : MonoBehaviour
{
    public static bool Running = false;
    static int amount = 0;
    static bool firstdrill = true;
    public static int Percentage = 0;
    [SerializeField]
    public Text percentagebar;
    public int numberOfHoles;
    public Text message;

    //Changes the message depending on wether or not the player drilled a hole or made a mistake.
    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "drill" && Running == true && OnselectedScript.GrabbedObject == null)
        {
            this.gameObject.SetActive(false);
            if (firstdrill == true && MenuScripts.IsTutorial == true)
            {
                StartCoroutine(TextChanger(4, "Firstdrill"));
                TextScripts.guideStage = 5;
                firstdrill = false;
            }
            //Sets the % amount to the UI overlay
            amount++;
            Percentage = 100/numberOfHoles*amount;
            percentagebar.text = Percentage.ToString()+"%";
        }
        else if(MenuScripts.IsTutorial == true)
        {
            if (other.gameObject.tag == "drill")
            {
if (Running == false && OnselectedScript.GrabbedObject != null)
            {
                    StartCoroutine(TextChanger(4, "Grab&&False"));
            }
            else
            {
                if (Running == false)
                {
                        StartCoroutine(TextChanger(4, "False"));
                }
                if (OnselectedScript.GrabbedObject != null)
                {
                        StartCoroutine(TextChanger(4, "Grab"));
                }
            }
            }
            
            
        }
        
    }
    private IEnumerator TextChanger(float waitTime, string Occasion)
    {
        if (Occasion == "Firstdrill")
        {
            TextScripts.ChangeText(new Color(0, 255, 0, 1), 1, 0, "When you drill the holes, the progressbar in the top right cornor will go up", message);
            TextScripts.ChangeText(new Color(0, 255, 0, 1), 0, 2, "", message);
            yield return new WaitForSeconds(2);
            TextScripts.ChangeText(new Color(255, 255, 255, 1),1, 0, "Keep drilling until the progressbar reaches 100%", message);
            TextScripts.currentMessage = "Keep drilling until the progressbar reaches 100%";
        }
        if (Occasion == "Grab&&False")
        {
            TextScripts.ChangeText(new Color(255, 0, 0, 1), 1, 0, "Let go of the object and turn the machine on before drilling", message);
            TextScripts.ChangeText(new Color(255, 0, 0, 1), 0, 2, "", message);
            yield return new WaitForSeconds(2);
            TextScripts.ChangeText(new Color(255, 255, 255, 1), 1, 0,TextScripts.currentMessage, message);

        }
        if (Occasion == "False")
        {
            TextScripts.ChangeText(new Color(255, 0, 0, 1), 1, 0, "Turn On Machine before drilling", message);
            TextScripts.ChangeText(new Color(255, 0, 0, 1), 0, 2, "", message);
            yield return new WaitForSeconds(2);
            TextScripts.ChangeText(new Color(255, 255, 255, 1), 1, 0, TextScripts.currentMessage, message);

        }
        if (Occasion == "Grab")
        {
            TextScripts.ChangeText(new Color(255, 0, 0, 1), 1, 0, "Let go of the object before drilling", message);
            TextScripts.ChangeText(new Color(255, 0, 0, 1), 0, 2, "", message);
            yield return new WaitForSeconds(2);
            TextScripts.ChangeText(new Color(255, 255, 255, 1), 1, 0, TextScripts.currentMessage, message);
        }
    }

}

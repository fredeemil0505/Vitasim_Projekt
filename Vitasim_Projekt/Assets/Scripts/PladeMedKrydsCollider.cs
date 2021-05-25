using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PladeMedKrydsCollider : MonoBehaviour
{
    static bool firstTrigger = true;
    [SerializeField]
    public Text text;
    //changes the message text the first time the script triggers and conditions are me
    //public void OnGrab()
    //{
    //    if (TextScripts.guideStage == 2 && firstTrigger == true)
    //    {
    //        StartCoroutine(TextChanger(4));
    //        TextScripts.guideStage = 3;
    //        firstTrigger = false;
    //    }
    //}
    ////used to fade/change color/text
    //private IEnumerator TextChanger(float waittime)
    //{
    //    TextScripts.ChangeText(new Color(0, 255, 0, 1), 0, 4, "", text);
    //    yield return new WaitForSeconds(waittime);
    //    TextScripts.ChangeText(new Color(255, 255, 255, 1), 1, 0, "when you have arranged the drillplate, grap the Machine handle", text);
    //    TextScripts.currentMessage = "when you have arranged the drillplate, grap the Machine handle";
    //}
}

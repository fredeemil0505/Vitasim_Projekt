using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnselectedScript : MonoBehaviour
{
    static bool firstTrigger = true;
    [SerializeField]
    public Text text;
    public static GameObject GrabbedObject;
   public void Onselect()
   {
GrabbedObject = this.gameObject;
        Debug.Log("Enter");
        if (TextScripts.guideStage == 2 && firstTrigger == true && MenuScripts.IsTutorial)
        {
            StartCoroutine(TextChanger(4));
            TextScripts.guideStage = 3;
            firstTrigger = false;
        }
    }
    public void OnSelectExited()
    {
        
        GrabbedObject = null;
        if (GrabbedObject == null)
        {
            Debug.Log("Null");
        }
        else
            Debug.Log("Exit");
    }
    //used to fade/change color/text
    private IEnumerator TextChanger(float waittime)
    {
        TextScripts.ChangeText(new Color(0, 255, 0, 1), 0, 4, "", text);
        yield return new WaitForSeconds(waittime);
        TextScripts.ChangeText(new Color(255, 255, 255, 1), 1, 0, "when you have arranged the drillplate, grap the Machine handle", text);
        TextScripts.currentMessage = "when you have arranged the drillplate, grap the Machine handle";
    }

}

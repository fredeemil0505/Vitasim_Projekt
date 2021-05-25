using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleTextCollider : MonoBehaviour
{
    static bool firstTrigger = true;
    [SerializeField]
    public Text text;
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (firstTrigger == true && TextScripts.guideStage >=2)
    //    {
    //        StartCoroutine(TextChanger(4));
    //        TextScripts.guideStage = 4;
    //        firstTrigger = false;
    //    }
    //}

    public void OnGrab()
    {
        if (firstTrigger == true && TextScripts.guideStage == 3)
        {
            StartCoroutine(TextChanger(4));
            TextScripts.guideStage = 4;
            firstTrigger = false;
        }
    }
    private IEnumerator TextChanger(float waitTime)
    {
        Debug.Log("HandleTextCol");
        TextScripts.ChangeText(new Color(0, 255, 0, 1), 0, 4, "", text);
        yield return new WaitForSeconds(waitTime);
        TextScripts.ChangeText(new Color(255, 255, 255, 1), 1, 0, "Turn the handle to change the height of the drillhead, until you hit a drillspot", text);
        TextScripts.currentMessage = "Turn the handle to change the height of the drillhead, until you hit a drillspot";
    }
}

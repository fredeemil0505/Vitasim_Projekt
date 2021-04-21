using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTrigger : MonoBehaviour
{
    static bool FirstTrigger = true;
    [SerializeField]
    public Text text;
    //When a controller hits the button it will set running to true and start palying a sound.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (FirstTrigger == true && TextScripts.guideStage == 1 && MenuScripts.IsTutorial == true)
            {
                StartCoroutine(TextChanger(4));
                FirstTrigger = false;
                TextScripts.guideStage = 2;
            }
            
            DrillScripts.Running = true;
        }
        
    }
    private IEnumerator TextChanger(float waitTime)
    {
        TextScripts.ChangeText(new Color(0, 255, 0, 1), 0, 4, "", text);
        yield return new WaitForSeconds(waitTime);
        TextScripts.ChangeText(new Color(255, 255, 255, 1), 1, 0, "Grab the drillplate and arrange the drilspots under the drillhead", text);
        TextScripts.currentMessage = "Grab the drillplate and arrange the drilspots under the drillhead";
    }
}

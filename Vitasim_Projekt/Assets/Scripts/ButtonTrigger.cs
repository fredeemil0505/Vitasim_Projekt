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
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "GameController")
    //    {
    //        if (FirstTrigger == true && TextScripts.guideStage < 2)
    //        {
    //            text.color = new Color(0, 255, 0, 1);
            
    //            text.CrossFadeAlpha(0, 4, false);
            
    //            text.text = "Arrange the drilspots under the drillhead and grab the handle";
            
    //            text.color = new Color(255, 255, 255, 1);
            
    //            text.CrossFadeAlpha(1, 0, false);
                
    //            FirstTrigger = false;
    //        }
            
    //        DrillScripts.Running = true;
    //    }
        
    //}

    public void OnPress()
    {
        Debug.Log("Motherq");
            if (FirstTrigger == true && TextScripts.guideStage < 2 && MenuScripts.IsTutorial)
            {
            StartCoroutine(TextChanger());
            FirstTrigger = false;
            TextScripts.guideStage = 2;
            }

            DrillScripts.Running = true;
    }
    private IEnumerator TextChanger()
    {
        TextScripts.ChangeText(new Color(0, 255, 0, 1), 0, 4, "", text);
        yield return new WaitForSeconds(4);
        TextScripts.ChangeText(new Color(255, 255, 255, 1), 1, 0, "Arrange the drilspots under the drillhead and grab the handle", text);
        TextScripts.currentMessage = "Arrange the drilspots under the drillhead and grab the handle";
    }
}

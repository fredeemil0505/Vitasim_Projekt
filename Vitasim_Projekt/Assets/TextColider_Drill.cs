using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColider_Drill : MonoBehaviour
{
    static bool FirstTrigger = true;
    [SerializeField]
    public Text text;
    private void OnTriggerEnter(Collider other)
    {
        if (FirstTrigger == true && other.gameObject.tag == "Player")
        {
            StartCoroutine(Textboxcollider(4.1f));
            FirstTrigger = false;

            TextScripts.guideStage = 1;
            
        }
        
    }
    private IEnumerator Textboxcollider(float waittime)
    {
        TextScripts.ChangeText(new Color(0, 255, 0, 1), 0, 4f, "", text);
        yield return new WaitForSeconds(waittime);
        TextScripts.ChangeText(new Color(255, 255, 255, 1), 1, 0f, "Turn on the machine before drilling", text);
        TextScripts.currentMessage = "Turn on the machine before drilling";


    }
    
}

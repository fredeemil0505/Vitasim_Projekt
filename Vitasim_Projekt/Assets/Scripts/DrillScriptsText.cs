using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrillScriptsText : MonoBehaviour
{
    public void Heyho(Text text)
    {
        StartCoroutine(TextChanger(text));
    }
        public IEnumerator TextChanger2(Text message)
        {
        
            TextScripts.ChangeText(new Color(255, 0, 0, 1), 1, 0, "Let go of the object and turn the machine on before drilling", message);
            message.CrossFadeAlpha(0, 3.0f, false);
            yield return new WaitForSeconds(3);
            TextScripts.ChangeText(new Color(255, 255, 255, 1), 1, 0, TextScripts.currentMessage, message);
        }
        public IEnumerator TextChanger(Text message)
        {
        Debug.Log("Hmmmmmm");
            TextScripts.ChangeText(new Color(0, 255, 0, 1), 0, 4, "", message);
            yield return new WaitForSeconds(4);
            TextScripts.ChangeText(new Color(255, 255, 255, 1), 1, 0, "When you drill the holes, the progressbar in the top right cornor will go up", message);
            TextScripts.currentMessage = "When you drill the holes, the progressbar in the top right cornor will go up";
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

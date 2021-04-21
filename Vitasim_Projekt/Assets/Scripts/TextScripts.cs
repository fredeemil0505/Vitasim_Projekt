using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScripts : MonoBehaviour
{
    //Used for cheching how far the player has come in the tutorial
    static public int guideStage = 0;
    public static string currentMessage = "";
    //Used to change a text i varius  ways. and also plays a sound depending on the text color
    public static void ChangeText(Color a, int alpha, float waittime, string message, Text textobject)
    {
        SoundController sound = new SoundController();
        if (a == new Color(0, 255, 0, 1))
        {
            sound.PlayAudioClip(true);
        }
        if (a == new Color(255, 0, 0, 1))
        {
            sound.PlayAudioClip(false);
        }
        else
        {

        }
        textobject.color = a;
        if (message == "")
        { }
        else
        { textobject.text = message; }
        textobject.CrossFadeAlpha(alpha, waittime, false);

    }
}

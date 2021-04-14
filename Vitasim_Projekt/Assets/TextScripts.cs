using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScripts : MonoBehaviour
{
    //Used for cheching how far the player has come in the tutorial
    static public int guideStage = 0;
    public static string currentMessage = "";
    //Used to change a text i varius  ways.
    public static void ChangeText(Color a, int alpha, float waittime, string message, Text textobject)
    {

        textobject.color = a;
        if (message == "")
        {}
        else
        {textobject.text = message;}
        textobject.CrossFadeAlpha(alpha, waittime, false);
    }
}

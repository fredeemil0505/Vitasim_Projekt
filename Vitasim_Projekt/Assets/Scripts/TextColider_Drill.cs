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
        if (FirstTrigger == true && other.tag == "Player")
        {
            TextScripts.ChangeText(new Color(0, 255, 0, 1), 0, 4, "", text);
            TextScripts.TextChanger(new Color(255, 255, 255, 1), 1, 0, "Turn on the machine before drilling", text)

            text.text = "Turn on the machine before drilling";

            text.color = new Color(255, 255, 255, 1);

            text.CrossFadeAlpha(1, 0, false);
            FirstTrigger = false;
            TextScripts.guideStage = 1;
        }
    }
}

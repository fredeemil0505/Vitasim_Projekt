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
        Debug.Log(other.tag);
        if (FirstTrigger == true && other.tag == "Untagged")
        {
 
            text.color = new Color(0, 255, 0, 1);
        
            text.CrossFadeAlpha(0, 4, false);
        
            text.text = "Turn on the machine before drilling";
        
            text.color = new Color(255, 255, 255, 1);
        
            text.CrossFadeAlpha(1, 0, false);
            FirstTrigger = false;
        }
       
    }
}

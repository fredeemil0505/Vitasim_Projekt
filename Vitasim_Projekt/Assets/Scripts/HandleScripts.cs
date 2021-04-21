using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HandleScripts : MonoBehaviour
{
    private float difference = 0f;
    public static float xValue;
    static bool FirstTrigger = true;
    [SerializeField]
    public GameObject drillHead;
    public GameObject Handle;
    public Text text;
    public void Start()
    {
        //Debug.Log("DragStart");
        xValue = Handle.transform.rotation.z;
    }
    //Tjekker om handled er blevet roteret og hvis det er så ændre den y værdien for drilheaded
    public void Update()
    {
        
        if (Handle.transform.rotation.z != xValue)
        {
            if (FirstTrigger == true && TextScripts.guideStage <= 2 && MenuScripts.IsTutorial == true)
            {
                StartCoroutine(Textchanger(4));
                TextScripts.guideStage = 5;
                FirstTrigger = false;
            }
            difference = Handle.transform.rotation.z - xValue;

            drillHead.transform.localPosition = new Vector3(0, -0.001278f * Handle.transform.localEulerAngles.z, 0);

            //Debug.Log("Y" + drillHead.transform.localPosition.y);
           //Debug.Log("X" + Handle.transform.localEulerAngles.z);
            //Debug.Log("Diff" + difference);
            xValue = Handle.transform.rotation.z;
            
        }

    }
    private IEnumerator Textchanger(float waittime)
    {
        TextScripts.ChangeText(new Color(0, 255, 0, 1), 0, 4, "", text);
        yield return new WaitForSeconds(waittime);
        TextScripts.ChangeText(new Color(255, 255, 255, 1), 1, 0, "Turn the handle to change the height of the drillhead", text);
    }
   
}

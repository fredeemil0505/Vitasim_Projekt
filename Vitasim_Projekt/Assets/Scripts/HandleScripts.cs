using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HandleScripts : MonoBehaviour
{
    private float difference = 0f;
    public static float xValue;
    [SerializeField]
    public GameObject drillHead;
    public GameObject Handle;
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
            difference = Handle.transform.rotation.z - xValue;

            drillHead.transform.localPosition = new Vector3(0, -0.001278f * Handle.transform.localEulerAngles.z, 0);

            //Debug.Log("Y" + drillHead.transform.localPosition.y);
           //Debug.Log("X" + Handle.transform.localEulerAngles.z);
            //Debug.Log("Diff" + difference);
            xValue = Handle.transform.rotation.z;
            
        }
        
        
        




    }
}

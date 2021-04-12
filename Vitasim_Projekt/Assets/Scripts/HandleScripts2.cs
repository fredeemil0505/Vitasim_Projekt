using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleScripts2 : MonoBehaviour
{
    //Metode designet for nye boremaskine model, et par ekstra variabler tilføjet.
    //er stadig under udvikling
    public float change = 0.001278f;
    public static float zValue;
    [SerializeField]
    public GameObject drillHead;
    public GameObject Handle;

    private float zOffset = 0.0f;
    private float difference = 0f;


    public void Start()
    {
        //Debug.Log("DragStart");
        zValue = Handle.transform.rotation.z;
        zOffset = drillHead.transform.localPosition.z;
    }
    //Tjekker om handled er blevet roteret og hvis det er så ændre den y værdien for drilheaded
    public void Update()
    {

        if (Handle.transform.rotation.z != zValue)
        {
            difference = Handle.transform.rotation.z - zValue;

            drillHead.transform.localPosition = new Vector3(drillHead.transform.localPosition.x
                , drillHead.transform.localPosition.y
                , zOffset - change * Handle.transform.localEulerAngles.z);

            //Debug.Log("Y" + drillHead.transform.localPosition.z);
            //Debug.Log("X" + Handle.transform.localEulerAngles.z);
            //Debug.Log("Diff" + difference);
            zValue = Handle.transform.rotation.z;
        }
    }


}

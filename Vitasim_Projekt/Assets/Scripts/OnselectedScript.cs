using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnselectedScript : MonoBehaviour
{
    public static GameObject GrabbedObject;
   public void Onselect()
   {
GrabbedObject = this.gameObject;
        Debug.Log("Enter");
  }
    public void OnSelectExited()
    {
        
        GrabbedObject = null;
        if (GrabbedObject == null)
        {
            Debug.Log("Null");
        }
        else
            Debug.Log("Exit");
    }
  
}

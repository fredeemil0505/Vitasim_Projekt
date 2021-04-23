using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeshMakerNamespace;

public class RuntimeCSG : MonoBehaviour {
	public GameObject brush;
	public GameObject target;
	// Use this for initialization
	//void Start () {
	//	CSG.EPSILON = 1e-5f;
	//	CSG csg = new CSG();
	//	csg.Brush = brush;
	//	csg.Target = target;
	//	csg.OperationType = CSG.Operation.Subtract;		
	//	csg.customMaterial = new Material(Shader.Find("Standard"));
	//	csg.useCustomMaterial = false; 
	//	csg.hideGameObjects = false;
	//	csg.keepSubmeshes = true;
	//	GameObject newObject = csg.PerformCSG();
	//	Debug.Log(newObject.name);
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "drill")
        {
CSG.EPSILON = 1e-5f;
		CSG csg = new CSG();
		csg.Brush = brush;
		csg.Target = target;
		csg.OperationType = CSG.Operation.Subtract;
		csg.customMaterial = new Material(Shader.Find("Standard"));
		csg.useCustomMaterial = false;
		csg.hideGameObjects = false;
		csg.keepSubmeshes = true;
		GameObject newObject = csg.PerformCSG();
        }
		
	}
}
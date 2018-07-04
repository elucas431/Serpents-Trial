using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoMove : MonoBehaviour {

    public GameObject controller; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = controller.transform.position;
        transform.eulerAngles = new Vector3 (0, controller.transform.eulerAngles.y, 0);
        //transform.rotation = new Quaternion(0, controller.transform.rotation.y, 0,0.5f); 
	}
}

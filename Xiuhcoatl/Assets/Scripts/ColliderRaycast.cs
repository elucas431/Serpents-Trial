using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRaycast : MonoBehaviour {

    [HideInInspector]
    public float playerHeight;
    public RaycastHit hit; 

     public void Update()
    {
        Ray height = new Ray(transform.position, Vector3.down); 
        if (Physics.Raycast(height, out hit))
        {
            playerHeight = hit.distance;
        }
        Debug.DrawLine(this.gameObject.transform.position, hit.point, Color.red);
       //Debug.Log(playerHeight);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColPhysics : MonoBehaviour {

    Rigidbody playerRb;
    Collider playerCol;
    Rigidbody cameraRb;
    Collider cameraCol; 

     void Start()
    {
       cameraRb = this.gameObject.GetComponent<Rigidbody>();
       cameraCol = this.gameObject.GetComponent<Collider>();
        playerRb = GetComponentInChildren<Rigidbody>();
        playerCol = GetComponentInChildren<Collider>();

    }

    void LateUpdate()
    {
        cameraRb = playerRb;
        cameraCol = playerCol; 
    }

}

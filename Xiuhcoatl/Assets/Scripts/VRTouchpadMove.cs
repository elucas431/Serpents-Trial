using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//-------------------------------------------------------------------------------------------------\\
// This code has been developed by Feisty Crab Studios for personal, commercial, and education use.\\
//                                                                                                 \\
// You are free to edit and redistribute this code, subject to the following:                      \\
//                                                                                                 \\
//      1. You will not sell this code or an edited version of it.                                 \\
//      2. You will not remove the copyright messages                                              \\
//      3. You will give credit to Feisty Crab Studios if used commercially                        \\
//      4. Don't be a mean sausage, nobody likes a mean sausage.                                   \\
//                                                                                                 \\
// Contact us @ feistycrabstudios.gmail.com with any questions.                                    \\
//-------------------------------------------------------------------------------------------------\\

public class VRTouchpadMove : MonoBehaviour
{
    public float speed, speedWalk, multiplier;
    public bool isSprinting, disableMove; 
    [SerializeField]
    private Rigidbody rig;
    public GameObject directionObj;
    public float fallSpeed; 

    

    private Valve.VR.EVRButtonId touchpad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId touchpadDown = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;
    

    private Vector2 axis = Vector2.zero;
    public Vector2 controllerAxis;

    public float maxSpeed;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Fall Zone"))
        {
            disableMove = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Fall Zone"))
        {
            disableMove = false;
        }
    }

    void LateUpdate()
    {   
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (disableMove != true)
        {


            if (device.GetPress(touchpadDown))
            {
                axis = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);

                if (rig != null)
                {
                    maxSpeed = (Mathf.Abs(device.velocity.y)) * multiplier;
                    //speed = (Mathf.Abs(device.velocity.x) + Mathf.Abs(device.velocity.y))/multiplier;
                    rig.AddForce(((directionObj.transform.right * axis.x + directionObj.transform.forward * axis.y) * speed), ForceMode.Force);
                    rig.velocity = Vector3.ClampMagnitude(rig.velocity, maxSpeed); //limits movement speed
                                                                                   //rig.MovePosition(rig.position.x, rig.position.y, rig.position.z); //zero out height
                                                                                   //Debug.Log("x value: " + axis.x + " y value " + axis.y);

                    //TEST
                    //SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);
                }
            }
            else if (device.GetTouch(touchpadDown))
            {
                axis = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);

                if (rig != null)
                {
                    maxSpeed = speedWalk;
                    //speed = (+Mathf.Abs(device.velocity.y)) / multiplier;
                    //speed = (Mathf.Abs(device.velocity.x) + Mathf.Abs(device.velocity.y))/multiplier;
                    rig.AddForce(((directionObj.transform.right * axis.x + directionObj.transform.forward * axis.y) * speed), ForceMode.Force);
                    rig.velocity = Vector3.ClampMagnitude(rig.velocity, maxSpeed); //limits movement speed
                                                                                   //rig.position = new Vector3(rig.position.x, rig.position.y, rig.position.z); //zero out height
                                                                                   //Debug.Log("x value: " + axis.x + " y value " + axis.y);
                }
            }
            else
            {
                rig.velocity = new Vector3(0, 0, 0);
                maxSpeed = fallSpeed; 
            }
        }
        else if(disableMove == true)
        {

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPhysics : MonoBehaviour
{

    public float speed, speedWalk, multiplier;
    public bool isSprinting;
    [SerializeField]
    private Rigidbody rig;

    private Valve.VR.EVRButtonId touchpad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;


    private Vector2 axis = Vector2.zero;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void FixedUpdate()
    {

        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetPress(touchpad))
        {
            axis = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);

            if (rig != null)
            {
                speed = (Mathf.Abs(device.velocity.y)) / multiplier;
                //rig.velocity += (transform.right * axis.x + transform.forward * axis.y) * 0.1f * speed;
                //rig.velocity = new Vector3(rig.velocity.x, 0.0f, rig.velocity.z);
                rig.MovePosition(rig.transform.right * axis.x + rig.transform.forward * axis.y * Time.deltaTime);
                //SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);
            }
        }

        else if (device.GetTouch(touchpad))
        {
            axis = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);    

                if (rig != null)
                {
                //rig.velocity += (transform.right * axis.x + transform.forward * axis.y) * 0.1f * speed;
                // rig.velocity = new Vector3(rig.velocity.x, 0.0f, rig.velocity.z); 
                rig.MovePosition(transform.right * axis.x * axis.y * Time.deltaTime);
                //SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);
            }
        }
    }
}
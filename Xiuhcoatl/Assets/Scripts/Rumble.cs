using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rumble : MonoBehaviour {

    public float duration, timer;
    public ushort str;
    private SteamVR_TrackedObject trackedObj;
    public bool Rstart;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update ()
    {
        timer += Time.deltaTime;
  
            if (timer <= duration && Rstart == true)
        {
            SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);
        }
        if (Rstart == false)
        {
            timer = 0;
        }
	}
}

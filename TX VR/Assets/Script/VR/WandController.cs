using UnityEngine;
using System.Collections;

// https://www.youtube.com/watch?v=LZTctk19sx8

public class WandController : MonoBehaviour {

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private bool gripButtonDown = false;
    private bool gripButtonUp= false;

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private bool triggerButtonDown = false;
    private bool triggerButtonUp = false;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int) trackedObject.index);  } }
    private SteamVR_TrackedObject trackedObject;

	// Use this for initialization
	void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        gripButtonDown = controller.GetPressDown(gripButton);
        gripButtonUp = controller.GetPressUp(gripButton);

        triggerButtonDown = controller.GetPressDown(triggerButton);
        triggerButtonUp = controller.GetPressUp(triggerButton);

        if (gripButtonDown)
        {
            Debug.Log("GripDown was just pressed");
            //TODO: reload?
        }
        if (gripButtonUp)
        {
            Debug.Log("GripDown was just unpressed");
        }
        if (triggerButtonDown)
        {
            Debug.Log("TriggerDown was just pressed");
			GetComponentInChildren<BulletContainer> ().shot ();
        }
        if (triggerButtonUp)
        {
            Debug.Log("TriggerDown was just unpressed");
        }
    }
}

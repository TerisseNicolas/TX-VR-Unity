using UnityEngine;
using System.Collections;

// https://www.youtube.com/watch?v=LZTctk19sx8

public class WandController : MonoBehaviour {

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private bool gripButtonDown = false;
    private bool gripButtonUp= false;
    private bool gripButtonPressed= false;


    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private bool triggerButtonDown = false;
    private bool triggerButtonUp = false;
    private bool triggerButtonPressed = false;

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
        gripButtonPressed= controller.GetPress(gripButton);

        triggerButtonDown = controller.GetPressDown(triggerButton);
        triggerButtonUp = controller.GetPressUp(triggerButton);
        triggerButtonPressed = controller.GetPress(triggerButton);

        if (gripButtonDown)
        {
            Debug.Log("GripDown was just pressed");
        }
        if (gripButtonUp)
        {
            Debug.Log("GripDown was just unpressed");
        }
        if (triggerButtonDown)
        {
            Debug.Log("TriggerDown was just pressed");
        }
        if (triggerButtonUp)
        {
            Debug.Log("TriggerDown was just unpressed");
        }
    }
}

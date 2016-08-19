using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {

    public Transform pistol;
    public Transform shotgun;
    public Transform automatic;

    private int currentWeaponId = 0;
    private bool changingWeapon = false;
    public List<Transform> weapons;

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId padUpButton = Valve.VR.EVRButtonId.k_EButton_DPad_Up;
    private Valve.VR.EVRButtonId padDownButton = Valve.VR.EVRButtonId.k_EButton_DPad_Down;
    private Valve.VR.EVRButtonId reloadButton = Valve.VR.EVRButtonId.k_EButton_A;

    private bool triggerButtonDown = false;
    private bool triggerButtonPressed = false;
    private bool padUpButtonUp = false;
    private bool padDownButtonUp = false;
    private bool reloadButtonUp = false;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObject.index); } }
    private SteamVR_TrackedObject trackedObject;

    void awake()
    {
        this.weapons = new List<Transform>();
        this.weapons.Add(pistol);
        this.weapons.Add(shotgun);
        this.weapons.Add(automatic);
    }

    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    private void getPreviousWeapon()
    {
        int tempId;
        if (this.currentWeaponId > 0)
        {
            tempId = this.currentWeaponId - 1;
        }
        else
        {
            tempId = this.weapons.Count - 1;
        }
        sleepBetweenWeaponChange(tempId);
    }

    private void getNextWeapon()
    {
        sleepBetweenWeaponChange((this.currentWeaponId + 1) % weapons.Count);
    }

    IEnumerator sleepBetweenWeaponChange(int newWeaponId)
    {
        this.changingWeapon = true;
        Destroy(transform.Find(this.weapons[this.currentWeaponId].gameObject.name));
        yield return new WaitForSeconds(2);
        Instantiate(this.weapons[newWeaponId], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
        this.currentWeaponId = newWeaponId;
        this.changingWeapon = false;
    }

    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        triggerButtonPressed = controller.GetPress(triggerButton);
        triggerButtonDown = controller.GetPressDown(triggerButton);

        padUpButtonUp = controller.GetPressUp(padUpButton);
        padDownButtonUp = controller.GetPressUp(padDownButton);
        reloadButtonUp = controller.GetPressUp(reloadButton);

        if (padUpButtonUp)
        {
            if (!this.changingWeapon)
            {
                getPreviousWeapon();
            }
        }
        if (padDownButtonUp)
        {
            if(!this.changingWeapon)
            {
                getNextWeapon();
            }
        }
        if(reloadButtonUp)
        {
            if (!this.changingWeapon)
            {
                this.weapons[this.currentWeaponId].gameObject.GetComponent<BulletContainer>().reload();
            }
        }
        if(triggerButtonDown || triggerButtonPressed)
        {
            if(!this.changingWeapon)
            {
                this.weapons[this.currentWeaponId].gameObject.GetComponent<BulletContainer>().shot();
            }
        }
    }
}

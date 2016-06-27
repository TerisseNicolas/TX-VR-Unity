using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Fire(VibrationZoneType.calfR);
        if (Input.GetKeyDown(KeyCode.Z))
            Fire(VibrationZoneType.calfL);
        if (Input.GetKeyDown(KeyCode.E))
            Fire(VibrationZoneType.thighR);
        if (Input.GetKeyDown(KeyCode.R))
            Fire(VibrationZoneType.thighL);
        if (Input.GetKeyDown(KeyCode.T))
            Fire(VibrationZoneType.forearmR);
        if (Input.GetKeyDown(KeyCode.Y))
            Fire(VibrationZoneType.forearmL);
        if (Input.GetKeyDown(KeyCode.U))
            Fire(VibrationZoneType.armR);
        if (Input.GetKeyDown(KeyCode.I))
            Fire(VibrationZoneType.armL);
        if (Input.GetKeyDown(KeyCode.Q))
            Fire(VibrationZoneType.chest);
        if (Input.GetKeyDown(KeyCode.S))
            Fire(VibrationZoneType.head);
        if (Input.GetKeyDown(KeyCode.D))
            Fire(VibrationZoneType.back);
    }

    private void Fire(VibrationZoneType zone)
    {
        switch (zone)
        {
            case VibrationZoneType.calfR:
                Debug.Log("Shoot calfR");
                break;
            case VibrationZoneType.calfL:
                Debug.Log("Shoot calfL");
                break;
            case VibrationZoneType.thighR:
                Debug.Log("Shoot thighR");
                break;
            case VibrationZoneType.thighL:
                Debug.Log("Shoot thighL");
                break;
            case VibrationZoneType.forearmR:
                Debug.Log("Shoot forearmR");
                break;
            case VibrationZoneType.forearmL:
                Debug.Log("Shoot forearmL");
                break;
            case VibrationZoneType.armR:
                Debug.Log("Shoot armR");
                break;
            case VibrationZoneType.armL:
                Debug.Log("Shoot calfL");
                break;
            case VibrationZoneType.chest:
                Debug.Log("Shoot chest");
                break;
            case VibrationZoneType.head:
                Debug.Log("Shoot head");
                break;
            case VibrationZoneType.back:
                Debug.Log("Shoot back");
                break;
        }
    }
}

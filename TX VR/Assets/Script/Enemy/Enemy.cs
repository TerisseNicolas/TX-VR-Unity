﻿using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour {

    private GameObject weapon;
    private GameObject aimingArm;

    //Aim target
    GameObject target; 
    float speed = 4f;
    int angle = 25;

    void Start()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {         
            if (child.name == "Pistol")
            {
                //Debug.Log(gameObject.name + "--------" + child.gameObject.name);
                weapon = child.gameObject;
            }
            if (child.name == "Bip001 R UpperArm")
            {
                aimingArm = child.gameObject;
            }
        }
        //Only one target in the scene
        this.target = GameObject.Find("target");


        //StartCoroutine(raiseArm());
        //aim();
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

    public void Fire()
    {
        Array values = Enum.GetValues(typeof(VibrationZoneType));
        System.Random random = new System.Random();
        VibrationZoneType zone = (VibrationZoneType) values.GetValue(random.Next(values.Length));
        Fire(zone);
    }

    private void Fire(VibrationZoneType zone)
    {
        //Debug.Log(gameObject.name + "-------" + zone.ToString());

        Transform zoneTransform = GameObject.Find("VibrationZone_" + zone.ToString()).transform;
        weapon.transform.LookAt(zoneTransform);

        this.weapon.GetComponentInChildren<BulletContainer>().shot();
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


    void aim1()
    {
        /*Vector3 targetDir = target.transform.position - aimingArm.transform.position;
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        aimingArm.transform.rotation = Quaternion.LookRotation(newDir);*/


        /*Vector3 relativePos = target.transform.position - this.aimingArm.transform.position;
        Debug.Log("target " + target.transform.position.ToString());
        Debug.Log("arm " + this.aimingArm.transform.position);
        Debug.Log("rela " + relativePos);
        Quaternion rotation = Quaternion.LookRotation(relativePos);// * new Quaternion(0, 0, 0, 1);
        Debug.Log(rotation.ToString());
        this.aimingArm.transform.rotation = rotation;*/

        //aimingArm.transform.RotateAround(aimingArm.transform.position, transform.right, Time.deltaTime * 90f);

        /*Vector3 targetDir = target.transform.position - aimingArm.transform.position;
        Debug.Log(aimingArm.transform.rotation.eulerAngles.ToString());
        float angle = AngleBet(this.aimingArm.transform.eulerAngles, targetDir);*/
        //aimingArm.transform.RotateAround(aimingArm.transform.position, transform.up, angle);

        /*
        Quaternion myQuat = Quaternion.Euler(aimingArm.transform.localEulerAngles);
        Quaternion targetQuat = Quaternion.Euler(target.transform.localEulerAngles);

        int i = 0;
        while((i!= 1000) && (myQuat != targetQuat))
        {
            i++;
            Debug.Log(i.ToString());
            aimingArm.transform.localRotation = Quaternion.RotateTowards(myQuat, targetQuat, 10.0f);
            myQuat = Quaternion.Euler(aimingArm.transform.localEulerAngles);
        }*/
    }
    void aim()
    {
        var rotate = Quaternion.LookRotation(target.transform.position - aimingArm.transform.position);
        aimingArm.transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * 6.0f);
    }
            
    public static float AngleBet(Vector3 from, Vector3 to)
    {
        return Mathf.Acos(Mathf.Clamp(Vector3.Dot(from.normalized, to.normalized), -1f, 1f)) * 57.29578f;
    }



    IEnumerator raiseArm()
    {
        int i;
        for(i=angle; i>=0; i--)
        {
            this.aimingArm.transform.Rotate(Vector3.forward * speed);
            yield return new WaitForSeconds(0.005f);
        }
        this.weapon.GetComponentInChildren<BulletContainer>().shot();
        yield return new WaitForSeconds(1f);

        //aim();
        StartCoroutine(lowerArm());
    }

    IEnumerator lowerArm()
    {
        int i;
        for (i = 0; i <= angle; i++)
        {
            this.aimingArm.transform.Rotate(Vector3.back * speed);
            yield return new WaitForSeconds(0.005f);
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(raiseArm());
    }
}

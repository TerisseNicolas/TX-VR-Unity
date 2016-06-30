﻿using UnityEngine;
using System.Collections;

public class BulletContainer : MonoBehaviour {

    //public Transform bulletTransformPrefab;
    public BulletShot bulletShotPrefab;

    public void shot()
    {
        //var bulletTransform = Instantiate(bulletTransformPrefab) as Transform;
        //bulletTransform.name = "Bullet";
        BulletShot clone = (BulletShot)Instantiate(bulletShotPrefab, this.transform.position, this.transform.rotation);
        clone.gameObject.name = "Bullet";

        /*
        BulletShot anim_bullet = bulletTransform.GetComponent<BulletShot>();
        if (anim_bullet != null)
        {
            //anim_bullet.transform.SetParent(this.transform);
            anim_bullet.transform.position = this.transform.position;
            anim_bullet.transform.rotation = this.transform.rotation;
        }
        else
        {
            Debug.Log("error");
        }*/
    }
}

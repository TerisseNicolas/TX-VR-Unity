using UnityEngine;
using System.Collections;

public class BulletContainer : MonoBehaviour {

    //public Transform bulletTransformPrefab;
    public BulletShot bulletShotPrefab;
    public string weaponName;

    private int bulletsCapacityStatic;  //constant
    private int bulletsCapacityActive;  //modified when shot

    void Start()
    {
        if (weaponName == null || weaponName == "")
        {
            //this error is shown if the attribute "weaponName" is not assigned in a BulletContainer object
            Debug.LogError("weaponName not assigned!");
        }
        else if (this.weaponName == "Automatic")
        {
            this.bulletsCapacityStatic = this.bulletsCapacityActive = 50;
        }
        else
        {
            this.bulletsCapacityStatic = this.bulletsCapacityActive = 5;
        }
    }

    void Update()
    {
        if (this.weaponName == "Pistol" || this.weaponName == "Shotgun")
        {
            //only one shot at the same time
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shot();
            }
        }
        if (this.weaponName == "Automatic")
        {
            //possible to shoot continously by keeping "space" pressed
            if (Input.GetKey(KeyCode.Space))
            {
                shot();
            }
        }

    }
    
    public void shot()
    {
        if (this.bulletsCapacityActive > 0)
        {
            BulletShot clone = (BulletShot)Instantiate(bulletShotPrefab, this.transform.position, this.transform.rotation);
            clone.gameObject.name = "Bullet";
            this.bulletsCapacityActive--;
        }
        else
        {
            //TODO: add sound empty magazine
            Debug.Log("Empty magazine");
        }
    }

    public void reload()
    {
        this.bulletsCapacityActive = this.bulletsCapacityStatic;
    }
}

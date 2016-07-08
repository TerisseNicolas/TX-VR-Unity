using UnityEngine;
using System.Collections;

public class BulletContainer : MonoBehaviour {

    //public Transform bulletTransformPrefab;
    public BulletShot bulletShotPrefab;
    public string weaponName;

    void Start()
    {
        //StartCoroutine(test());
        if (weaponName == null || weaponName == "")
        {
            Debug.LogError("weaponName not assigned!");
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
        if (this.weaponName == "OtherName")//TODO: find this weapon
        {
            //possible to shoot continously by keeping "space" pressed
            if (Input.GetKey(KeyCode.Space))
            {
                shot();
            }
        }

    }

    IEnumerator test()
    {
        for(;;)
        {
            shot();
            yield return new WaitForSeconds(1f);
        }
    }

    public void shot()
    {
        BulletShot clone = (BulletShot)Instantiate(bulletShotPrefab, this.transform.position, this.transform.rotation);
        clone.gameObject.name = "Bullet";
    }
}

using UnityEngine;
using System.Collections;

public class BulletContainer : MonoBehaviour {

    public BulletShot bulletShotPrefab;
    public string weaponName;

    public float reloadTime = 3f;
    public float fireRate = 1f;
    public int chargerCapacity = 6;
    public int chargerFilling;
    public bool automatic = false;

    private bool shooting = false;
    private bool reloading = false;

    void Start()
    {
        if (weaponName == null || weaponName == "")
        {
            Debug.LogError("weaponName not assigned!");
        }
        else if (gameObject.name.Contains("Automatic"))
        {
            this.automatic = true;
            this.chargerCapacity = 30;
            this.fireRate = 0.3f;
        }
        else if (gameObject.name.Contains("shotgun"))
        {
            this.reloadTime = 3f;
            this.chargerCapacity = 2;
        }
        this.chargerFilling = chargerCapacity;
    }
    
    public void shot()
    {
        if ((this.chargerFilling > 0) && !this.shooting)
        {
            BulletShot clone = (BulletShot)Instantiate(bulletShotPrefab, this.transform.position, this.transform.rotation);
            clone.gameObject.name = "Bullet";
            cooling();
            this.chargerFilling--;
        }
        else
        {
            //TODO: add sound empty magazine
            Debug.Log("Empty magazine");
        }
    }

    public IEnumerator reload()
    {
        if(!this.reloading)
        {
            this.reloading = true;
            yield return new WaitForSeconds(this.reloadTime);
            this.chargerFilling = this.chargerCapacity;
            this.reloading = false;
        }        
    }

    private IEnumerator cooling()
    {
        this.shooting = true;
        yield return new WaitForSeconds(this.fireRate);
        this.shooting = false;
    }
}

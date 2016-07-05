using UnityEngine;
using System.Collections;

public class BulletContainer : MonoBehaviour {

    //public Transform bulletTransformPrefab;
    public BulletShot bulletShotPrefab;

    void Start()
    {
        //StartCoroutine(test());
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

using UnityEngine;
using System.Collections;

public class BulletContainer : MonoBehaviour {

    public Transform bulletTransformPrefab;

    public void shot()
    {
        var bulletTransform = Instantiate(bulletTransformPrefab) as Transform;
        bulletTransform.name = "Bullet";
        BulletShot anim_bullet = bulletTransform.GetComponent<BulletShot>();
        if (anim_bullet != null)
        {
            anim_bullet.transform.SetParent(this.transform);
            anim_bullet.transform.position = this.transform.position;
        }
        else { Debug.Log("error"); }

    }
}

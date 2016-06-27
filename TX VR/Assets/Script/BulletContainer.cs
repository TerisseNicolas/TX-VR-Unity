using UnityEngine;
using System.Collections;

public class BulletContainer : MonoBehaviour {

    public Transform bulletTransformPrefab;

    void Start()
    {
        //StartCoroutine(test());
    }

    IEnumerator test()
    {
        for(;;)
        {
            shot();
            yield return new WaitForSeconds(0.5f); 
        }
    }
    public void shot()
    {
        var bulletTransform = Instantiate(bulletTransformPrefab) as Transform;
        bulletTransform.name = "Bullet";
        BulletShot anim_bullet = bulletTransform.GetComponent<BulletShot>();
        if (anim_bullet != null)
        {
            anim_bullet.transform.SetParent(this.transform);
            anim_bullet.transform.position = this.transform.position; // Camera.main.ScreenToWorldPoint(this.transform.position);
            // anim_bullet.transform.rotation = this.transform.rotation;
        }
        else { Debug.Log("error"); }

    }
}

using UnityEngine;
using System.Collections;

public class VibratingZone : MonoBehaviour
{
    LifeManager targetLife;
    int damage = 10;

    void Start()
    {
        this.targetLife = transform.root.GetComponentInChildren<LifeManager>();
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Bullet")
        {
            targetLife.hurt(this.damage * other.GetComponent<BulletShot>().damageCoefficient);
        }
    }
}

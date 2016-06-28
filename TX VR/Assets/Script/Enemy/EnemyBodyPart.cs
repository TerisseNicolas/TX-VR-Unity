using UnityEngine;
using System.Collections;

public class EnemyBodyPart : MonoBehaviour {

    LifeManager parentLife;
    int damage = 10;

    void Start()
    {
        this.parentLife = transform.root.GetComponentInChildren<LifeManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Bullet")
        {
            parentLife.hurt(this.damage * other.GetComponent<BulletShot>().damageCoefficient);
        }
    }
}

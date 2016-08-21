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
            float points = this.damage * other.GetComponent<BulletShot>().damageCoefficient;
            parentLife.hurt(points);
            Score.increaseScore((int)points);
        }
    }
}

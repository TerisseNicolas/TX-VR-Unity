using UnityEngine;
using System.Collections;

public class VibratingZone : MonoBehaviour
{
    target target;
    int damage = 10;

    void Start()
    {
        this.target = GameObject.Find("target").GetComponent<target>();
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Bullet")
        {
            target.setLife(this.damage * other.GetComponent<BulletShot>().damageCoefficient);
        }
    }
}

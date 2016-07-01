using UnityEngine;
using System.Collections;
using System;

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
            VibrationZoneType vibrationZoneType = (VibrationZoneType)Enum.Parse(typeof(VibrationZoneType), this.name.Split('_')[1]);
            BluetoothManager.send(vibrationZoneType, VibrationType.limited, 1);
            return;
        }
        if (other.name == "Wall")
        {
            VibrationZoneType vibrationZoneType = (VibrationZoneType)Enum.Parse(typeof(VibrationZoneType), this.name.Split('_')[1]);
            BluetoothManager.send(vibrationZoneType, VibrationType.limited, 2);
        }
    }
}

using UnityEngine;
using System.Collections;

public class BulletShot : MonoBehaviour
{

    public float damageCoefficient { get; private set; }

    void Awake()
    {
        this.damageCoefficient = 1.0f;
        
    }

    void Start()
    {
        SoundPlayer.Instance.playShot1();
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 25 * Time.deltaTime, 0);
        //transform.Translate(0, Time.deltaTime, 0, Space.World);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Contains("Crate1") || col.gameObject.name.Contains("Barrel1") || col.gameObject.name.Contains("CityBuilding1") || col.gameObject.name.Contains("Wall"))
        {
            SoundPlayer.Instance.playImpact1();
            if (col.gameObject.name.Contains("Crate1"))
            {
                Destroy(col.gameObject);
            }
        }
        Destroy(gameObject);
    }
}

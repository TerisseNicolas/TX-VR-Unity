using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

    private GameObject weapon;

    // Use this for initialization
    void Awake()
    {
        this.weapon = GameObject.Find("BulletContainer_Turret");
    }

    void Start()
    {
        StartCoroutine(shootingRoutine());
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 4);
    }

    IEnumerator shootingRoutine()
    {
        for(;;)
        {
            this.shot();
            //SoundPlayer.Instance.playShot1();
            yield return new WaitForSeconds(0.2f);
        }
    }

    // Update is called once per frame
    void shot () {
        this.weapon.GetComponent<BulletContainer>().shot();
    }
}

using UnityEngine;
using System.Collections;

public class testCowboy : MonoBehaviour {

    private GameObject weapon;
    private GameObject aimingArm;
    private GameObject target;
    private GameObject hand;


    void Start () {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == "Pistol")
            {
                weapon = child.gameObject;
            }
            if (child.name == "Bip001 R UpperArm")
            {
                aimingArm = child.gameObject;
            }
            if (child.name == "Bip001 R Hand")
            {
                hand = child.gameObject;
            }
            

        }
        this.target = GameObject.Find("target");

        //aiming arm points at target

        Transform lineTransform = GameObject.Find("Line").transform;
        Transform headTransform = GameObject.Find("Bip01_Head1").transform;
        lineTransform.LookAt(headTransform);

        Quaternion quat = hand.transform.rotation;
        //quat.x = lineTransform.rotation.x;
        quat.x += 90;
        hand.transform.rotation = quat;

        weapon.transform.rotation = lineTransform.rotation;


        StartCoroutine(toto());



        //aimingArm.transform.LookAt(GameObject.Find("Line").transform);
        //aimingArm.transform.LookAt(new Vector3(transform.position.x, transform.position.y, target.transform.position.z));

    }

    IEnumerator toto()
    {
        yield return new WaitForSeconds(3);
        this.weapon.GetComponentInChildren<BulletContainer>().shot();
    }
	

	void Update () {
	
	}
}

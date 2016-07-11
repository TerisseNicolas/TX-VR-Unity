using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    private float speed = 4f;
    private int angle = 15;
    private Vector3 newPos;

    //Initial Z rotation for shot : 75

    private GameObject aimingArm;
    private BulletContainer shotgun;
    private Animator animator;
    private bool movingArm = false;

    void Start()
    {
        this.aimingArm = gameObject.transform.Find("Bip01/Bip01_Spine/Bip01_Spine1/Bip01_Spine2/Bip01_Spine4/Bip01_R_Clavicle/Bip01_R_UpperArm").gameObject;
        this.shotgun = gameObject.transform.Find("Bip01/Bip01_Spine/Bip01_Spine1/Bip01_Spine2/Bip01_Spine4/Bip01_R_Clavicle/Bip01_R_UpperArm/Bip01_R_Forearm/Bip01_R_Hand/Pistol").gameObject.GetComponentInChildren<BulletContainer>();

        //StartCoroutine(raiseArm());
        //StartCoroutine(test()); 

        animator = gameObject.GetComponent<Animator>();
        animator.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.enabled = true;
            animator.Play("PlayerDown");
            //animator.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.enabled = true;
            animator.Play("PlayerUp");
            //animator.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.W) && !this.movingArm)
        {
            animator.enabled = false;
            StartCoroutine(raiseArm());
        }
    }

    IEnumerator test()
    {
        for (;;)
        {
            this.shotgun.shot();
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator raiseArm()
    {
        this.movingArm = true;
        int i;
        for (i = angle; i >= 0; i--)
        {
            this.aimingArm.transform.Rotate(Vector3.forward * speed);
            yield return new WaitForSeconds(0.005f);
        }
        this.shotgun.shot();
        yield return new WaitForSeconds(1f);

        StartCoroutine(lowerArm());
    }

    IEnumerator lowerArm()
    {
        int i;
        for (i = 0; i <= angle; i++)
        {
            this.aimingArm.transform.Rotate(Vector3.back * speed);
            yield return new WaitForSeconds(0.005f);
        }
        this.movingArm = false;
        //yield return new WaitForSeconds(1f);
        //StartCoroutine(raiseArm());
    }
}
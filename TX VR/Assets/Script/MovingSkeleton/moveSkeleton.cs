using UnityEngine;
using System.Collections;

public class moveSkeleton : MonoBehaviour {


    Animator animator;

    void Start()
    {
        this.animator = gameObject.GetComponent<Animator>();
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow) &&!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Walk01"))
        {
            //this.animator.Stop();
            this.animator.Play("Walk01");
            //this.animator.CrossFade("Walk01", 0.5f);
        }
        if (Input.GetKey(KeyCode.DownArrow) && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("WalkBack"))
        {
            this.animator.Play("WalkBack");
        }
        if (Input.GetKey(KeyCode.RightArrow) && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("WalkRight"))
        {
            this.animator.Play("WalkRight");
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("WalkLeft"))
        {
            this.animator.Play("WalkLeft");
        }

        if ((Input.GetKeyUp(KeyCode.UpArrow)) && this.animator.GetCurrentAnimatorStateInfo(0).IsName("Walk01"))
        {
            this.animator.CrossFade("Idle", 0.2f);
        }
        if ((Input.GetKeyUp(KeyCode.DownArrow)) && this.animator.GetCurrentAnimatorStateInfo(0).IsName("WalkBack"))
        {
            this.animator.CrossFade("Idle", 0.2f);
        }
        if ((Input.GetKeyUp(KeyCode.RightArrow)) && this.animator.GetCurrentAnimatorStateInfo(0).IsName("WalkRight"))
        {
            this.animator.CrossFade("Idle", 0.2f);
        }
        if ((Input.GetKeyUp(KeyCode.LeftArrow)) && this.animator.GetCurrentAnimatorStateInfo(0).IsName("WalkLeft"))
        {
            this.animator.CrossFade("Idle", 0.2f);
        }

        foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (gameObj.name == "Wall")
            {
                float distance = Vector3.Distance(this.transform.position, gameObj.transform.position);
                if (distance < 5)
                {
                    Debug.Log("5m du mur");
                }
                if (distance < 3)
                {
                    Debug.Log("3m du mur");
                }
            }
        }
        

    }
}

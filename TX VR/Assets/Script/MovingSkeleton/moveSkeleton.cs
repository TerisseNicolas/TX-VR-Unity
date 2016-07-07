using UnityEngine;
using System.Collections;

public class moveSkeleton : MonoBehaviour {


    private Animator animator;
    public float speedFront = 0.5f;
    public float speedSide = 0.5f;

    void Start()
    {
        this.animator = gameObject.GetComponent<Animator>();
    }
	// Update is called once per frame
	void Update () {

        //New animation
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

        //During the animation and a the end
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Walk01"))
        {
            transform.position += Vector3.right * speedFront * Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                this.animator.CrossFade("Idle", 0.2f);
            } 
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("WalkBack"))
        {
            transform.position += Vector3.left * speedFront * Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                this.animator.CrossFade("Idle", 0.2f);
            }
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("WalkRight"))
        {
            transform.position += -Vector3.forward * speedSide * Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                this.animator.CrossFade("Idle", 0.2f);
            }
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("WalkLeft"))
        {
            transform.position += Vector3.forward * speedSide * Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                this.animator.CrossFade("Idle", 0.2f);
            }
        }

        foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (gameObj.name.Contains("Wall"))
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

using UnityEngine;
using System.Collections;

public class moveSkeleton : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 pos = this.transform.position;
            pos.x = pos.x + 0.5f;
            this.transform.position = pos;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 pos = this.transform.position;
            pos.x = pos.x - 0.5f;
            this.transform.position = pos;
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

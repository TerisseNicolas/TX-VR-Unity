using UnityEngine;
using System.Collections;

public class target : MonoBehaviour {

    int life = 100;

    BoxCollider headCollider;

    // Use this for initialization
    void Start() {
        headCollider = GameObject.Find("Bip01_Head2").GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update() {

    }

    public int getLife()
    {
        return life;
    }
    public void setLife(int newValue)
    {
        life -= newValue;
        if(life <= 0)
        {
            Debug.Log("Killed");
            life = 0;
        }
    }
}

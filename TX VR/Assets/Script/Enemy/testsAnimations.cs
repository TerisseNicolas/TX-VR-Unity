﻿using UnityEngine;
using System.Collections;

public class testsAnimations : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("toto");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    IEnumerator toto()
    {
        for (;;)
        {
            yield return new WaitForSeconds(2);
            gameObject.GetComponent<Animator>().Play("EnemyStanding");
            yield return new WaitForSeconds(2);
            gameObject.GetComponent<Animator>().Play("EnemyKneeling");
        }
    }

}
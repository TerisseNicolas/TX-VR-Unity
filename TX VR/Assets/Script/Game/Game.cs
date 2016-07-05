using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

    List<Enemy> enemyList;
    int enemyCountInit = 6;
    int enemyRemaining;

    void Awake()
    {
        this.enemyRemaining = this.enemyCountInit;
    }

	void Start ()
    {
        int i;
        for (i=1; i<= enemyCountInit; i++)
        {
            enemyList.Add(GameObject.Find("CowBoy" + i.ToString()).GetComponent<Enemy>());
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

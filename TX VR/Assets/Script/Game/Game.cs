using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    EnemyManager enemyManager;
    public bool gameEnd = false;

    void Start()
    {
        this.enemyManager = gameObject.GetComponent<EnemyManager>();
        StartCoroutine(startGame());
    }

    //Start the game
    IEnumerator startGame()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Starting game ===========================");
        StartCoroutine(this.enemyManager.startGame());
        yield return StartCoroutine(endOfGameCheck());
    }

    //Infinite game loop
    IEnumerator endOfGameCheck()
    {
        while(EnemyManager.enemyRemaining !=0 )
        {
            yield return new WaitForSeconds(1f);
        }

        //End of game Todo
        Debug.Log("End of game============================");
        this.gameEnd = true;
    }
}

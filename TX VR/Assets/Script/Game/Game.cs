using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    EnemyManager enemyManager;
    GameObject target;
    public bool gameEnd = false;

    void Start()
    {
        this.enemyManager = gameObject.GetComponent<EnemyManager>();
        this.target = GameObject.Find("target");
        this.target.GetComponent<LifeManager>().DeathEvent += target_DeathEvent;
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

    //When the player died
    private void target_DeathEvent(object sender, System.EventArgs e)
    {
        Debug.Log("The player is dead ============================");
    }
}

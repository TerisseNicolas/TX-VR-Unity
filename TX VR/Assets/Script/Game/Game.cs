using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    EnemyManager enemyManager;
    GameObject target;
    public int gameEnd = 0;
    public int playTime = 180;
    public int remainingPlayTime;

    private Text timerText;

    void Start()
    {
        this.remainingPlayTime = this.playTime;
        this.timerText = GameObject.Find("Timer").GetComponent<Text>();
        this.timerText.text = this.remainingPlayTime.ToString();
        this.enemyManager = gameObject.GetComponent<EnemyManager>();
        this.target = GameObject.Find("target");
        this.target.GetComponent<LifeManager>().DeathEvent += target_DeathEvent;
        StartCoroutine(startGame());
    }

   //Start the game
    IEnumerator startGame()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(gameTimer());
        Debug.Log("Starting game ===========================");
        StartCoroutine(this.enemyManager.startGame());
        yield return StartCoroutine(endOfGameCheck());
    }

    //Infinite game loop
    IEnumerator endOfGameCheck()
    {
        yield return new WaitForSeconds(0f);
        while (EnemyManager.enemyRemaining != 0)
        {
            yield return new WaitForSeconds(1f);
        }
        endOfGame();
    }

    IEnumerator gameTimer()
    {
        for(int i=this.playTime; i>0; i--)
        {
            yield return new WaitForSeconds(1f);
            this.remainingPlayTime--;
            this.timerText.text = this.remainingPlayTime.ToString();
        }
        endOfGame();
    }

    private void endOfGame()
    {
        this.gameEnd++;
        if(this.gameEnd == 1)
        {
            //todo
        }
    }

    //When the player died
    private void target_DeathEvent(object sender, System.EventArgs e)
    {
        Debug.Log("The player is dead ============================");
    }
}

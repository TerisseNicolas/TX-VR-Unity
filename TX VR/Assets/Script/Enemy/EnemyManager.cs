using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    List<Enemy> enemyList = new List<Enemy>();
    public static int enemyCountInit = 6;
    public static int enemyRemaining = enemyCountInit;

    void Start()
    {
        int i;
        for (i = 1; i <= EnemyManager.enemyCountInit; i++)
        {
            enemyList.Add(GameObject.Find("CowBoy" + i.ToString()).GetComponent<Enemy>());
        }
    }

    // Update is called once per frame
   public IEnumerator startGame()
    {
        float sleepingTime;
        System.Random random = new System.Random();
        int index;
        while (EnemyManager.enemyRemaining != 0)
        {
            //Select an enemy
            index = random.Next(enemyList.Count);

            //Fire
            enemyList[index].Fire();

            sleepingTime = random.Next(2, 6);
            yield return new WaitForSeconds(sleepingTime);
        }
        yield return new WaitForSeconds(0f);
    }
}

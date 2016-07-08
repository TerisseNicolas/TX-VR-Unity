using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;


public class EnemyManager : MonoBehaviour
{
    List<Enemy> enemyList = new List<Enemy>();
    public static int enemyCountInit = 5;
    public static int enemyRemaining = enemyCountInit;

    void Start()
    {
        int i;
        for (i = 1; i <= EnemyManager.enemyCountInit; i++)
        {
            enemyList.Add(GameObject.Find("CowBoy" + i.ToString()).GetComponent<Enemy>());
            enemyList[i - 1].gameObject.GetComponent<LifeManager>().DeathEvent += EnemyManager_DeathEvent;
        }
    }

    public IEnumerator startGame()
    {
        float sleepingTime;
        System.Random random = new System.Random();
        int index;
        Animator animator;
        float length1 = 2f;
        float length2 = 2f;

        while (EnemyManager.enemyRemaining != 0)
        {
            //Select an enemy
            index = random.Next(enemyList.Count);

            //Fire
            animator = enemyList[index].gameObject.GetComponentInChildren<Animator>();

            foreach (AnimationClip clip in AnimationUtility.GetAnimationClips(animator.gameObject))
            {
                if (clip.name == "EnemyStanding")
                {
                    length1 = clip.length;
                }
                else if (clip.name == "EnemyKneeling")
                {
                    length2 = clip.length;
                }
            }
            animator.Play("EnemyStanding");
            yield return new WaitForSeconds(length1);
            enemyList[index].Fire();
            yield return new WaitForSeconds(length2);
            enemyList[index].gameObject.GetComponentInChildren<Animator>().Play("EnemyKneeling");

            //Between each cowboy action
            sleepingTime = random.Next(2, 6);
            yield return new WaitForSeconds(sleepingTime);
        }
        yield return new WaitForSeconds(0f);
    }

    //When an enemy is killed
    private void EnemyManager_DeathEvent(object sender, System.EventArgs e)
    {
        //Debug.Log("Killed ++++++++" + sender.ToString());
        GameObject enemyObject = ((LifeManager)sender).gameObject;
        enemyList.Remove(enemyObject.GetComponent<Enemy>());
        enemyRemaining -= 1;
        Destroy(enemyObject);
        Score.increaseScore(10);
        //Debug.Log(enemyList.Count.ToString() + "-----------------");
    }
}

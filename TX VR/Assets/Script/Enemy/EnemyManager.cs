using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor;


public class EnemyManager : MonoBehaviour
{
    List<Enemy> enemyList = new List<Enemy>();
    public static int enemyCountInit = 5;
    public static int enemyRemaining = enemyCountInit;

    Animator animator;
    int index;

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

        while (EnemyManager.enemyRemaining != 0)
        {
            //Select an enemy
            index = random.Next(enemyList.Count);

            //Fire
            animator = enemyList[index].gameObject.GetComponentInChildren<Animator>();
            

            animator.Play("EnemyStanding");
            yield return new WaitForSeconds(0.1f);
            for (;;)
            {
                if (animator.GetCurrentAnimatorClipInfo(0).Length != 0 && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "EnemyStanding" && !animator.IsInTransition(0))
                {
                    yield return new WaitForSeconds(0.01f);
                }
                else
                    break;
            }

            enemyList[index].Fire();
            
            //Between each cowboy action
            sleepingTime = random.Next(2, 6);
            yield return new WaitForSeconds(sleepingTime);
        }
        yield return new WaitForSeconds(0f);
    }

    IEnumerator doAnimations(string anim1, string anim2)
    {
        animator.Play(anim1);
        yield return new WaitForSeconds(0.1f);
        for (;;)
        {
            if (animator.GetCurrentAnimatorClipInfo(0).Length != 0)
            {
                Debug.Log(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == anim1);
                yield return new WaitForSeconds(1);
            }
            else
                break;
        }

        enemyList[index].Fire();
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

using UnityEngine;
using System.Collections;
using System;

public class EnemyMaze : MonoBehaviour
{
    EnemyDetector enemyDetector;
    Enemy enemy;

    void Start () {
        this.enemy = gameObject.GetComponent<Enemy>();
        this.enemyDetector = transform.root.gameObject.GetComponentInChildren<EnemyDetector>();

        StartCoroutine(animate());
    }

    void Update()
    {
        //For tests
        Vector3 newpos = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime / 2);
        transform.position = newpos;
    }

    IEnumerator animate()
    {
        //Don't understand everything ^^
        Animator animator = gameObject.GetComponentInChildren<Animator>();
        for (;;)
        {
            if (this.enemyDetector.targetDetected == true)
            {
                Debug.Log("targetDetected");
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName("EnemyStanding"))
                {
                    animator.Play("EnemyStanding");
                    yield return new WaitForSeconds(0.1f);
                    for (;;)
                    {
                        if (animator.GetCurrentAnimatorClipInfo(0).Length != 0 && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "EnemyStanding" && !animator.IsInTransition(0))
                        {
                            yield return new WaitForSeconds(0.1f);
                        }
                        else
                            break;
                    }
                }
                this.enemy.Fire();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}

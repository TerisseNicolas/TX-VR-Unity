using UnityEngine;
using System.Collections;

public class MazeGame : MonoBehaviour
{
    FinalSphere finalSphere;
    GameObject target;
    public bool gameEnd = false;

    // Use this for initialization
    void Start () {
        this.target = GameObject.Find("targetMaze");
        this.target.GetComponent<LifeManager>().DeathEvent += target_DeathEvent;
        this.finalSphere = GameObject.Find("FinalSphere").GetComponent<FinalSphere>();

        StartCoroutine(startGame());
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Starting game ===========================");

        StartCoroutine(endOfGameCheck());
    }

    //Infinite game loop
    IEnumerator endOfGameCheck()
    {
        yield return new WaitForSeconds(0f);
        while (this.finalSphere.collided == false)
        {
            yield return new WaitForSeconds(1f);
        }

        Debug.Log("End of game============================");
        this.gameEnd = true;
    }

    //When the player died
    private void target_DeathEvent(object sender, System.EventArgs e)
    {
        Debug.Log("The player is dead ============================");
    }
}

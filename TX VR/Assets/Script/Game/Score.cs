using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
    static int score = 0;

    public static void increaseScore(int points)
    {
        if(points > 0)
        {
            Score.score += points;
            Debug.Log("New score : " + Score.score.ToString());
        }
    }
}

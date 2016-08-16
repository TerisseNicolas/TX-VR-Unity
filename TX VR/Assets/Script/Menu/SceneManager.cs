using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSupervisor : MonoBehaviour
{
    public static void loadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

	public static void loadShooterScene()
    {
        SceneManager.LoadScene("CowBoyShooting");
    }

    public static void loadScoresScene()
    {
        SceneManager.LoadScene("ScoreScene");
    }
}
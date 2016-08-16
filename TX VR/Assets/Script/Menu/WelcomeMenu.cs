using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WelcomeMenu : MonoBehaviour
{
    private Button buttonShooter;
    private Button buttonScores;
    private Button buttonQuit;

	void Start ()
    {
        buttonShooter = GameObject.Find("ButtonShooter").GetComponent<Button>();
        buttonScores = GameObject.Find("ButtonScores").GetComponent<Button>();
        buttonQuit = GameObject.Find("ButtonQuit").GetComponent<Button>();

        buttonShooter.onClick.AddListener(buttonShooterClicked);
        buttonScores.onClick.AddListener(() => { buttonScoresClicked(); });
        buttonQuit.onClick.AddListener(() => { buttonQuitClicked(); });
    }

    void buttonShooterClicked()
    {
        SceneSupervisor.loadShooterScene();
    }

    void buttonScoresClicked()
    {
        SceneSupervisor.loadScoresScene();
    }

    void buttonQuitClicked()
    {
        Application.Quit();
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScene : MonoBehaviour {

    private Button buttonReturn;

    void Start()
    {
        buttonReturn = GameObject.Find("ButtonReturn").GetComponent<Button>();
        buttonReturn.onClick.AddListener(buttonReturnClicked);
    }

    void buttonReturnClicked()
    {
        SceneSupervisor.loadMenuScene();
    }
}

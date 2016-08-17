using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class WelcomeMenu : MonoBehaviour
{
    //Button order: shooter, scores, quit
    private List<Button> buttons;
    private int buttonSelectedId;

    private Valve.VR.EVRButtonId padUpButton = Valve.VR.EVRButtonId.k_EButton_DPad_Up;
    private Valve.VR.EVRButtonId padDownButton = Valve.VR.EVRButtonId.k_EButton_DPad_Down;
    private Valve.VR.EVRButtonId axisCenterButton = Valve.VR.EVRButtonId.k_EButton_Axis0;

    private bool padUpButtonUp = false;
    private bool padDownButtonUp = false;
    private bool axisCenterButtonUp = false;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObject.index); } }
    private SteamVR_TrackedObject trackedObject;

    void Awake()
    {
        buttons = new List<Button>();
    }
    void Start ()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();

        buttons.Add(GameObject.Find("ButtonShooter").GetComponent<Button>());
        buttons.Add(GameObject.Find("ButtonScores").GetComponent<Button>());
        buttons.Add(GameObject.Find("ButtonQuit").GetComponent<Button>());

        this.buttonSelectedId = 0;

        buttons[0].onClick.AddListener(buttonShooterClicked);
        buttons[0].onClick.AddListener(() => { buttonScoresClicked(); });
        buttons[0].onClick.AddListener(() => { buttonQuitClicked(); });
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

    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        padUpButtonUp = controller.GetPressUp(padUpButton);
        padDownButtonUp = controller.GetPressUp(padDownButton);
        axisCenterButtonUp = controller.GetPressUp(axisCenterButton);

        if (padUpButtonUp)
        {
            //Move up
            previousButtonId();
        }
        if (padDownButtonUp)
        {
            //Move down
            nextButtonId();
        }
        if (axisCenterButtonUp)
        {
            //Confirm
            buttons[this.buttonSelectedId].onClick.Invoke();
        }
    }

    private void nextButtonId()
    {
        this.buttons[buttonSelectedId].image.color = Color.red;
        this.buttonSelectedId = (this.buttonSelectedId + 1) % buttons.Count;
        this.buttons[buttonSelectedId].image.color = Color.cyan;
    }

    private void previousButtonId()
    {
        this.buttons[buttonSelectedId].image.color = Color.red;
        if (this.buttonSelectedId > 0)
        {
            this.buttonSelectedId -= 1;
        }
        else
        {
            this.buttonSelectedId = this.buttons.Count - 1;
        }
        this.buttons[buttonSelectedId].image.color = Color.cyan;
    }
}

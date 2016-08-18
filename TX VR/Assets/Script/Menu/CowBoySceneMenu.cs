using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CowBoySceneMenu : MonoBehaviour {

    private List<Button> buttons;
    private int buttonSelectedId;
    private bool menuShown = false;

    private Canvas canvas;

    private Valve.VR.EVRButtonId padUpButton = Valve.VR.EVRButtonId.k_EButton_DPad_Up;
    private Valve.VR.EVRButtonId padDownButton = Valve.VR.EVRButtonId.k_EButton_DPad_Down;
    private Valve.VR.EVRButtonId axisCenterButton = Valve.VR.EVRButtonId.k_EButton_Axis0;
    private Valve.VR.EVRButtonId menuButton = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;

    private bool padUpButtonUp = false;
    private bool padDownButtonUp = false;
    private bool axisCenterButtonUp = false;
    private bool menuButtonUp = false;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObject.index); } }
    private SteamVR_TrackedObject trackedObject;

    void Awake()
    {
        buttons = new List<Button>();
    }
    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        this.canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        buttons.Add(GameObject.Find("resumeButton").GetComponent<Button>());
        buttons.Add(GameObject.Find("restartButton").GetComponent<Button>());
        buttons.Add(GameObject.Find("quitButton").GetComponent<Button>());

        this.buttonSelectedId = 0;

        buttons[0].onClick.AddListener(resumeButtonClicked);
        buttons[0].onClick.AddListener(() => { restartButtonClicked(); });
        buttons[0].onClick.AddListener(() => { quitButtonClicked(); });
    }

    void showMenu()
    {
        this.canvas.enabled = true;
    }

    void hideMenu()
    {
        this.canvas.enabled = false;
    }

    void resumeButtonClicked()
    {
        hideMenu();
    }

    void restartButtonClicked()
    {
        SceneSupervisor.loadShooterScene();
    }

    void quitButtonClicked()
    {
        SceneSupervisor.loadMenuScene();
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
        menuButtonUp = controller.GetPressUp(menuButton);

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
        if(menuButtonUp)
        {
            switch(this.menuShown)
            {
                case true:
                    this.menuShown = false;
                    hideMenu();
                    break;
                case false:
                    this.menuShown = true;
                    showMenu();
                    break;
            }
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
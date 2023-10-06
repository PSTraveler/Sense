using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Fourth_EventScript : MonoBehaviour, Character_Input.IVoiceActionActions, Character_Input.IPauseGameActions, Character_Input.ISenseChangeActions
{
    private Character_Input _input;
    bool isOK = false;
    int type = 0;

    public GameObject player;
    public GameObject lights;
    public Material defaultMat;
    public Material floorMat;
    public Material wallMat;
    public GameObject floor;
    public GameObject wall;
    public GameObject UI_point;
    public GameObject UI_Manual;
    public GameObject UI_Pause;
    public GameObject UI_Eye;
    public GameObject UI_Ear;
    public GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        Shader.SetGlobalFloat("FLOORmask_strength3", 0.0f);
        player.GetComponent<CharacterControl_4F>().enabled = false;
        UI_point.SetActive(false);
        UI_Manual.GetComponent<Image>().enabled = false;
        UI_Pause.SetActive(false);
        goal.SetActive(false);
        StartCoroutine(ManualShow());

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (type == 0) {
            lights.SetActive(true);
            UI_Eye.SetActive(true);
            UI_Ear.SetActive(false);
            player.GetComponent<CharacterControl_4F>().isTouchActive = false;
            player.GetComponent<CharacterControl_4F>().rad2 = 0.0f;
            floor.GetComponent<Renderer>().material = defaultMat;
            wall.GetComponent<Renderer>().material = defaultMat;
            AudioListener.volume = 0.1f;
        }

        else if (type == 1) {
            lights.SetActive(false);
            UI_Eye.SetActive(false);
            UI_Ear.SetActive(true);
            player.GetComponent<CharacterControl_4F>().isTouchActive = false;
            player.GetComponent<CharacterControl_4F>().rad2 = 0.0f;
            floor.GetComponent<Renderer>().material = defaultMat;
            wall.GetComponent<Renderer>().material = defaultMat;
            AudioListener.volume = 1.0f;
        }

        else if (type == 2) {
            lights.SetActive(false);
            UI_Eye.SetActive(false);
            UI_Ear.SetActive(false);
            player.GetComponent<CharacterControl_4F>().isTouchActive = true;
            floor.GetComponent<Renderer>().material = floorMat;
            wall.GetComponent<Renderer>().material = wallMat;
            AudioListener.volume = 0.1f;
        }
    }

    public void OnAccept(InputAction.CallbackContext context)
    {
        if (context.performed) isOK = true;
        else isOK = false;
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed && !UI_Pause.activeSelf) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            player.GetComponent<CharacterControl_4F>().enabled = false;
            UI_point.SetActive(false);
            Time.timeScale = 0.0f;
            UI_Pause.SetActive(true);
        }
        else if (context.performed && UI_Pause.activeSelf) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            player.GetComponent<CharacterControl_4F>().enabled = true;
            UI_point.SetActive(true);
            Time.timeScale = 1.0f;
            UI_Pause.SetActive(false);
        }
    }

    public void OnEye(InputAction.CallbackContext context)
    {
        if (context.performed) type = 0;
    }

    public void OnEar(InputAction.CallbackContext context)
    {
        if (context.performed) type = 1;
    }

    public void OnHand(InputAction.CallbackContext context)
    {
        if (context.performed) type = 2;
    }

    private void OnEnable()
    {
        if (_input == null) _input = new Character_Input();

        _input.VoiceAction.SetCallbacks(instance: this);
        _input.PauseGame.SetCallbacks(instance: this);
        _input.SenseChange.SetCallbacks(instance: this);
        _input.VoiceAction.Enable();
        _input.PauseGame.Enable();
        _input.SenseChange.Enable();
    }

    private void OnDisable()
    {
        _input.VoiceAction.Disable();
        _input.PauseGame.Disable();
        _input.SenseChange.Disable();
    }
    IEnumerator ManualShow()
    {
        UI_Manual.GetComponent<Image>().enabled = true;

        while(!isOK) {
            yield return null;
        }

        UI_Manual.GetComponent<Image>().enabled = false;

        player.GetComponent<CharacterControl_4F>().enabled = true;
        UI_point.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Third_EventScript : MonoBehaviour, Character_Input.IVoiceActionActions, Character_Input.IPauseGameActions
{
    private Character_Input _input;
    bool isOK = false;
    public GameObject player;
    public GameObject UI_point;
    public GameObject UI_Manual;
    public GameObject UI_Pause;
    public GameObject goal;
    public bool[] stageClear = new bool[5] {false, false, false, false, false};

    // Start is called before the first frame update
    void Start()
    {
        Shader.SetGlobalFloat("FLOORmask_strength3", 0.0f);
        player.GetComponent<CharacterControl_3F>().enabled = false;
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
        if (stageClear[0] && stageClear[1] && stageClear[2] && stageClear[3] && stageClear[4]) {
            goal.SetActive(true);
            stageClear = new bool[5] {false, false, false, false, false};
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

            player.GetComponent<CharacterControl_3F>().enabled = false;
            UI_point.SetActive(false);
            Time.timeScale = 0.0f;
            UI_Pause.SetActive(true);
        }
        else if (context.performed && UI_Pause.activeSelf) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            player.GetComponent<CharacterControl_3F>().enabled = true;
            UI_point.SetActive(true);
            Time.timeScale = 1.0f;
            UI_Pause.SetActive(false);
        }
    }

    private void OnEnable()
    {
        if (_input == null) _input = new Character_Input();

        _input.VoiceAction.SetCallbacks(instance: this);
        _input.PauseGame.SetCallbacks(instance: this);
        _input.VoiceAction.Enable();
        _input.PauseGame.Enable();
    }

    private void OnDisable()
    {
        _input.VoiceAction.Disable();
        _input.PauseGame.Disable();
    }
    IEnumerator ManualShow()
    {
        UI_Manual.GetComponent<Image>().enabled = true;

        while(!isOK) {
            yield return null;
        }

        UI_Manual.GetComponent<Image>().enabled = false;

        player.GetComponent<CharacterControl_3F>().enabled = true;
        UI_point.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.InputSystem;

public class First_EventScript : MonoBehaviour, Character_Input.IVoiceActionActions, Character_Input.IPauseGameActions
{
    private Character_Input _input;
    bool isOK = false;
    public GameObject player;
    public GameObject UI_point;
    public GameObject UI_video;
    public GameObject UI_Manual;
    public GameObject UI_Pause;
    public Sprite Tex_Manual_2;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        player.GetComponent<CharacterControl>().enabled = false;
        UI_point.SetActive(false);
        UI_video.GetComponent<VideoPlayer>().Stop();
        UI_video.GetComponent<VideoPlayer>().Play();
        UI_video.GetComponent<VideoPlayer>().loopPointReached += EndofVideo;
        UI_Manual.GetComponent<Image>().enabled = false;
        UI_Pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

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

            player.GetComponent<CharacterControl>().enabled = false;
            UI_point.SetActive(false);
            Time.timeScale = 0.0f;
            UI_Pause.SetActive(true);
        }
        else if (context.performed && UI_Pause.activeSelf) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            player.GetComponent<CharacterControl>().enabled = true;
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

    void EndofVideo(VideoPlayer vp)
    {
        StartCoroutine(ManualShow());
    }

    IEnumerator ManualShow()
    {
        UI_Manual.GetComponent<Image>().enabled = true;

        while(!isOK) {
            yield return null;
        }

        UI_Manual.GetComponent<Image>().sprite = Tex_Manual_2;
        yield return null;
        isOK = false;
        
        while(!isOK) {
            yield return null;
        }

        UI_Manual.GetComponent<Image>().enabled = false;

        player.GetComponent<CharacterControl>().enabled = true;
        UI_point.SetActive(true);
    }
}

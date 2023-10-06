using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class Goal : MonoBehaviour, Character_Input.IVoiceActionActions
{
    private Character_Input _input;
    public GameObject UI_Point;
    public GameObject UI_Goal;
    public string goal_string;
    bool isEnter;

    // Start is called before the first frame update
    void Start()
    {
        UI_Goal.GetComponent<TextMeshProUGUI>().text = goal_string;
        UI_Goal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAccept(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton() && isEnter) {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 1);
        }
    }

    private void OnEnable()
    {
        if (_input == null) _input = new Character_Input();

        _input.VoiceAction.SetCallbacks(instance: this);
        _input.VoiceAction.Enable();
    }

    private void OnDisable()
    {
        _input.VoiceAction.Disable();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player") {
            Time.timeScale = 0.0f;
            isEnter = true;
            UI_Point.SetActive(false);
            UI_Goal.SetActive(true);
        }
    }


}

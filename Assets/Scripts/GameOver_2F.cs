using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_2F : MonoBehaviour
{
    public GameObject UI_Point;
    public GameObject UI_Effect;
    public GameObject UI_Voice;
    public GameObject UI_Gameover;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        UI_Gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 0.0f;
            UI_Point.SetActive(false);
            UI_Voice.SetActive(false);
            UI_Effect.SetActive(false);
            player.GetComponent<CharacterControl_2F>().enabled = false;
            player.GetComponentInChildren<AudioListener>().enabled = false;
            UI_Gameover.SetActive(true);
        }
    }
}
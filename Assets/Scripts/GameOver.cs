using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject UI_Point;
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
            player.GetComponent<CharacterControl>().enabled = false;
            UI_Gameover.SetActive(true);
        }
    }
}

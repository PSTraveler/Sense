using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Buttons : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1.0f;
        if (SceneManager.GetActiveScene().name == "1FScene")
            player.GetComponent<CharacterControl>().enabled = true;
        else if (SceneManager.GetActiveScene().name == "2FScene") {
            player.GetComponent<CharacterControl_2F>().enabled = true;
            player.GetComponentInChildren<AudioListener>().enabled = true;
        }
        else if (SceneManager.GetActiveScene().name == "3FScene") {
            player.GetComponent<CharacterControl_3F>().enabled = true;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void exit()
    {
        Time.timeScale = 1.0f;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

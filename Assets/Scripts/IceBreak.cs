using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBreak : MonoBehaviour
{
    public GameObject player;
    public GameObject UI_Point;
    public GameObject UI_GameOver;
    public AudioClip dingdong;
    public AudioClip buzzer;

    AudioSource audioSource;

    bool isMoved = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(ChangeSound());
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoved && player.transform.hasChanged) {
            Time.timeScale = 0.0f;
            UI_Point.SetActive(false);
            player.GetComponent<CharacterControl_2F>().enabled = false;
            player.GetComponentInChildren<AudioListener>().enabled = false;
            UI_GameOver.SetActive(true);
        }
    }

    IEnumerator ChangeSound()
    {
        while (Vector3.Distance(transform.position, player.transform.position) > 1.2f) {
            audioSource.Stop();
            audioSource.clip = dingdong;
            audioSource.Play();

            yield return new WaitForSeconds(3.0f);

            audioSource.Stop();
            audioSource.clip = buzzer;
            audioSource.Play();

            yield return new WaitForSeconds(0.5f);

            player.transform.hasChanged = false;
            isMoved = true;

            yield return new WaitForSeconds(3.0f);
            
            isMoved = false;
        }

        enabled = false;

        yield return null;
    }
}

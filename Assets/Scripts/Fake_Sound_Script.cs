using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fake_Sound_Script : MonoBehaviour
{
    public AudioClip ac;
    public GameObject next;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckEnd());
        next.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CheckEnd()
    {
        while (!GetComponent<AudioSource>().isPlaying) {
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);

        while (GetComponent<AudioSource>().time > 0) {
            yield return null;
        }

        if (ac != null) {
            GetComponent<AudioSource>().clip = ac;
            GetComponent<AudioSource>().spatialBlend = 1.0f;
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(1.0f);
        }

        next.SetActive(true);

        yield return null;
    }
}

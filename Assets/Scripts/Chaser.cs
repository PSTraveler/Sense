using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public GameObject player;
    public GameObject chaser;
    public float speed = 1.5f;
    float power = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        chaser.GetComponent<AudioSource>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        chaser.transform.LookAt(player.transform);
    }

    void FixedUpdate()
    {
        chaser.transform.Translate(new Vector3(0, 0, power * Time.fixedDeltaTime));
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player") {
            chaser.GetComponent<AudioSource>().Play();
            StartCoroutine(Terminate());
            power = speed;
            GetComponent<Collider>().enabled = false;
        }
    }

    IEnumerator Terminate()
    {
        yield return new WaitForSeconds(37.0f);
        chaser.SetActive(false);
        enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Signal : MonoBehaviour
{
    public GameObject player;
    public GameObject next;
    AudioSource audioSource;
    float dis;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (next != null)
            next.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector3.Distance(transform.position, player.transform.position);
        audioSource.pitch = Mathf.Clamp(3 * audioSource.pitch / dis, 1.0f, 3.0f);
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player") {
            if (next != null)
                next.SetActive(true);
        }
    }
}

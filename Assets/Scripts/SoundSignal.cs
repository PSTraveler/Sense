using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSignal : MonoBehaviour
{
    public GameObject player;
    public GameObject next;
    public float mind = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        if (next != null)
            next.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < mind) {
            if (next != null)
                next.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}

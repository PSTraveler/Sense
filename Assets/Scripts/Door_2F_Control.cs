using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_2F_Control : MonoBehaviour
{
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player") {
            door.GetComponent<Animator>().SetBool(door.name, true);
            enabled = false;
        }
    }
}

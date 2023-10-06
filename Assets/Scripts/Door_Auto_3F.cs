using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Auto_3F : MonoBehaviour
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
            door.GetComponent<Animator>().SetBool("isEnd", false);
            door.GetComponent<Animator>().SetBool("isActive", true);
        }
    }
    
    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Player") {
            door.GetComponent<Animator>().SetBool("isEnd", true);
            door.GetComponent<Animator>().SetBool("isActive", false);
        }
    }
}

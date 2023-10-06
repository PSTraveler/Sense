using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Auto : MonoBehaviour
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

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
            door.GetComponent<Animator>().SetBool("isActive", true);
    }
}

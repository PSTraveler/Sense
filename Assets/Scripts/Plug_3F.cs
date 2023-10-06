using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plug_3F : MonoBehaviour
{
    public GameObject plug;
    public GameObject bulb;
    public int index;

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
        if (c.gameObject == plug) {
            bulb.GetComponent<ClearState_3F>().isDone[index] = true;
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject == plug) {
            bulb.GetComponent<ClearState_3F>().isDone[index] = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearState_3F : MonoBehaviour
{
    public bool[] isDone = new bool[3] {false, false, false};
    public GameObject eventSystem;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDone[0] && isDone[1] && isDone[2]) {
            eventSystem.GetComponent<Third_EventScript>().stageClear[index] = true;
            gameObject.SetActive(false);
        }
    }
}

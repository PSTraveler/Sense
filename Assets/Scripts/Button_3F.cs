using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_3F : MonoBehaviour
{
    public GameObject door;
    public Material idleMat;
    public Material useMat;
    public GameObject eventSystem;
    public int index;
    Renderer rd;
    public bool isActive = false;
    public bool isClear = false;
    void Start()
    {
        rd = GetComponent<Renderer>();
        if (!isClear)
            StartCoroutine(doorOpen());
    }

    void Update()
    {
        if (isClear && isActive) {
            rd.material = useMat;
            door.SetActive(false);
            eventSystem.GetComponent<Third_EventScript>().stageClear[index] = true;
            enabled = false;
        }

    }

    IEnumerator doorOpen()
    {
        while(true) {

            if (isActive) {
                rd.material = useMat;
                door.GetComponent<Animator>().SetBool("isEnd", false);
                door.GetComponent<Animator>().SetBool("isActive", true);
                yield return new WaitForSeconds(3.0f);
                door.GetComponent<Animator>().SetBool("isEnd", true);
                door.GetComponent<Animator>().SetBool("isActive", false);
                rd.material = idleMat;
                isActive = false;
            }
            yield return null;
        }
    }
}

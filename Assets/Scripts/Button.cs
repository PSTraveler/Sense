using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool isActive;
    public GameObject door;
    public Material useMat;
    public Material idleMat;
    private Renderer mr;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<Renderer>();
        isActive = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive) {
            mr.material = useMat;
            door.GetComponent<Animator>().SetBool("isActive", true);
            if (door.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("DoorOpening") && door.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) {
                mr.material = idleMat;
                isActive = false;
                door.GetComponent<Animator>().SetBool("isActive", false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wave : MonoBehaviour
{
    public GameObject player;
    public float power = 1.0f;
    public bool isRepeat = false;
    SpriteRenderer ren;
    Color c;
    float len = 0;

    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<SpriteRenderer>();
        c = ren.color;
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        if ((Vector3.Distance(transform.position, player.transform.position) < 1.0f) && !isRepeat) gameObject.SetActive(false);
    }

    void LateUpdate() {
        c = ren.color;
        len = Mathf.Clamp(len, 0.0f, 1.0f);
        c.a = Mathf.Clamp(c.a * len, 0.0f, 1.0f);
        ren.color = c;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") {
            len = power / Vector3.Distance(transform.position, other.transform.position);
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.tag == "Player") {
            len = power / Vector3.Distance(transform.position, other.transform.position);
            other.gameObject.GetComponent<CharacterControl>().isVib = true;
        }
    }
    
    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player") {
            len = 0;
            other.gameObject.GetComponent<CharacterControl>().isVib = false;
        }
    }
}

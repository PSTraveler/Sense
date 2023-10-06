using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatControl : MonoBehaviour
{
    public Animator beat_anim;
    public AudioSource beat_sound;
    public AudioClip beat_slow;
    public AudioClip beat_fast;
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
            beat_anim.Rebind();
            beat_anim.speed *= 2.0f;
            beat_sound.clip = beat_fast;
            if (!beat_sound.isPlaying) beat_sound.Play();
        }
    }

    void OnDisable()
    {
        if (beat_anim != null) {
            beat_anim.Rebind();
            beat_anim.speed *= 0.5f;
            beat_sound.clip = beat_slow;
            if (!beat_sound.isPlaying) beat_sound.Play();
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Player") {
            beat_anim.Rebind();
            beat_anim.speed *= 0.5f;
            beat_sound.clip = beat_slow;
            if (!beat_sound.isPlaying) beat_sound.Play();
        }
    }
}

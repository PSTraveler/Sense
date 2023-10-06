using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class VoicePlay : MonoBehaviour
{
    public GameObject UI_Point;
    public Animator anim_bg;
    public Animator anim_text;
    public VideoPlayer vd;
    public AudioSource _audio;
    public TextMeshProUGUI tm;
    public GameObject next;

    [Multiline]
    public string text;

    string[] bunch;

    // Start is called before the first frame update
    void Start()
    {
        _audio.Stop();
        vd.Stop();
        bunch = text.Split('\n');
        if (next != null)
            next.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player") {
            UI_Point.SetActive(false);
            anim_bg.SetBool("isEnd", false);
            anim_bg.SetBool("isActive", true);
            vd.Play();
            _audio.Play();
            
            StartCoroutine(PrintText());

            GetComponent<Collider>().enabled = false;
        }
    }

    IEnumerator PrintText()
    {
        yield return new WaitForSeconds(1.0f);
        anim_text.SetBool("isActive", true);

        foreach (string line in bunch) {

            anim_text.SetBool("isEnd", false);
            tm.text = line;

            yield return new WaitForSeconds(3.0f);

            anim_text.SetBool("isEnd", true);

            while (anim_text.GetCurrentAnimatorStateInfo(0).IsName("Voice_text_Start")) {
                yield return null;
            }

            while (anim_text.GetCurrentAnimatorStateInfo(0).IsName("Voice_text_End") && anim_text.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f) {
                yield return null;
            }
        }

        anim_bg.SetBool("isActive", false);
        anim_text.SetBool("isActive", false);
        anim_bg.SetBool("isEnd", true);
        UI_Point.SetActive(true);

        _audio.Stop();
        vd.Pause();

        if (next != null)
            next.SetActive(true);
        yield return null;
    }
}

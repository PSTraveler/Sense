using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Title_Screen : MonoBehaviour
{
    public VideoPlayer vp;
    public Animator anim;
    bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        vp.loopPointReached += EndofVideo;
    }

    // Update is called once per frame
    void Update()
    {
        if (vp.time > 7.8f && !isPause) {
            anim.SetBool("isActive", true);
            vp.Pause();
            isPause = true;
        }
    }

    void EndofVideo(VideoPlayer vp) {
        SceneManager.LoadScene("1FScene");
    }

    public void start()
    {
        anim.SetBool("isEnd", true);
        vp.Play();
    }

    public void exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

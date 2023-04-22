using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PGVSceneController : MonoBehaviour
{
    private VideoPlayer _vp;

    void Start()
    {
        _vp = GetComponent<VideoPlayer>();
        _vp.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(1);
    }
}

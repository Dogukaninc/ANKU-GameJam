using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.loopPointReached += VideoFinish;
    }

    void VideoFinish(VideoPlayer player)
    {
        SceneManager.LoadScene("Scene_1");
    }
}

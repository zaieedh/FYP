using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    /// <summary>
    /// Reference to video player
    /// </summary>
    VideoPlayer videoPlayer;
    /// <summary>
    /// Reference to pause and play button objects on GUI
    /// </summary>
    public GameObject PauseButton, PlayButton;
    /// <summary>
    /// Reference to slider object on GUI that shows current time of clip
    /// </summary>
    public Slider Progress;
    /// <summary>
    /// Checking if slider is moving
    /// </summary>
    bool sliderMoving;
    
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        Progress.maxValue = (float)videoPlayer.length;
        videoPlayer.loopPointReached += OnEndPlaying;
    }

    /// <summary>
    /// Pausing video and setting its time to 0
    /// </summary>
    /// <param name="videoPlayer">Current video player</param>
    void OnEndPlaying(VideoPlayer videoPlayer)
    {
		PauseVideo();
		videoPlayer.time = 0;
	}

	private void FixedUpdate()
	{
    	if (videoPlayer != null && !sliderMoving)
        {
            Progress.value = (float)videoPlayer.time;
        }
	}
    /// <summary>
    /// Pausing video
    /// </summary>
	public void PauseVideo()
    {
        PlayButton.SetActive(true);
        PauseButton.SetActive(false);
        videoPlayer.Pause();
    }
    /// <summary>
    /// Playing video
    /// </summary>
    public void PlayVideo()
    {
		PlayButton.SetActive(false);
		PauseButton.SetActive(true);
		videoPlayer.Play();
	}

    /// <summary>
    /// Setting sliderMoving to true (Once user wants to change current time of video)
    /// </summary>
    public void ChangePositionStart()
    {
        sliderMoving = true;
    }
    /// <summary>
    /// Setting sliderMoving to false and updating time of video based on progress slider (Once user wants to change current time of video)
    /// </summary>
    public void ChangePositionEnd()
    {
        videoPlayer.time = (int)Progress.value;
        sliderMoving = false;
    }
}

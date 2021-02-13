using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Video;
using TMPro;

public class ControlBrightenes : MonoBehaviour
{
    [Header("<-----Volume slider, input Field------------->")]
    public              Slider              volumeSlider;
    [Header("<-----playback speed slider, input Field----->")]
    public              Slider              playBackSpeed;
    public              InputField          playbackSpeed_field;
                        VideoPlayer         videoPlayer;

    [Header("<-----video volume control------------------->")]
    public              AudioSource         source;

    [Header("<-----DropDown Menu-------------------------->")]
    public              TMP_Dropdown        dropdown;

    public              Playpause           playpause;
    public static       ControlBrightenes   _instance = null;
    private void Awake() {
        if(_instance == null)
        {
            _instance = this;
        }
    }
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(delegate{
            _Volume();
        });

        playBackSpeed.onValueChanged.AddListener(delegate{
        videoSpeed();});

        if(playpause != null)
            videoPlayer = playpause.videoPlayer;
            
        playbackSpeed_field.onValueChanged.AddListener(delegate{
          _videoSpeedField();});

        dropdown.onValueChanged.AddListener(delegate{
            setAspectRatio(dropdown);});
        
    }
    
    //==========================================================================
    /// <summary>
    /// This function is to control video volume using slider value.
    /// </summary>
    public void _Volume()
    {
        source.volume = volumeSlider.value;
    }

 //==========================================================================
    /// <summary>
    /// This function is to control video playback speed using slider value.
    /// </summary>
    public void videoSpeed()
    {
        videoPlayer.playbackSpeed = playBackSpeed.value;
        playbackSpeed_field.text = playBackSpeed.value.ToString("0.00");
    }
     //==========================================================================
    /// <summary>
    /// This function is to control video playback speed using Input field value.
    /// </summary>

    public void _videoSpeedField()
    {
        playBackSpeed.value = float.Parse(playbackSpeed_field.text);
        videoPlayer.playbackSpeed = playBackSpeed.value;
    }


    //===========================================================================
    /// <summary>
    /// This function is for setting AspectRatio of the video.
    /// </summary>
    /// <param name="dp">DropDown value for seeting Aspect Ratio.</param>
    public void setAspectRatio(TMP_Dropdown dp)
    {
       switch (dp.captionText.text)
       {
           case "FitVertical" :videoPlayer.aspectRatio = VideoAspectRatio.FitVertically;
           break;

           case "FitHorizontal" : videoPlayer.aspectRatio = VideoAspectRatio.FitHorizontally;
           break;

            case "FitInside" :videoPlayer.aspectRatio = VideoAspectRatio.FitInside;
           break;

           case "Stretch" : videoPlayer.aspectRatio = VideoAspectRatio.Stretch;
           break;

           case "FitOutside" :videoPlayer.aspectRatio = VideoAspectRatio.FitOutside;
           break;

           case "NoScalling" :videoPlayer.aspectRatio = VideoAspectRatio.NoScaling;
           break;

           case "default" :
           break;
       }
       
    }
}

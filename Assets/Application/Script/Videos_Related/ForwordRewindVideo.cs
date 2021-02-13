using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Video;
using TMPro;


public class ForwordRewindVideo : MonoBehaviour
{
    
    public              Slider               slider;
                        VideoPlayer          vPlayer;
    private double                           Totaltime, len;
    public              TextMeshProUGUI      TotalTimeText;
    private int                              hr,min,rMin;
    private float                            hrR, sec,rSec;
    [HideInInspector]
    public  float                             conversionFactor, frameSliderValue, ActualTime;
    public bool                               isPlaying = true;
    private float                             _frame,_frameRate,_frameCount;
    public                 Playpause           playpause;
    public long                                forwordFrameAmount;
    void Start()
    {
        if(playpause!=null)
            vPlayer = playpause.videoPlayer;

           slider.onValueChanged.AddListener(delegate{
             _ForwordBackword();
            });
    }
    //==========================================================================================
    /// <summary>
    /// This function is used for forword and Rewind video using slider value.
    /// </summary>
    public void _ForwordBackword()
    {
        if(slider.value < slider.maxValue-1){
            vPlayer.Play();

            if(!isPlaying){
                vPlayer.frame = vPlayer.frame = (long)(slider.value * _frameRate);}
            }
    }


    //======================================================================================
    /// <summary>
    /// This function is called from MainMenu.cs to calculate videoframe.
    /// </summary>
    public void _calculateVideoFrame()
    {
        if(playpause!=null)
            vPlayer = playpause.videoPlayer;

        StartCoroutine(videoFrameCount());
    }
//==========================================================================================
    /// <summary>
    /// IEnumerator is used to get total framecount of video after loading, and total time of video in Hour,Minute and Second.
    /// </summary>
    /// <returns></returns>
    IEnumerator videoFrameCount()
    {
        yield return new WaitForSeconds(0.5f);
        Totaltime = vPlayer.frameCount / vPlayer.frameRate;
        ActualTime = (float)(Totaltime / conversionFactor);
      

        min = (int)(ActualTime % conversionFactor);
        hr = (int)(ActualTime / conversionFactor);
        sec = (float)(Mathf.FloorToInt((ActualTime - (int)ActualTime) * conversionFactor));

        rMin = 0;
        rSec = 0;
        hrR = 0;

        TotalTimeText.text =  hr.ToString("00") + ":"+ min.ToString("00") +":"+ sec.ToString("00");

        slider.maxValue = Mathf.Floor((float)Totaltime);
        _frameRate = vPlayer.frameRate;
        _frameCount = vPlayer.frameCount;
        isPlaying = true;

        StartCoroutine(sliderIncrease());
    }
//==========================================================================================
    /// <summary>
    /// This function is used for calculating total video time and slider value(Increase by video playing time).
    /// </summary>
    public void remainigVideoLenght()
    {
        _frame =  vPlayer.frame;
        frameSliderValue = (int)((_frameCount - (float)_frame) / _frameRate);
        slider.value = (int)Totaltime - frameSliderValue;
        calculateTime();
    }
//==========================================================================================
    /// <summary>
    /// This function called when slider is clicked or released.
    /// </summary>
    /// <param name="b">Assigning b true/false to IsPlaying</param>
    public void _sliderMoveStatus(bool b)
    {
        isPlaying = b;

      //  playpause.Isplaying = !b;
       // playpause.playPausevideo();

        if(!isPlaying){
            //vPlayer.frame = (long)(slider.value * _frameRate);
           // _calculateVideoFrame();
          
        }
        else{
            vPlayer.frame = (long)(slider.value * _frameRate);
            _calculateVideoFrame();
        }
    }
//============================================================================================
/// <summary>
/// This function is for increasing slider value as per the video frame.
/// </summary>
/// <returns></returns>
    IEnumerator sliderIncrease()
    {
        while(isPlaying)
        {
            remainigVideoLenght();
            if(slider.value == slider.maxValue)
            {
                playpause.WhenCompleted.Invoke();
                isPlaying = false;
            }
            yield return null;
        }
    }

    //=================================================================================
    /// <summary>
    /// This function is used for calculation time of the video i.e PlayingTime / TotalTime.
    /// </summary>
    public void calculateTime()
    {
        if(vPlayer.isPlaying){
            rSec = slider.value - rMin * conversionFactor;
        
            if(rSec >= conversionFactor){
                rMin += 1;}
            }

            if(rSec < 0){
                rMin-= 1;
            }

        if(rMin < conversionFactor){
            TotalTimeText.text =  hrR.ToString("00") + ":"+ rMin.ToString("00") +":"+ rSec.ToString("00") +" / " +
            hr.ToString("00") + ":"+min.ToString("00") +":"+ sec.ToString("00");}

        if(rMin > conversionFactor){
            hrR = (int)(rMin / conversionFactor);
            
            TotalTimeText.text =  hrR.ToString("00") + ":"+ (rMin -  hrR * conversionFactor).ToString("00") +":"+ rSec.ToString("00") +" / " +
                hr.ToString("00") + ":"+min.ToString("00") +":"+ sec.ToString("00");}

    }


    //==============================================================================================
    /// <summary>
    /// This is for forwording video for 10 sec.
    /// </summary>
    public void Forwordvideo()
    {
        vPlayer.frame += forwordFrameAmount;
        videoFrameCount();
    }

     //==============================================================================================
    /// <summary>
    /// This is for Backword video for 10 sec.
    /// </summary>
    public void Backwordvideo()
    {
        vPlayer.frame -= forwordFrameAmount;
        videoFrameCount();
    }

    private void Update() {

        if(isPlaying){
            if(Input.GetKey(KeyCode.RightArrow))
            Forwordvideo();

            else if(Input.GetKey(KeyCode.LeftArrow)){
            Backwordvideo();}
        }
    }
}

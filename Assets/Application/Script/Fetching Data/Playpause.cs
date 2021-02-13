using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class Playpause : MonoBehaviour
{
    public              VideoPlayer             videoPlayer;
    public bool                                 Isplaying = true;
    public              UnityEvent              WhenPlaying, WhenNotPlaying, WhenCompleted;
    public              bool                    playPauseUsingKeyboardArrowkey = false;
    public static Playpause _instance = null;
    private void Awake() {
        if(_instance == null)
            _instance = this;
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
       if(playPauseUsingKeyboardArrowkey){
        if(Input.GetKeyDown("space")){
            playPausevideo();}
       }
    }

//=================================================================================================
/// <summary>
/// This is for play/pause video.
/// </summary>
    public void playPausevideo()
    {
        Isplaying = !Isplaying;
        if(Isplaying){
            WhenPlaying.Invoke();
            videoPlayer.Play();
            
        }
        if(!Isplaying){
            WhenNotPlaying.Invoke();
            videoPlayer.Pause();
        }
    }
}

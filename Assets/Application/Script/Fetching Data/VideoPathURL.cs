using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.IO;
using UnityEngine.Events;
public class VideoPathURL : MonoBehaviour
{
    
    private             VideoPlayer             videoPlayer;
    public              Playpause               playpause;
    //=====================================================================
    /// <summary>
    /// Creating this scrit singletone.
    /// </summary>
    public static VideoPathURL _instance = null;
    private void Awake() {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    //=============================================================================
    /// <summary>
    /// This function is called from MainMenu.cs and is used for assigning video name to the video player.
    /// </summary>
    /// <param name="str"></param>
    public void playOnButtonPress(string str)
    {
        if(playpause != null)
            videoPlayer = playpause.videoPlayer;


        if(VideoLocation.videoLocationPath == "Persistent Data Path")
        {
            videoPlayer.url = "File://" + Application.persistentDataPath+"/" + str;
        }

        if(VideoLocation.videoLocationPath == "StreamingAsset Path")
        {
            videoPlayer.url = Application.dataPath + "/StreamingAssets/" + str;
        }
        if(VideoLocation.videoLocationPath == "Browse Folder")
        {
            videoPlayer.url = VideoLocation.BrowsePath + "/"+ str;
        }
        
        

        videoPlayer.Play();
    }
}
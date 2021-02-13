using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
   
    public          List<string>            TrackList = new List<string>();
    public          Button                  Nbtn, Pbtn;
    public          ForwordRewindVideo      forwordRewindVideo;
    public static   MainMenu                _instance = null;
    public          AnimationController     animationController;

    public          ToogleButton            toggleButton;
    public          ControlBrightenes       controlBrightenes;
    public          TextMeshProUGUI         nextVideoName;
    public          Text                             CurrentVideoName;
    [Header("<----------Drop TMPro For VideoNumber---------->")]
    public          TextMeshProUGUI         VNumber;
    public             List<string>         TrackVideoName = new List<string>();
    private void Awake() {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    //==========================================================================================================
    /// <summary>
    /// This function to initialize or call the function in start, i.e when scene is loaded.
    /// </summary>
    private void Start() {

         Nbtn.onClick.AddListener(()=> {
             nextVideoToPlay(Nbtn.GetComponent<VideoName>().button_id, Nbtn.GetComponent<VideoName>().videoName.text);
         });


         Pbtn.onClick.AddListener(()=> {
             nextVideoToPlay(Pbtn.GetComponent<VideoName>().button_id, Pbtn.GetComponent<VideoName>().videoName.text);
         });
    }

    //==========================================================================================================
    /// <summary>
    /// This function is called when video changes automatically after completing video and called from "Loading.cs" script after 100% done
    /// </summary>
    public void playNextVideo()
    {
        nextVideoToPlay(Nbtn.GetComponent<VideoName>().button_id, Nbtn.GetComponent<VideoName>().videoName.text);
    }



    public void replay()
    {
        nextVideoToPlay((Nbtn.GetComponent<VideoName>().button_id -1), TrackList[(Nbtn.GetComponent<VideoName>().button_id -1)]);
    }

    //===========================================================================================================
    /// <summary>
    /// This function is called from "VideoName.cs" for assigning next and previous track name.
    /// </summary>
    /// <param name="IndexNumber">Current index number of video Playing</param>
    public void nextVideoToPlay(int IndexNumber, string ClipName)
    {

        if(CurrentVideoName != null)
            CurrentVideoName.text = TrackVideoName[IndexNumber];

        if(animationController != null)
            if(animationController.Animationlist[1].IsActive)
                toggleButton._GetToggleMode();

        if(controlBrightenes != null)
            controlBrightenes.playBackSpeed.value = 1.0f;

        if(IndexNumber == 0){
            Pbtn.interactable = false;
            Nbtn.interactable = true;}

        if(IndexNumber == (TrackList.Count-1)){
            Pbtn.interactable = true;
             Nbtn.interactable = false;}

        if(IndexNumber > 0 && IndexNumber < (TrackList.Count-1)){
            Pbtn.interactable = true;
            Nbtn.interactable = true;}

        if(IndexNumber < TrackList.Count-1){
            Nbtn.GetComponentInChildren<Text>().text = TrackList[IndexNumber+1];
            Nbtn.GetComponent<VideoName>().button_id = IndexNumber + 1;

            if(nextVideoName != null)
                nextVideoName.text = TrackVideoName[IndexNumber+1];
        }

        if(IndexNumber >= 1){
            Pbtn.GetComponentInChildren<Text>().text = TrackList[IndexNumber -1];
            Pbtn.GetComponent<VideoName>().button_id = IndexNumber - 1;
            }

        

        VideoPathURL._instance.playOnButtonPress(ClipName);

        if(forwordRewindVideo != null)
            forwordRewindVideo._calculateVideoFrame();

        VNumber.text = "Video Number : "+ (IndexNumber+1).ToString() + " OF " + TrackList.Count;
        
    }


    private void OnDisable() {
        TrackList.Clear();
        TrackVideoName.Clear();
    }
}
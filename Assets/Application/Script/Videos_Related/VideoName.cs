using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public enum MainButton
{
    MainTrackButton,
    NextPrevButton,
}
public class VideoName : MonoBehaviour
{
    // Start is called before the first frame update
    public static string vName;
    public Text videoName;
    public int button_id;
    public MainButton mainButton;
    //====================================================
    /// <summary>
    /// This is for making class a singletone, so that we can accwss the variables and can call functions as well.
    /// </summary>
    public static VideoName _instance = null;
    private void Awake() {
        if(_instance == null)
        {
            _instance  = this;
        }
    }

    private void Start() {
        Button button = GetComponent<Button>();
        if(MainButton.MainTrackButton == mainButton){
            button.onClick.AddListener(()=> {
            GetVideoName(button.name);});
        }
    }
    //======================================================================
    /// <summary>
    /// This function is get video name while pressing button to play.
    /// </summary>
    /// <param name="str">Video Name</param>
    public void GetVideoName(string str)
    {
        vName = str;
        InstantiateButton._instance.VideoPlay();
        MainMenu._instance.nextVideoToPlay(button_id, str);
    }
}

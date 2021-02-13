using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.IO;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine.Events;

public class FetchVideofile : MonoBehaviour
{
    public string URL;
    private List<FileInfo> infos = new List<FileInfo>();
    public List<string> str = new List<string>();
    public MainMenu mainMenu;
    public InstantiateButton instantiateButton;
    private int totalVideo;
    Regex regex;
    [Header("<---------CLASS CONTAINING VIDEO COMPATIBILITY---------->")]
    public videoFormat videoFormat;
    [Header("<---------CLASS CONTAINING VIDEO AVAILABILITY------------>")]
    public VideoAvailableOrNot VideoAvailableOrNot;
    public static FetchVideofile _instance = null;
    private void Awake() {
        if(_instance == null)
        {
            _instance = this;
        }
    }
    void Start()
    {
        getURL(VideoLocation.videoLocationPath);
    }
    

    //==============================================================================
    /// <summary>
    /// this function is for geeting all file from the directoy.
    /// </summary>
    /// <param name="PathName">Path of the video</param>
    public void allVideoInformation(string PathName)
    {

        DirectoryInfo  dir = new DirectoryInfo(PathName);
        infos = new List<FileInfo>(dir.GetFiles("*.*"));

        if(infos.Count != 0)
        {
            foreach (var xyz in infos)
            {
                for (int i = 0; i < videoFormat.videoCompatibility.Length; i++)
                {
                    if(xyz.Extension == videoFormat.videoCompatibility[i])
                    {
                        totalVideo+=1;
                        InstantiateButton._instance.ButtonInstantiate();
                        instantiateButton.ButtonInstantiate();

                        _SplitString(xyz.Name);

                        if(mainMenu != null)
                            mainMenu.TrackList.Add(xyz.Name); //Adding all track list to TrackList in MainMenu script

                        InstantiateButton._instance.temp.GetComponentInChildren<Button>().name = xyz.Name;
                        instantiateButton.temp.GetComponent<Button>().name = xyz.Name;
                        
                    }
                }
            }
            VideoAvailableOrNot.checkEmptyCondition(str, URL);
        }
    }

//==================================================================================================
/// <summary>
/// This function is used for splitting/separate the string according to our need,  In this, function . (dot) is use for separation 
/// </summary>
/// <param name="str1"></param>
    public void _SplitString(string str1)
    {
        string[] result = str1.Split('.');
        str.Add(result[0]);

        InstantiateButton._instance.temp.GetComponentInChildren<VideoName>().videoName.text = result[0];

        instantiateButton.temp.GetComponentInChildren<VideoListMenu>().VideoNameText.text = result[0];

        for (int i = 0; i < totalVideo; i++)
        {
            instantiateButton.temp.GetComponentInChildren<VideoListMenu>().SerialNumberText.text = (i+1).ToString();

        }

        if(mainMenu != null)
                mainMenu.TrackVideoName.Add(result[0]); //Adding all track list to VeoName Without Extension in MainMenu script.
        
    }

    //===============================================================================================
    /// <summary>
    /// This function is for getting the path from where video has to fetched.
    /// </summary>
    /// <param name="str">path of the video</param>
    public void getURL(string str)
    {
        switch (str)
        {
            case "Persistent Data Path" : URL = "File://" + Application.persistentDataPath;
            allVideoInformation(Application.persistentDataPath);
            break;

            case "StreamingAsset Path" :
            URL = Application.dataPath + "/StreamingAssets";
            allVideoInformation(Application.streamingAssetsPath);
            break;

            case "Browse Folder" : 
            URL = VideoLocation.BrowsePath;
            allVideoInformation(URL);
            break;
            
            default:
            break;
        }
    }
}
//========================================================
/// <summary>
/// This class is for all video video format supported in Unity.
/// </summary>
[System.Serializable]
public class videoFormat
{
    public string[] videoCompatibility = {".mp4", ".avi" , ".asf", ".dv", ".mov", ".m4v", ".mpg", ".mpeg", ".ogv", "vp8", ".webm", ".wmv"};
}


//========================================================
/// <summary>
/// This class is for Check wheather Track list is empty or nott.
/// </summary>
[System.Serializable]
public class VideoAvailableOrNot
{
        public UnityEvent WhenListIsEmpty,whenVideoFound;
        public TextMeshProUGUI msgText;
        public void checkEmptyCondition(List<string> TrackList, string Location)
        {
            if(TrackList.Count == 0){
                WhenListIsEmpty.Invoke();
                
                msgText.text = "Please put videos you want to play in " + "'" + Location 
                + "'" +" Location and click refresh button. NOTE : video formate should be in {.mp4, .avi , .asf, .dv, .mov,.m4v, .mpg, .mpeg, .ogv, .vp8, .webm, .wmv}";

            }
            else{
                whenVideoFound.Invoke();} 
        }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
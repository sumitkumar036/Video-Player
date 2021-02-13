using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class InstantiateButton : MonoBehaviour
{
    public GameObject obj;
    public GameObject temp;
    public List<Button> buttons = new List<Button>();
    private int buttonNumber;
    public GameObject MainPanal,VideoPanal;
    //=================================================================
    /// <summary>
    /// This is for making this class a singletone, so that we can access the variables and can call the function as well.
    /// </summary>
    public static InstantiateButton _instance = null;
    private void Awake() {
        if(_instance == null)
        {
            _instance = this;
        }
    }
    private void Start() {
        buttonNumber = -1;
    }
    //=====================================================================
    /// <summary>
    /// This function is used for instantiating the list of videos in the menu.
    /// </summary>
    public void ButtonInstantiate()
    {
        buttonNumber +=1;
        temp = Instantiate(obj,this.transform);
        temp.GetComponentInChildren<VideoName>().button_id = buttonNumber;//Assigning button id of each button.
    }
    //=============================================================================================
    /// <summary>
    /// This function  is to active and inactive panal on button press this function is called from videoName.cs
    /// </summary>
    public void VideoPlay()
    {
        if(MainPanal != null)
            MainPanal.SetActive(false);
            
        if(VideoPanal != null)
        VideoPanal.SetActive(true);
    }
}

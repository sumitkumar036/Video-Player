using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VideoLocation : MonoBehaviour
{
    public static string videoLocationPath, BrowsePath;
    public FileExplorer fileExplorer;
    public Button[] button;

    public static VideoLocation _instance = null;
    private void Awake() {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    private void Start() {
        for (int i = 0; i < button.Length; i++)
        {
            call(i);
        }
    }

    public void call(int value)
    {
        button[value].onClick.AddListener(delegate {
            getVideoLocation(button[value]);
        });
    }

    public void getVideoLocation(Button button)
    {
        videoLocationPath = button.name;
        BrowsePath = fileExplorer._path;
    }
}

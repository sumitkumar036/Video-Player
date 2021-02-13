using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class ThumbnailPlayer : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{

    public VideoPlayer vp;
    CreateTexture createTexture = new CreateTexture();
    private void Start() {
  
    }
//===========================================================================================
/// <summary>
/// This function called from FetchVideofile.cs to assign video.
/// </summary>
/// <param name="str"></param>
    public void setVideo(string str)
    {
      

        if(VideoLocation.videoLocationPath == "Persistent Data Path")
        {
            vp.url = "File://" + Application.persistentDataPath+"/" + str + ".mp4";
        }

        if(VideoLocation.videoLocationPath == "StreamingAsset Path")
        {
            vp.url = Application.dataPath + "/StreamingAssets/" + str + ".mp4";
        }
        if(VideoLocation.videoLocationPath == "Browse Folder")
        {
            vp.url = VideoLocation.BrowsePath + "/"+ str + ".mp4";
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        vp.Pause();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        vp.Play();
    }
}


//===============================================================================================
/// <summary>
/// This class is for creating RenderTexture at runtime.
/// </summary>
public class CreateTexture
{
    public RenderTexture rt;
    public void createRenderTexture()
    {
        rt = new RenderTexture(256, 256, 24, RenderTextureFormat.ARGB32);
        rt.Create();
    }
}
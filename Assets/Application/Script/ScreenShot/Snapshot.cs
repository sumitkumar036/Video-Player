using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public enum ScreenshotType
{
    withoutUIElement,
    withUIElement,
};
public enum SnapshotName
{

    dateTime,
    ParticularString,
    Default,
};

public class Snapshot : MonoBehaviour
{

    private bool Ready = false;
    [Header("<-----Enter Height & width of image to be captured---------->")]
    
    public int height;
    public int width;
    [Header("<-----Drop the Image on which captured image will be shown-->")]
    public Image SnapImage;
    private Sprite sprite;
    private byte[] bytes;
    private Texture2D screenshot;
    [Header("<-----Drop here the Maincamera ---------------------------->")]
    public Camera cam;
    [Header("<-----Drop here the Canvas -------------------------------->")]
    public Canvas canvas;

    [Header("<-----Choose Snapshot type to be taken--------------------->")]
    public ScreenshotType screenshotType;
    [Header("<-----Choose Snapshot NameType----------------------------->")]
    public SnapshotName snapshotName;

    [Header("<-----Image Name if Selected SnapshotName ParticularString->")]
    public string Snapshotname;

    [Header("<-----Click onRunTime to capture--------------------------->")]
    public bool Capture = false;
    void Start()
    {

    }

    //===================================================================================
    /// <summary>
    /// /// This function is for saving Snapshot to the particular location.
    /// </summary>
    /// <param name="width">width of image</param>
    /// <param name="height">Height of image</param>
    /// <returns></returns>
    public static string CaptureScreenshot(int width, int height)
    {
        #if UNITY_ANDROID
               if(SnapshotName.ParticularString == snapshotName)
                    return string.Format(Application.persistentDataPath + "/"+ Snapshotname +".png");

                if(SnapshotName.dateTime == snapshotName){
                    Snapshotname = System.DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
                    return string.Format(Application.persistentDataPath + "/"+ Snapshotname+".png");}
        #endif
        
        return null;
    }

    //=======================================================================================
    /// <summary>
    /// This function is for capture snashot when called.
    /// </summary>
    public void TakeScreenShot()
    {
        Ready = true;
        if(ScreenshotType.withUIElement == screenshotType)
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = cam;
            canvas.sortingOrder = 100;
        }
    }
    //==========================================================================================
    /// <summary>
    /// This function called for process of talking snapshot.
    /// </summary>
    void LateUpdate()
    {
        if (Ready)
        {
            RenderTexture r = new RenderTexture(width, height, 24);
            cam.targetTexture = r;
            screenshot = new Texture2D(width, height, TextureFormat.RGB24, false);
            cam.Render();
         
            RenderTexture.active = r;
            screenshot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            cam.targetTexture = null;
            RenderTexture.active = null;
            Destroy(r);
            bytes = screenshot.EncodeToPNG();
            string filename = CaptureScreenshot(width, height);

            #if UNITY_STANDALONE_WIN
              if(SnapshotName.ParticularString == snapshotName){
                    System.IO.File.WriteAllBytes(Application.dataPath + "/StreamingAssets"+ "/Screenshots/" +Snapshotname+".png", bytes);}

                if(SnapshotName.dateTime == snapshotName){
                     Snapshotname = System.DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss");
                    System.IO.File.WriteAllBytes(Application.dataPath + "/StreamingAssets "+ "/Screenshots/"+ Snapshotname +".png", bytes);}
            #endif

            #if UNITY_ANDROID
                System.IO.File.WriteAllBytes(filename, bytes);
            #endif

            Ready = false;

            if(SnapImage != null)
               SnapImage.sprite = LoadPNG();
        }
    }

    //================================================================================================
    /// <summary>
    /// This function is for converting texture to PNG
    /// </summary>
    /// <returns></returns>
    private Sprite LoadPNG()
    {
        string url = "";
        Texture2D texture = null;
        byte[] fileData;

        #if UNITY_ANDROID
                if(SnapshotName.ParticularString == snapshotName)
                    url = Application.persistentDataPath + "/StreamingAssets/ "+ Snapshotname +".png";

                if(SnapshotName.dateTime == snapshotName){
                    url = Application.persistentDataPath + "/StreamingAssets/ "+ Snapshotname +".png";}
        #endif


        #if UNITY_STANDALONE_WIN
            if(SnapshotName.ParticularString == snapshotName){
                    url = Application.dataPath + "/StreamingAssets/ "+ Snapshotname +".png";}

            if(SnapshotName.dateTime == snapshotName){
                url = Application.dataPath + "/StreamingAssets/ "+ Snapshotname +".png";}
        #endif
       // url = Application.dataPath + "/StreamingAssets/ "+ Snapshotname +".png";
        
        if (File.Exists(url))
        {
            fileData = File.ReadAllBytes(url);
            texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);
        }

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
        return sprite;
    }

    private void OnValidate() {
        if(Capture)
        {
            Capture = false;
            TakeScreenShot();
        }
    }
}
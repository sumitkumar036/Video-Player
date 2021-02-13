using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FetchImageFromWWW : MonoBehaviour
{
    public string url = "https://imagevars.gulfnews.com/2019/07/24/190724-Salman-Khan_16c24162f1f_medium.jpg";
    public RawImage rawImage;

    // automatically called when game started
    void Start()
    {
        StartCoroutine(LoadFromLikeCoroutine());
    }

   
    private IEnumerator LoadFromLikeCoroutine()
    {
        WWW wwwLoader = new WWW(url);
        yield return wwwLoader;           
        rawImage.texture = wwwLoader.texture;
    }
}
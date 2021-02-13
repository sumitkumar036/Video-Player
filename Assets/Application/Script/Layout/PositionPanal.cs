using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPanal : MonoBehaviour
{

    [Header("<-----Put text[0] & Button[1]----->")]
    public GameObject[] obj;
    [Header("<-----List of Position value------>")]
    public List<PositionValue> positionValues = new List<PositionValue>();
    void Start()
    {
        
    }
    public void setPositionVertical()
    {
        obj[0].transform.localPosition = positionValues[0].Textposition;
        obj[0].GetComponent<RectTransform>().sizeDelta = positionValues[0].TextsizeDelta;
        obj[1].transform.localPosition = positionValues[0].Buttonposition;

        if(obj.Length == 3){
            obj[2].transform.localPosition = positionValues[0].Imageposition;
            obj[2].GetComponent<RectTransform>().sizeDelta = positionValues[0].ImagesizeDelta;
        }
     }

    public void setPositionHorizontal()
    {
        obj[0].transform.localPosition = positionValues[1].Textposition;
        obj[0].GetComponent<RectTransform>().sizeDelta = positionValues[1].TextsizeDelta;
        obj[1].transform.localPosition = positionValues[1].Buttonposition;

        if(obj.Length == 3){
            obj[2].transform.localPosition = positionValues[1].Imageposition;
            obj[2].GetComponent<RectTransform>().sizeDelta = positionValues[1].ImagesizeDelta;
        }
    }
}

[System.Serializable]
public class PositionValue
{
    public string str;
    [Header("<-----Enter Text size & position--------->")]
    public Vector3 Textposition;
    public Vector2 TextsizeDelta;
    [Header("<-----Enter Button size & position----->")]
    public Vector3 Buttonposition;
    public Vector2 ButtonsizeDelta;
    [Header("<-----Enter Image size & position----->")]
    public Vector3 Imageposition;
    public Vector2 ImagesizeDelta;
}

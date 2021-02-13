using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gridverticalayout : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LayOutContainer;
    [Header("<-----Horizontal Padding----->")]
    public int[] Hpadding;
    public int HcellX, HcellY, HspacingX, HspacingY, HconstraintCount;

    [Header("<-----Vertical Padding------->")]
    public int[] VPadding;
    public int VcellX, VcellY, VspacingX, VspacingY,VconstraintCount;
    public List<PositionPanal> panalObjectPositions = new List<PositionPanal>();
  //  public static string layout;
    public int len;
    void Start()
    {
        len = LayOutContainer.GetComponentsInChildren<PositionPanal>().Length;
        for (int i = 0; i < len; i++)
        {
            panalObjectPositions.Add(LayOutContainer.GetComponentsInChildren<PositionPanal>()[i]);
        }
    }

    
     public void SetHorizontal()
    {
        GridLayoutGroup gridLayoutGroup;
        gridLayoutGroup = LayOutContainer.GetComponent<GridLayoutGroup>();

        gridLayoutGroup.cellSize = new Vector2(HcellX, HcellY);
        gridLayoutGroup.spacing = new Vector2(HspacingX, HspacingY);
        gridLayoutGroup.padding.left = Hpadding[0]; 
        gridLayoutGroup.padding.right = Hpadding[1];
        gridLayoutGroup.padding.top = Hpadding[2];
        gridLayoutGroup.padding.bottom = Hpadding[3];

        gridLayoutGroup.startCorner = GridLayoutGroup.Corner.UpperLeft;
        gridLayoutGroup.startAxis = GridLayoutGroup.Axis.Horizontal;
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = HconstraintCount;
        gridLayoutGroup.childAlignment = TextAnchor.UpperLeft;

        ContentSizeFitter contentSizeFitter;
        contentSizeFitter = LayOutContainer.GetComponent<ContentSizeFitter>();

        contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.MinSize;
        contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        for (int i = 0; i < len; i++)
        {
            panalObjectPositions[i].setPositionHorizontal();
        }
        
    }
    public void SetVertical()
    {
        GridLayoutGroup gridLayoutGroup;
        gridLayoutGroup = LayOutContainer.GetComponent<GridLayoutGroup>();

        gridLayoutGroup.cellSize = new Vector2(VcellX, VcellY);
        gridLayoutGroup.spacing = new Vector2(VspacingX, VspacingY);
        gridLayoutGroup.padding.left = VPadding[0]; 
        gridLayoutGroup.padding.right = VPadding[1];
        gridLayoutGroup.padding.top = VPadding[2];
        gridLayoutGroup.padding.bottom = VPadding[3];
        gridLayoutGroup.startAxis = GridLayoutGroup.Axis.Vertical;
        gridLayoutGroup.startCorner = GridLayoutGroup.Corner.UpperLeft;
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = VconstraintCount;


        ContentSizeFitter contentSizeFitter;
        contentSizeFitter = LayOutContainer.GetComponent<ContentSizeFitter>();

        contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.MinSize;
        contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        for (int i = 0; i < len; i++)
        {
            panalObjectPositions[i].setPositionVertical();
        }
    }

    public void SetLayOut(string str)
    {
        //layout = str;
        switch (str)
        {
            case "Vertical" : SetVertical();
            break;

            case "Horizontal" : SetHorizontal();
            break;

            default:
            break;

        }
    }
}

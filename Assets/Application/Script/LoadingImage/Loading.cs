using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;


public enum TextType
{
    TextMeshPro,
    NormalText,
};
public class Loading : MonoBehaviour
{
    
    public              Image                   FillImage;
    public              TextMeshProUGUI         percentageText;
    public              Text                    textPercentage;
    public bool                                 load = false;
    public float                                AmountToFill;
    public              UnityEvent              AfterCompleted;
    public              TextType                textType;

    
    void Update()
    {
        if(load)
             LoadingStart();
    }

    public void LoadingStart()
    {
        if(FillImage.fillAmount <= 1){
            FillImage.fillAmount += AmountToFill;
            if(TextType.TextMeshPro == textType)
                percentageText.text = ((int)(FillImage.fillAmount * 100)).ToString();

            if(TextType.NormalText == textType)
                textPercentage.text = ((int)(FillImage.fillAmount * 100)).ToString();
        }
        if(FillImage.fillAmount >= 1){
            AfterCompleted.Invoke();
            FillImage.fillAmount = 0;
        }
    }

    private void OnEnable() {
        load = true;
        FillImage.fillAmount = 0;
    }

    private void OnDisable() {
        load = false;
        FillImage.fillAmount = 0;
    }
}

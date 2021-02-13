using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public enum ObjectType
{
    _Button,
    Panal,
    None,
};

public class ButtonScaler : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    private Button _button;
    private Transform _panal;
    public float scaler;
    public float PreScale;
    public Text txt;
    public Color32 clr;
    public UnityEvent WhenEnterd, WhenExit;
    public ObjectType objectType;
    void Start()
    {
        if(ObjectType._Button == objectType)
        {
            _button = this.GetComponent<Button>();
            txt = _button.GetComponentInChildren<Text>();
        }
           

        if(ObjectType.Panal == objectType)
           _panal = this.GetComponent<Transform>();
        
        PreScale = this.transform.localScale.x;
    }

    //==============================================================================
    /// <summary>
    /// This function is for fireEvent when cursor is Entered the button on which script is attached.
    /// </summary>
    /// <param name="eventData">provide PointerEvent data</param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        scaleButton(true);
        WhenEnterd.Invoke();
    }

     //==============================================================================
    /// <summary>
    /// This function is for fireEvent when cursor is Exited from the button on which script is attached.
    /// </summary>
    /// <param name="eventData">provide PointerEvent data</param>
    public void OnPointerExit(PointerEventData eventData)
    {
         scaleButton(false);
         WhenExit.Invoke();
    }

    //===============================================================================
    /// <summary>
    /// This function is for scalling button by scaler variable.
    /// </summary>
    /// <param name="b">Boolean for Entered / Exit</param>
    public void scaleButton(bool b)
    {
        if(b)
        {
            if(ObjectType._Button == objectType){
            _button.transform.localScale = new Vector3(scaler, scaler, scaler);
             if(txt !=null)
            txt.color = clr;}

            if(ObjectType.Panal == objectType){
            _panal.transform.localScale = new Vector3(scaler, scaler, scaler);
            if(txt !=null)
                txt.color = clr;}

        }
        if(!b)
        {
           if(ObjectType._Button == objectType){
            _button.transform.localScale = new Vector3(PreScale, PreScale, PreScale);
             if(txt !=null)
            txt.color = Color.white;}

            if(ObjectType.Panal == objectType){
            _panal.transform.localScale = new Vector3(PreScale, PreScale, PreScale);
            if(txt!=null)
                txt.color = Color.white;}
        }
    }
}

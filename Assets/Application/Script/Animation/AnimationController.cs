using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum AnimationType{playAutomatically,PlayByButton, None,};

public enum wMode{Default, Loop, Once, pingPong, clampForever,};

public class AnimationController : MonoBehaviour
{
    public int CurrentAnimation;//current animation number i.e, animation which is currentl playing
    [Header("<---------------List of all animation------------->")]

    public List<AnimationList> Animationlist = new List<AnimationList>();//serialized class declaration
    [Header("<---------------Click Here for Getting Name----->")]
    public bool getArrayNameByAnimationName;

    void Start()
    {
        for (int i = 0; i < Animationlist.Count; i++){
            if(Animationlist[i].animationType == AnimationType.playAutomatically){
                 _playAnimation(i);}
        }
    }

    //=================================================================================================================
    /// <summary>
    /// This function is for playing animation by passing animation number
    /// </summary>
    /// <param name="i">Animation number want to play</param>
    public void _playAnimation(int i)
    {
        CurrentAnimation = i;
        Animationlist[i].WhenAnimationStart.Invoke();
              
        if(Animationlist[i].wrap == wMode.Loop)
            Animationlist[i].animation.clip.wrapMode = WrapMode.Loop;

        if(Animationlist[i].wrap == wMode.Once)
            Animationlist[i].animation.clip.wrapMode = WrapMode.Once;

        if(Animationlist[i].wrap == wMode.pingPong)
            Animationlist[i].animation.clip.wrapMode = WrapMode.PingPong;

        if(Animationlist[i].wrap == wMode.Default)
            Animationlist[i].animation.clip.wrapMode = WrapMode.Default;

        if(Animationlist[i].wrap == wMode.clampForever)
            Animationlist[i].animation.clip.wrapMode = WrapMode.ClampForever;

        Animationlist[i].animTotalFrame = Animationlist[i].animation.clip.length * Animationlist[i].animation.clip.frameRate;
        Animationlist[i].animCurrentFrame =  Animationlist[i].animation[Animationlist[i].animation.clip.name].weight * Animationlist[i].animTotalFrame;
            
        Animationlist[i].animation[Animationlist[i].animation.clip.name].speed = Animationlist[i].animSpeed;

        if(Animationlist[i].animation[Animationlist[i].animation.clip.name].speed < 0)
            Animationlist[i].animation[Animationlist[i].animation.clip.name].time = Animationlist[i].animation[Animationlist[i].animation.clip.name].length;
        
         if(Animationlist[i].animation[Animationlist[i].animation.clip.name].speed > 0)
            Animationlist[i].animation[Animationlist[i].animation.clip.name].time = 0;

       
        Animationlist[i].animation.CrossFade(Animationlist[i].animation.clip.name);

        
        for (int j = 0; j < Animationlist.Count; j++)
        {
            if(j == i)
                Animationlist[j].IsActive = true;
            else
                Animationlist[j].IsActive = false;
        }
        Invoke("whenComplete",Animationlist[i].animation[Animationlist[i].animation.clip.name].length);
    }

    //========================================================================================================================
    /// <summary>
    /// This function is for play and pause current animation.
    /// </summary>
    /// <param name="b">Parameter for play or pause animation</param>
    public void PausePlayCurrentAnimation(bool b)
    {
        if(b)
            Animationlist[CurrentAnimation].animation[Animationlist[CurrentAnimation].animation.clip.name].speed = Animationlist[CurrentAnimation].animSpeed;
        if(!b){
            Animationlist[CurrentAnimation].animation[Animationlist[CurrentAnimation].animation.clip.name].speed = 0;}
    }

    //=========================================================================================================================
    /// <summary>
    /// This function called when current animation is completed
    /// </summary>
    public void whenComplete()
    {
        Animationlist[CurrentAnimation].WhenAnimationComplete.Invoke();
        Debug.Log("Animation => "+CurrentAnimation+" Completed.");
    }

    private void OnValidate() {
        if(getArrayNameByAnimationName){
            for (int i = 0; i < Animationlist.Count; i++)
            {
                if(Animationlist[i].animation != null)
                    Animationlist[i].str = i+ " => " + Animationlist[i].animation.name;
                else
                    Animationlist[i].str = i +" => " + "Animation Not Available";
            }
            getArrayNameByAnimationName = false;
        }
    }

    public void calculateAnimationFrame(int i)
    {
        
    }
}

[System.Serializable]
public class AnimationList
{
    public string str;
    [Header("<-------------------------Drag & Drop Animation Here for play--------------------------------------->")]
    public Animation animation;
    [Header("<-------------------------Set Animation Speed( +ve or -ve for forword/Reverse play)------------------>")]
    public float animSpeed;
    [Header("<-------------------------Animation Frame Information(total frame & current frame running)------------>")]
    public float animTotalFrame;
    public float animCurrentFrame;
    [Header("<-------------------------Select AnimationType(Auto_play/Play_By_Clicking Button)--------------------->")]
    public AnimationType animationType;
    public bool IsActive = false;
    [Header("<-------------------------animationWrapeMode(proprty of animation to play)----------------------------->")]
    public wMode wrap;
    [Header("<-------------------------Event on animation start (call any function when animation get started)------->")]
    public UnityEvent WhenAnimationStart;
    [Header("<-------------------------Event on animation Complete (call any function when animation get Completed)-->")]
    
    public UnityEvent WhenAnimationComplete;
}

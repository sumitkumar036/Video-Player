using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ButtonType
{
    ButtonSound,
    CameraSound,
    MachineSound,
    Others,
};
public class ButtonSound : MonoBehaviour
{
    public AudioSource src;
    public SoundCategory[] soundCategory;
    public bool GetArrayName = false;

    private void Start() {
        for (int i = 0; i < soundCategory.Length; i++)
        {
             soundCategory[i].playSound();
        }
    }

    private void OnValidate() {
        if(GetArrayName)
        {
            for (int i = 0; i < soundCategory.Length; i++)
            {
                soundCategory[i].str = i + " => "+ soundCategory[i].button.name;
            }
            GetArrayName = false;
        }
    }
}

[System.Serializable]
public class SoundCategory{
    public string str;
    public AudioClip audioClip;
    public Button button;
    public ButtonType buttonType;
    ButtonSound buttonSound;
    public void playSound()
    {
        button.onClick.AddListener(()=>{
            PlyaSoundOnClick();});
    }

    public void PlyaSoundOnClick()
    {
        buttonSound.src.clip = audioClip;
        buttonSound.src.Play();
    }
}

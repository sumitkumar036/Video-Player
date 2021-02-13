
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
//[System.Flags]
public enum LoadType{LoadSceneByName,LoadSceneBySceneIndex,};
public class SceneManagement : MonoBehaviour
{
    //---------------------------------------------------------------
    /// <summary>
    /// Enum definition
    /// </summary>
    [Header("<-----Choose Enum Type----->")]
    //[EnumFlag]
    public LoadType loadType;
    public string LoadSceneByNameVar;
    public int LoadSceneBySceneIndexVar;

    public List<Button> buttons = new List<Button>();
    //---------------------------------------------------------------------
    /// <summary>
    /// Delegate declaration to call function
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="SceneIndex"></param>
    public delegate void SceneChanging(string sceneName, int SceneIndex);
    public bool xyz;
    public int z;

    //---------------------------------------------------------------------
    private void Start() {
        for (int i = 0; i < buttons.Count; i++)
        {
             ButtonPressed(i);
        }
    }

    public void ButtonPressed(int i)
    {
     buttons[i].onClick.AddListener(()=>{
                  ChangeSceneByName(buttons[i].name, LoadSceneBySceneIndexVar);
             });
    }

    /// <summary>
    /// Used to change scene using sceneName or BuildIndex.
    /// </summary>
    /// <param name="sceneName">SceneName to be passed</param>
    /// <param name="SceneIndex">Scene BuildIndex to be passed</param>

    //--------------------------------------------------------------------
    public void ChangeSceneByName(string sceneName,int SceneIndex)
    {
        if(loadType == LoadType.LoadSceneByName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
        if(loadType == LoadType.LoadSceneBySceneIndex)
        {
            SceneManager.LoadSceneAsync(SceneIndex);
        }
    }
}

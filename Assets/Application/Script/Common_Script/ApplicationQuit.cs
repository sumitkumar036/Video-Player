using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationQuit : MonoBehaviour
{
  
  public void _Quit()
  {
      Application.Quit();
  }

  public void refreshScene()
  {
      SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
  }
}

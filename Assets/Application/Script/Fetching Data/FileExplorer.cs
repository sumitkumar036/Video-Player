using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFB;
using TMPro;

public class FileExplorer : MonoBehaviour
{
    // Start is called before the first frame update
    public string _path;


    public void _openFileexplorer()
    {
        
        var paths = StandaloneFileBrowser.OpenFolderPanel("Select Folder", "", true);
        WriteResult(paths);
    }

      public void WriteResult(string[] paths) {
        if (paths.Length == 0) {
            return;
        }

        _path = "";
        foreach (var p in paths) {
            _path += p;// + "\n";
        }
    }

    public void WriteResult(string path) {
        _path = path;
    }

}

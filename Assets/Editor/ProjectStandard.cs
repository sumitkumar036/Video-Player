using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ProjectStandard : MonoBehaviour {
    // Start is called before the first frame update

    [MenuItem ("MRSINGH/SIMULANIS")]

    public static void MRSINGH () {

        string path = Application.dataPath + " / ";
        Directory.CreateDirectory (path + "Application");

        Directory.CreateDirectory (path + "Application/_Scene");
        Directory.CreateDirectory (path + "Application/Script");

        Directory.CreateDirectory (path + "Application/FBX");
        Directory.CreateDirectory (path + "Application/FBX/Models");
        Directory.CreateDirectory (path + "Application/FBX/Animations");

        Directory.CreateDirectory (path + "Application/UI");
        Directory.CreateDirectory (path + "Application/UI/Popups");
        Directory.CreateDirectory (path + "Application/UI/Others");

        Directory.CreateDirectory (path + "Application/Audio");
        Directory.CreateDirectory (path + "Application/Audio/Voise Overs");
        Directory.CreateDirectory (path + "Application/Audio/Others");

        Directory.CreateDirectory (path + "Application/Custom");
        Directory.CreateDirectory (path + "Application/Custom/Package");
        Directory.CreateDirectory (path + "Application/Custom/Animation");

        Directory.CreateDirectory (path + "Application/Videos");

    }
}
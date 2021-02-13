using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryData : MonoBehaviour
{
    public IDictionary<int , string> mydict = new Dictionary<int , string>();//dictionary initialisation
    public VideoAudioMusicDetails[] videoAudioMusicDetails;
    public bool getData;
    public string str;

    private sumit sum = new sumit();
    void Start()
    {
        for (int i = 0; i < videoAudioMusicDetails.Length; i++)
        {
            str += string.Join("+", videoAudioMusicDetails[i].VideoName);
        }
        mydict.Add(1, str);
        Debug.Log(mydict[1]);


        sum.xyz("Called from start");
        Debug.Log(sum.calculateSum(36, 36));
    }

    private void OnValidate() {
        if(getData)
        {
            getData = false;
           
            for (int i = 0; i < videoAudioMusicDetails.Length; i++)
            {
                videoAudioMusicDetails[i].VideoNumber = i;
                videoAudioMusicDetails[i].VideoName = "sumit = > " + i.ToString();
            }
        }
    }
}


class sumit
{
    public void xyz(string c)
    {
        Debug.Log("!!!!!!!It's working!!!!!!!!  :"+c);
    }

    public int calculateSum(int x, int y)
    {
        int c = x + y;
        return c;
    }
}
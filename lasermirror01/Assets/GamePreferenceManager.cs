using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePreferenceManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadPrefs();
    }

    // Update is called once per frame
    void OnApplicationQuit()
    {
        SavePrefs();
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetFloat("audio", 5f);
        PlayerPrefs.Save();
    }

    public void LoadPrefs()
    {
        var score = PlayerPrefs.GetFloat("audio", 1f);
    }
}

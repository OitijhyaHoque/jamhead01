using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject player;
    public AudioSource walk, bgm;
    // Start is called before the first frame update
    void Start()
    {
        walk = player.GetComponent<AudioSource>();
    }
    public void change()
    {
        walk.volume = PlayerPrefs.GetFloat("audio", 1f);
        bgm.volume = PlayerPrefs.GetFloat("audio", 1f);
    }
}

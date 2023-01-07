using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource walkingsound;

    void Update()
    {
        bool condition = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        
        if (condition && (Time.timeScale > 0.001f))
        {
            walkingsound.enabled = true;
        }
        else
        {
            walkingsound.enabled = false;
        }
    }

}

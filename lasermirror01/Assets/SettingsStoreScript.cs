using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsStoreScript : MonoBehaviour
{
    public static string [] levelArray = { "Level1", "Level2", "Level3" };
    public static float controlSensitivity = 0.5f;
    public static float audioVolume = 1;

    public Slider audioSlider, controlSlider;

    public void changeVolume()
    {
        audioVolume = audioSlider.value;
    }

    public void changeSensitivity()
    {
        controlSensitivity = controlSlider.value;
    }
}

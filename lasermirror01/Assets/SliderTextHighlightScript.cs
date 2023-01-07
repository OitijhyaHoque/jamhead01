using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderTextHighlightScript : MonoBehaviour
{
    public GameObject slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.GetComponent<Slider>() == EventSystem.current)
        {
            Debug.Log("464646464644644644646464646446446446464646464464464");
        }
    }
}

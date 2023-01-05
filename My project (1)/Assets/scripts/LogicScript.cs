using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject nextLevelScreen;
    public DestinationScript dest;
    public int level = 1;
    public Text levelText;

    void Start()
    {
         level = 1;
        dest = GameObject.FindGameObjectWithTag("destination").GetComponent<DestinationScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void levelComplete()
    {
        nextLevelScreen.SetActive(true);
        
        
    }

    public void NextLevelPress()
    {
        Debug.Log("next level button pressed");
        level++;
        levelText.text = "Level : " +level.ToString();
        dest.hitThisLevel = false;

    }
}

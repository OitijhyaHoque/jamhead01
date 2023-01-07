using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject nextLevelScreen;
    public DestinationScript dest;
    public PauseMenuScript pScript;
    public int level = 1;
    public Text levelText;

    void Start()
    {
         level = LevelStorage.level;
        levelText.text = "Level : " + level.ToString();
        dest = GameObject.FindGameObjectWithTag("destination").GetComponent<DestinationScript>();
         pScript = GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseMenuScript>();
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
        LevelStorage.level = level;
        levelText.text = "Level : " +level.ToString();
        dest.hitThisLevel = false;

        SceneManager.LoadScene("Level2");
    }
    public void NextLevelPress2()
    {
        Debug.Log("next level button pressed");
        level++;
        LevelStorage.level = level;
        levelText.text = "Level : " + level.ToString();
        dest.hitThisLevel = false;

        SceneManager.LoadScene("Level3");
    }

    public void MainMenuPressNextlvl()
    {
        LevelStorage.level = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseClickInGame()
    {
        pScript.PauseUnpause();
    }


}

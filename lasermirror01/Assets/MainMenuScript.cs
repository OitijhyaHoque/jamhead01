using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject playButton, optionsButton, exitButton;
    public Button playButtonButton, optionsButtonButton, exitButtonButton;
    // Start is called before the first frame update
    void Start()
    {
        playButtonButton = playButton.GetComponent<Button>();
        optionsButtonButton = optionsButton.GetComponent<Button>();
        exitButtonButton = exitButton.GetComponent<Button>();

        playButtonButton.onClick.AddListener(GotoLevel1);
        optionsButtonButton.onClick.AddListener(GotoOptions);
        exitButtonButton.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GotoLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    void GotoOptions()
    {

    }

    void ExitGame()
    {
        Application.Quit();
    }
}

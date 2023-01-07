using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu, optionsMenu;
    public GameObject playButton, optionsButton, exitButton, optionBackButton;
    // public GameObject audioSliderObj, controlSliderObj;
    public Button playButtonButton, optionsButtonButton, exitButtonButton, optionBackButtonButton;

    public Slider audioSlider, controlSlider;


    // Start is called before the first frame update
    void Start()
    {
        playButtonButton = playButton.GetComponent<Button>();
        optionsButtonButton = optionsButton.GetComponent<Button>();
        exitButtonButton = exitButton.GetComponent<Button>();
        optionBackButtonButton = optionBackButton.GetComponent<Button>();

        playButtonButton.onClick.AddListener(GotoLevel1);
        optionsButtonButton.onClick.AddListener(GotoOptions);
        exitButtonButton.onClick.AddListener(ExitGame);
        optionBackButtonButton.onClick.AddListener(ExitOptions);

        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
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
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionBackButton);

        audioSlider.value = PlayerPrefs.GetFloat("audio", 1f);
        controlSlider.value = PlayerPrefs.GetFloat("sense", 0.5f);
    }

    void ExitOptions()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(playButton);

        PlayerPrefs.SetFloat("audio", audioSlider.value);
        PlayerPrefs.SetFloat("sense", controlSlider.value);

    }

    void ExitGame()
    {
        Application.Quit();
    }
}

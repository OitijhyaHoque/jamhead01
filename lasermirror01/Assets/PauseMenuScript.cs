using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    public static bool GameIsPaused = true;

    public GameObject pauseMenu, optionsMenu;
    public GameObject resumeButton, optionsButton, exitButton, exitOptionsButton;
    public Button resumeButtonButton, optionsButtonButton, exitButtonButton, exitOptionsButtonButton;

    public Slider audioSlider, controlSlider;

    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        
        resumeButtonButton = resumeButton.GetComponent<Button>();
        optionsButtonButton = optionsButton.GetComponent<Button>();
        exitButtonButton = exitButton.GetComponent<Button>();
        exitOptionsButtonButton = exitOptionsButton.GetComponent<Button>();
        
        resumeButtonButton.onClick.AddListener(PauseUnpause);
        optionsButtonButton.onClick.AddListener(OptionMenuOpener);
        exitButtonButton.onClick.AddListener(GotoMainMenu);
        exitOptionsButtonButton.onClick.AddListener(OptionMenuCloser);

        PauseUnpause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    void PauseUnpause()
    {
        if (!GameIsPaused)
        {
            pauseMenu.SetActive(true);
            optionsMenu.SetActive(false);
            Time.timeScale = 0f;

            // clear selection
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(resumeButton);

            GameIsPaused = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(false);
            Time.timeScale = 1f;

            GameIsPaused = false;
        }
    }

    void OptionMenuOpener()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(exitOptionsButton);

        audioSlider.value = PlayerPrefs.GetFloat("audio", 1f);
        controlSlider.value = PlayerPrefs.GetFloat("sense", 0.5f);
    }

    void OptionMenuCloser()
    {
        

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(resumeButton);

        PlayerPrefs.SetFloat("audio", audioSlider.value);
        PlayerPrefs.SetFloat("sense", controlSlider.value);
        audioManager.change();

        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false; //make sure to make the UI is transparent
    public GameObject pauseMenuUI; //make a gameobject of the pausemenu
    public AudioSource auPausing;

    [SerializeField] private GameObject gameOverObject;
    private GameOverHandler gameOverHandler;

    void Start()
    {
        pauseMenuUI.SetActive(false); //made it false to get it transparent
        Resume();

        gameOverHandler = gameOverObject.GetComponent<GameOverHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) { return; }
        if (gameOverHandler.IsGameOver()) { return; }

        if (GameIsPaused) { Resume(); }
        else { Pause(); }
    }

    void Resume()
    {
        auPausing.Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; //Time resume
        GameIsPaused = false;
    }

    void Pause()
    {
        auPausing.Play();
        pauseMenuUI.SetActive(true); //set the pause menu ui on false
        Time.timeScale = 0f; //Za Warudo
        GameIsPaused = true; //Gameobject is put on true

    }
}
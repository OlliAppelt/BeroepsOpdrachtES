using UnityEngine;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject UI;

    private bool gameIsOver;

    private void Start()
    {
        gameIsOver = false;
        UI.SetActive(false);
    }

    /// <summary>
    /// Check if a game over screen is on.
    /// </summary>
    /// <returns>
    /// If the game is over as boolean.
    /// </returns>
    public bool IsGameOver()
    {
        return gameIsOver;
    }

    /// <summary>
    /// Initiate the game over screen with the reason why.
    /// </summary>
    public void StartGameOver()
    {
        if(gameIsOver) { return; }

        UI.SetActive(true);
        Time.timeScale = 0f;
        gameIsOver = true;

        return;
    }
}

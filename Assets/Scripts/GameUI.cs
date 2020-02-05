using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText, endScreenHeader, endScreenScoreText;

    [SerializeField]
    private GameObject endScreen;

    public GameObject pauseScreen;

    // instance
    public static GameUI instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + GameManager.instance.score;
    }

    public void SetEndScreen(bool hasWon)
    {
        endScreen.SetActive(true);

        endScreenScoreText.text = "<b>Score</b>\n" + GameManager.instance.score;

        if (hasWon)
        {
            endScreenHeader.text = "You Win";
            endScreenHeader.color = Color.green;
        }
        else
        {
            endScreenHeader.text = "Game Over";
            endScreenHeader.color = Color.red;
        }
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnMenuButton()
    {
        if (GameManager.instance.paused)
            GameManager.instance.TogglePauseGame();

        SceneManager.LoadScene(0);
    }

    public void TogglePauseScreen (bool paused)
    {
        pauseScreen.SetActive(paused);
    }

    public void OnResumeButton()
    {
        GameManager.instance.TogglePauseGame();
    }
}

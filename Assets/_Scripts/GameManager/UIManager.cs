using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI liveText;
    private GameObject gameOverPanel;
    private GameObject gamePausePanel;
    void Start()
    {
        liveText = GameObject.Find("LiveTxt").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("ScoreTxt").GetComponent<TextMeshProUGUI>();
        gamePausePanel = GameObject.Find("GamePausePanel");
        gameOverPanel = GameObject.Find("GameOverPanel");
        gamePausePanel.SetActive(false);
        gameOverPanel.SetActive(false);

        liveText.text = "Lives: 3";
        scoreText.text = "Score: 0";
        GameManager.instance.OnLiveChangedHandler += OnLiveTxtChanged;
        GameManager.instance.OnScoreChangedHandler += OnScoreTxtChanged;
        GameManager.instance.OnGameStateUpdateHandler += OnGameStateUpdateUIChange;
    }

    private void OnGameStateUpdateUIChange(GameManager.GameState gameState)
    {
        switch (gameState)
        {
            case GameManager.GameState.Pausing:
                gamePausePanel.SetActive(true);
                break;
            case GameManager.GameState.Playing:
                gamePausePanel.SetActive(false);
                break;
            case GameManager.GameState.GameOver:
                gameOverPanel.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnLiveTxtChanged(int lives)
    {
        liveText.text = "Lives: " + lives;
    }
    void OnScoreTxtChanged(int score)
    {
        scoreText.text = "Score: " + score;
    }
    
}

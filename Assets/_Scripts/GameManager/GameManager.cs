using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Pausing,
        Playing,
        GameOver
    }
    public static GameManager instance;
    public GameState currGameState;
    public delegate void LivesChanged(int lives);
    public event LivesChanged OnLiveChangedHandler;
    public delegate void ScoreChanged(int score);
    public event ScoreChanged OnScoreChangedHandler;
    public delegate void GameStateUpdate(GameState gameState);
    public event GameStateUpdate OnGameStateUpdateHandler;

    public int score=0;
    public int lives=1;
    void Start()
    {
        instance = this;
        currGameState = GameState.Playing;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currGameState)
        {
            case GameState.Pausing:
                Time.timeScale = 0;
                break;
            case GameState.Playing:
                Time.timeScale = 1;
                break;
            case GameState.GameOver:
                Time.timeScale = 0;
                break;
        }
    }
    public void OnLiveChanged(int updateLives)
    {
        this.lives += updateLives;
        OnLiveChangedHandler?.Invoke(this.lives);
        if(this.lives <= 0)
        {
            currGameState = GameState.GameOver;
            OnGameStateUpdateHandler?.Invoke(currGameState);
        }
    }   
    public void OnScoreChanged(int updateScore)
    {
        this.score+=updateScore;
        OnScoreChangedHandler?.Invoke(this.score);
    }

    public void OnGamePause()
    {
        currGameState= currGameState == GameState.Playing ? GameState.Pausing : GameState.Playing;
        OnGameStateUpdateHandler?.Invoke(currGameState);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    Play,
    Pause,
    Prepare,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public GameState State { get; private set; }
    
    public int Score { get; private set; }

    public UnityEvent StatePrepare;
    public UnityEvent StatePlay;
    public UnityEvent StatePause;
    public UnityEvent StateGameOver;
    public UnityEvent ScoreChanged;

    private void Start()
    {
        Prepare();
    }

    public void IncreaseScore()
    {
        Score++;
        ScoreChanged?.Invoke();
    }

    public void Prepare()
    {
        State = GameState.Prepare;
        Score = 0;
        ScoreChanged?.Invoke();
        StatePrepare?.Invoke();
    }

    public void Play()
    {
        State = GameState.Play;
        StatePlay?.Invoke();
    }

    public void Pause()
    {
        State = GameState.Pause;
        StatePause?.Invoke();
    }

    public void GameOver()
    {
        State = GameState.GameOver;
        StateGameOver?.Invoke();
    }
}

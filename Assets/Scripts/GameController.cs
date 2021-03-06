using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public float gameSpeed { get; private set; } = 5f;
    public float score { get; private set; } = 0;
    public Vector3 downDirection { get; private set; } = new Vector3(0, 0, -1);

    public Action<float> ScoreChange;
    public Action OnGameOver;
    public GameObject GameOverPanel;

    private void Start() {
        ScoreChange?.Invoke(score);
    }


    internal void AddScore() {
        score += gameSpeed;
        ScoreChange?.Invoke(score);
    }

    public void GameOver(){
        OnGameOver?.Invoke();
        GameOverPanel.SetActive(true);
        GameOverPanel.GetComponent<UIGameOverPanel>().Init(score);
    }

    internal void IncreaseSpeed() {
        gameSpeed += 3/gameSpeed;
    }
}

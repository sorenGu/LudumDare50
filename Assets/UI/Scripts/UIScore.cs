using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour {
    public GameController controller;
    TextMeshProUGUI Text;
    
    private void OnEnable() {
        controller.ScoreChange += OnScoreChange;
        Text = GetComponent<TextMeshProUGUI>();
    }

    private void OnScoreChange(float score) {
        Text.SetText(((int)score).ToString("00000"));
    }
}

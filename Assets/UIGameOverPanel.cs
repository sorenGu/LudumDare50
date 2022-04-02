using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameOverPanel : MonoBehaviour
{
    TextMeshProUGUI Text;

    public void Init(float score) {
        Text.SetText(((int)score).ToString("00000"));
    }

    public void Replay() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitButton() {
        Application.Quit();
    }

}

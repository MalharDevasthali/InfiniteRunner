using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    private void Start()
    {
        PlayerPrefs.GetInt("HighScore", 0);
        SetHighScoreText(PlayerPrefs.GetInt("HighScore"));
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void SetHighScoreText(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
        highScoreText.text = "High Score: " + score.ToString();
    }
    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
        SetHighScoreText(PlayerPrefs.GetInt("HighScore"));
    }
}

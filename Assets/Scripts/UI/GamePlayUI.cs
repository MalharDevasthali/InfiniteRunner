

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] private Image[] heartImage;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    public static GamePlayUI instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void RecudeHeart(int heartIndex)
    {
        if (heartIndex <= 0)
        {
            ShowGameOverUI();
            return;
        }
        heartImage[heartIndex].gameObject.SetActive(false);
    }
    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
    private void ShowGameOverUI()
    {
        GameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }

}

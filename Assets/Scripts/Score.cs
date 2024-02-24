
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public GameObject settingsPanel; // Ayarlar paneli

    private void Start()
    {
        // Ayarlar panelini varsay�lan olarak kapat
        settingsPanel.SetActive(false);

        // E�er sahne 2'de de�ilsek ve sahne 3'te de�ilsek, skoru s�f�rla ve g�ncelle
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex != 1 && currentSceneIndex != 2)
        {
            PlayerPrefs.SetInt("Score", 0);
            UpdateScoreText();
        }
    }

    public void ShowHighScore()
    {
        // Di�er sahneden en y�ksek skoru almak i�in PlayerPrefs kullan�n
        int highScore = PlayerPrefs.GetInt("highScore", 0); // Varsay�lan de�er 0

        // E�er di�er sahnede en y�ksek skor yoksa, kullan�c�ya bir mesaj g�sterin
        if (highScore == 0)
        {
            highScoreText.text = "No high score yet!";
        }
        else
        {
            highScoreText.text = highScore.ToString();
        }

        // Ayarlar panelini a��n
        settingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        // Ayarlar panelini kapat
        settingsPanel.SetActive(false);
    }

    void UpdateScoreText()
    {
        // Skoru g�ncelle
        scoreText.text = PlayerPrefs.GetInt("Score", 0).ToString();
    }
}
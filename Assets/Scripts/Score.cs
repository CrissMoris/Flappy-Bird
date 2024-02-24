
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
        // Ayarlar panelini varsayýlan olarak kapat
        settingsPanel.SetActive(false);

        // Eðer sahne 2'de deðilsek ve sahne 3'te deðilsek, skoru sýfýrla ve güncelle
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex != 1 && currentSceneIndex != 2)
        {
            PlayerPrefs.SetInt("Score", 0);
            UpdateScoreText();
        }
    }

    public void ShowHighScore()
    {
        // Diðer sahneden en yüksek skoru almak için PlayerPrefs kullanýn
        int highScore = PlayerPrefs.GetInt("highScore", 0); // Varsayýlan deðer 0

        // Eðer diðer sahnede en yüksek skor yoksa, kullanýcýya bir mesaj gösterin
        if (highScore == 0)
        {
            highScoreText.text = "No high score yet!";
        }
        else
        {
            highScoreText.text = highScore.ToString();
        }

        // Ayarlar panelini açýn
        settingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        // Ayarlar panelini kapat
        settingsPanel.SetActive(false);
    }

    void UpdateScoreText()
    {
        // Skoru güncelle
        scoreText.text = PlayerPrefs.GetInt("Score", 0).ToString();
    }
}
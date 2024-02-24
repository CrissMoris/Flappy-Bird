/*
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score;
    public Text scoreText;
    public Text highScoreText;

    private bool isScene3Loaded = false; // Sahne 3 yüklü mü?

    void Start()
    {
        Score = 0;
        scoreText.text = Score.ToString();

        // En yüksek skoru göstermek için
        int highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = highScore > 0 ? "High Score: " + highScore.ToString() : ""; // En yüksek skoru göster veya gösterme

        // Şu anki sahne sahne 3 ise, sahne 3'ün yüklü olduğunu belirt
        isScene3Loaded = SceneManager.GetActiveScene().buildIndex == 2; // 3. sahne indeksi 2 olduğunu varsayalım
    }

    public void UpdateScore()
    {
        Score++;
        scoreText.text = Score.ToString();

        // Her skor güncellendiğinde en yüksek skoru kontrol et ve gerekirse güncelle
        if (Score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", Score);
            highScoreText.text = "NEW HIGH SCORE: " + Score.ToString(); // En yüksek skoru ekranda güncelle
        }

        // Skor 20 olduğunda ve sahne 3 yüklü değilse 3. sahneye geç
        if (Score >= 20 && !isScene3Loaded)
        {
            SceneManager.LoadScene(2); // 3. sahne indeksi 2 olduğunu varsayalım
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
*/ using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score;
    public Text scoreText;
    public Text highScoreText;

    private bool isScene3Loaded = false; // Sahne 3 yüklü mü?

    void Start()
    {
        // En yüksek skoru göstermek için
        int highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = highScore > 0 ? "High Score: " + highScore.ToString() : ""; // En yüksek skoru göster veya gösterme

        // Şu anki sahne sahne 3 ise, sahne 3'ün yüklü olduğunu belirt
        isScene3Loaded = SceneManager.GetActiveScene().buildIndex == 2; // 3. sahne indeksi 2 olduğunu varsayalım

        // Sahne 3'e geçildiğinde skoru 20'den başlat
        if (isScene3Loaded)
        {
            Score = 20;
            scoreText.text = Score.ToString();
        }
        else // Sahne 2 veya başka bir sahne ise
        {
            Score = 0;
            scoreText.text = Score.ToString();
        }
    }

    public void UpdateScore()
    {
        Score++;
        scoreText.text = Score.ToString();

        // Her skor güncellendiğinde en yüksek skoru kontrol et ve gerekirse güncelle
        if (Score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", Score);
            highScoreText.text = "NEW HIGH SCORE: " + Score.ToString(); // En yüksek skoru ekranda güncelle
        }

        // Skor 20 olduğunda ve sahne 3 yüklü değilse 3. sahneye geç
        if (Score >= 20 && !isScene3Loaded)
        {
            SceneManager.LoadScene(2); // 3. sahne indeksi 2 olduğunu varsayalım
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}

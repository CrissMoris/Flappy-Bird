/*
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score;
    public Text scoreText;
    public Text highScoreText;

    private bool isScene3Loaded = false; // Sahne 3 y�kl� m�?

    void Start()
    {
        Score = 0;
        scoreText.text = Score.ToString();

        // En y�ksek skoru g�stermek i�in
        int highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = highScore > 0 ? "High Score: " + highScore.ToString() : ""; // En y�ksek skoru g�ster veya g�sterme

        // �u anki sahne sahne 3 ise, sahne 3'�n y�kl� oldu�unu belirt
        isScene3Loaded = SceneManager.GetActiveScene().buildIndex == 2; // 3. sahne indeksi 2 oldu�unu varsayal�m
    }

    public void UpdateScore()
    {
        Score++;
        scoreText.text = Score.ToString();

        // Her skor g�ncellendi�inde en y�ksek skoru kontrol et ve gerekirse g�ncelle
        if (Score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", Score);
            highScoreText.text = "NEW HIGH SCORE: " + Score.ToString(); // En y�ksek skoru ekranda g�ncelle
        }

        // Skor 20 oldu�unda ve sahne 3 y�kl� de�ilse 3. sahneye ge�
        if (Score >= 20 && !isScene3Loaded)
        {
            SceneManager.LoadScene(2); // 3. sahne indeksi 2 oldu�unu varsayal�m
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

    private bool isScene3Loaded = false; // Sahne 3 y�kl� m�?

    void Start()
    {
        // En y�ksek skoru g�stermek i�in
        int highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = highScore > 0 ? "High Score: " + highScore.ToString() : ""; // En y�ksek skoru g�ster veya g�sterme

        // �u anki sahne sahne 3 ise, sahne 3'�n y�kl� oldu�unu belirt
        isScene3Loaded = SceneManager.GetActiveScene().buildIndex == 2; // 3. sahne indeksi 2 oldu�unu varsayal�m

        // Sahne 3'e ge�ildi�inde skoru 20'den ba�lat
        if (isScene3Loaded)
        {
            Score = 20;
            scoreText.text = Score.ToString();
        }
        else // Sahne 2 veya ba�ka bir sahne ise
        {
            Score = 0;
            scoreText.text = Score.ToString();
        }
    }

    public void UpdateScore()
    {
        Score++;
        scoreText.text = Score.ToString();

        // Her skor g�ncellendi�inde en y�ksek skoru kontrol et ve gerekirse g�ncelle
        if (Score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", Score);
            highScoreText.text = "NEW HIGH SCORE: " + Score.ToString(); // En y�ksek skoru ekranda g�ncelle
        }

        // Skor 20 oldu�unda ve sahne 3 y�kl� de�ilse 3. sahneye ge�
        if (Score >= 20 && !isScene3Loaded)
        {
            SceneManager.LoadScene(2); // 3. sahne indeksi 2 oldu�unu varsayal�m
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}

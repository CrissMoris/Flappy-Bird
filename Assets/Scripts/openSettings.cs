using UnityEngine;

public class OpenSettings : MonoBehaviour
{
    public GameObject settingsCanvas; // Ayarlar canvas�
    public GameObject deathScreenCanvas; // DeathScreen canvas�

    // Ayarlar butonuna t�kland���nda bu metot �a�r�l�r
    public void OpenSettingsCanvas()
    {
        // Ayarlar canvas�n� etkinle�tir
        if (settingsCanvas != null)
        {
            settingsCanvas.SetActive(true);
        }

        // DeathScreen canvas�n� devre d��� b�rak
        if (deathScreenCanvas != null)
        {
            deathScreenCanvas.SetActive(false);
        }
    }

    // Ayarlar canvas�n� kapatmak i�in bir metot
    public void CloseSettingsCanvas()
    {
        // Ayarlar canvas�n� devre d��� b�rak
        if (settingsCanvas != null)
        {
            settingsCanvas.SetActive(false);
        }

        // DeathScreen canvas�n� etkinle�tir
        if (deathScreenCanvas != null)
        {
            deathScreenCanvas.SetActive(true);
        }
    }
}

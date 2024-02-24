using UnityEngine;

public class OpenSettings : MonoBehaviour
{
    public GameObject settingsCanvas; // Ayarlar canvasý
    public GameObject deathScreenCanvas; // DeathScreen canvasý

    // Ayarlar butonuna týklandýðýnda bu metot çaðrýlýr
    public void OpenSettingsCanvas()
    {
        // Ayarlar canvasýný etkinleþtir
        if (settingsCanvas != null)
        {
            settingsCanvas.SetActive(true);
        }

        // DeathScreen canvasýný devre dýþý býrak
        if (deathScreenCanvas != null)
        {
            deathScreenCanvas.SetActive(false);
        }
    }

    // Ayarlar canvasýný kapatmak için bir metot
    public void CloseSettingsCanvas()
    {
        // Ayarlar canvasýný devre dýþý býrak
        if (settingsCanvas != null)
        {
            settingsCanvas.SetActive(false);
        }

        // DeathScreen canvasýný etkinleþtir
        if (deathScreenCanvas != null)
        {
            deathScreenCanvas.SetActive(true);
        }
    }
}

using UnityEngine;

public class TapSound : MonoBehaviour
{
    // Ses dosyalarýný tutacak deðiþkenler
    public AudioClip ucmaSesi; // Týklama sesi
    public AudioClip arkaPlanMuzigi; // Arka plan müziði

    // Ses çalacak bileþenler
    private AudioSource tapAudioSource; // Týklama sesi için
    private AudioSource backgroundMusicAudioSource; // Arka plan müziði için

    private Rigidbody2D rb2D;
    public float velocity;

    private bool isDead = false;
    public GameObject DeathScreen;

    private float tapVolume = 0.2f; // Týklama sesi için ses düzeyi
    private float musicVolume ; // Arka plan müziði için ses düzeyi

    private void Start()
    {
        // AudioSource bileþenlerini alýyoruz
        tapAudioSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicAudioSource = gameObject.AddComponent<AudioSource>();

        // Ses dosyalarýný atýyoruz
        tapAudioSource.clip = ucmaSesi;
        backgroundMusicAudioSource.clip = arkaPlanMuzigi;

        // Ses seviyelerini ayarlýyoruz
        tapAudioSource.volume = tapVolume;
        backgroundMusicAudioSource.volume = musicVolume;

        // Rigidbody2D bileþenini alýyoruz
        rb2D = GetComponent<Rigidbody2D>();

        // Arka plan müziðini çal
        backgroundMusicAudioSource.Play();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            rb2D.velocity = Vector2.up * velocity;
            SesCalmayaBasla(); // Týklama sesini çal
        }
    }

    // Týklama sesini çalma fonksiyonu
    private void SesCalmayaBasla()
    {
        // Eðer týklama sesi dosyasý varsa
        if (ucmaSesi != null)
        {
            // Týklama sesini çal
            tapAudioSource.PlayOneShot(ucmaSesi);
        }
    }

    // Çarpýþma iþlevi
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Eðer karakter "Dusman" nesnesine çarparsa
        if (collision.gameObject.CompareTag("Dusman"))
        {
            // Oyun durdurulur
            isDead = true;
            Time.timeScale = 0;
            DeathScreen.SetActive(true);
            // Týklama sesini durdur
            NoSound();
        }
    }

    // Týklama sesini durdurma fonksiyonu
    private void NoSound()
    {
        // Eðer týklama sesi çalýyorsa
        if (tapAudioSource.isPlaying)
        {
            // Týklama sesini durdur
            tapAudioSource.Stop();
        }
    }
}

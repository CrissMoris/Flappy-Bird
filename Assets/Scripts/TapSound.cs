using UnityEngine;

public class TapSound : MonoBehaviour
{
    // Ses dosyalar�n� tutacak de�i�kenler
    public AudioClip ucmaSesi; // T�klama sesi
    public AudioClip arkaPlanMuzigi; // Arka plan m�zi�i

    // Ses �alacak bile�enler
    private AudioSource tapAudioSource; // T�klama sesi i�in
    private AudioSource backgroundMusicAudioSource; // Arka plan m�zi�i i�in

    private Rigidbody2D rb2D;
    public float velocity;

    private bool isDead = false;
    public GameObject DeathScreen;

    private float tapVolume = 0.2f; // T�klama sesi i�in ses d�zeyi
    private float musicVolume ; // Arka plan m�zi�i i�in ses d�zeyi

    private void Start()
    {
        // AudioSource bile�enlerini al�yoruz
        tapAudioSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicAudioSource = gameObject.AddComponent<AudioSource>();

        // Ses dosyalar�n� at�yoruz
        tapAudioSource.clip = ucmaSesi;
        backgroundMusicAudioSource.clip = arkaPlanMuzigi;

        // Ses seviyelerini ayarl�yoruz
        tapAudioSource.volume = tapVolume;
        backgroundMusicAudioSource.volume = musicVolume;

        // Rigidbody2D bile�enini al�yoruz
        rb2D = GetComponent<Rigidbody2D>();

        // Arka plan m�zi�ini �al
        backgroundMusicAudioSource.Play();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            rb2D.velocity = Vector2.up * velocity;
            SesCalmayaBasla(); // T�klama sesini �al
        }
    }

    // T�klama sesini �alma fonksiyonu
    private void SesCalmayaBasla()
    {
        // E�er t�klama sesi dosyas� varsa
        if (ucmaSesi != null)
        {
            // T�klama sesini �al
            tapAudioSource.PlayOneShot(ucmaSesi);
        }
    }

    // �arp��ma i�levi
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // E�er karakter "Dusman" nesnesine �arparsa
        if (collision.gameObject.CompareTag("Dusman"))
        {
            // Oyun durdurulur
            isDead = true;
            Time.timeScale = 0;
            DeathScreen.SetActive(true);
            // T�klama sesini durdur
            NoSound();
        }
    }

    // T�klama sesini durdurma fonksiyonu
    private void NoSound()
    {
        // E�er t�klama sesi �al�yorsa
        if (tapAudioSource.isPlaying)
        {
            // T�klama sesini durdur
            tapAudioSource.Stop();
        }
    }
}

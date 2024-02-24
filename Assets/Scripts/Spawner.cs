using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public YukariUcma BirdScript;
    public GameObject DubalarPrefab;
    public float height;
    public float spawnInterval; // Oluþturma aralýðý
    public float initialSpeed; // Baþlangýç hýzý
    public float speedIncreaseAmount; // Hýz artýþ miktarý
    public float speedIncreaseInterval; // Hýz artýþý aralýðý

    private float timer; // Zamanlayýcý
    private float currentSpeed; // Geçerli hýz

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = initialSpeed; // Baþlangýç hýzý
        StartCoroutine(SpawnObject()); // Oyun baþladýðýnda nesneleri spawn etmeye baþla
    }

    public IEnumerator SpawnObject()
    {
        timer = 0f; // Zamanlayýcýyý sýfýrla

        while (!BirdScript.isDead) // Kuþ ölmediyse devam et
        {
            // Zamanlayýcýyý güncelle
            timer += Time.deltaTime;

            // Belirli bir aralýkta hýz artýþýný kontrol et
            if (timer >= speedIncreaseInterval)
            {
                // Hýz artýþýný gerçekleþtir
                currentSpeed += speedIncreaseAmount;
                // Zamanlayýcýyý sýfýrla
                timer = 0f;
                // spawnInterval'i de hýz artýþý kadar artýr
                spawnInterval +=  speedIncreaseAmount;
            }

            // Duba oluþtur
            GameObject newDubalar = Instantiate(DubalarPrefab, new Vector3(3, Random.Range(-height, height), 0), Quaternion.identity);
            DubalarHareket dubalarScript = newDubalar.GetComponent<DubalarHareket>();
            dubalarScript.speed = currentSpeed; // Hýzý ayarla

            yield return new WaitForSeconds(spawnInterval); // spawnInterval kadar bekle
        }
    }
}

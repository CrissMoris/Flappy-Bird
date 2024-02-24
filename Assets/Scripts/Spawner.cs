using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public YukariUcma BirdScript;
    public GameObject DubalarPrefab;
    public float height;
    public float spawnInterval; // Olu�turma aral���
    public float initialSpeed; // Ba�lang�� h�z�
    public float speedIncreaseAmount; // H�z art�� miktar�
    public float speedIncreaseInterval; // H�z art��� aral���

    private float timer; // Zamanlay�c�
    private float currentSpeed; // Ge�erli h�z

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = initialSpeed; // Ba�lang�� h�z�
        StartCoroutine(SpawnObject()); // Oyun ba�lad���nda nesneleri spawn etmeye ba�la
    }

    public IEnumerator SpawnObject()
    {
        timer = 0f; // Zamanlay�c�y� s�f�rla

        while (!BirdScript.isDead) // Ku� �lmediyse devam et
        {
            // Zamanlay�c�y� g�ncelle
            timer += Time.deltaTime;

            // Belirli bir aral�kta h�z art���n� kontrol et
            if (timer >= speedIncreaseInterval)
            {
                // H�z art���n� ger�ekle�tir
                currentSpeed += speedIncreaseAmount;
                // Zamanlay�c�y� s�f�rla
                timer = 0f;
                // spawnInterval'i de h�z art��� kadar art�r
                spawnInterval +=  speedIncreaseAmount;
            }

            // Duba olu�tur
            GameObject newDubalar = Instantiate(DubalarPrefab, new Vector3(3, Random.Range(-height, height), 0), Quaternion.identity);
            DubalarHareket dubalarScript = newDubalar.GetComponent<DubalarHareket>();
            dubalarScript.speed = currentSpeed; // H�z� ayarla

            yield return new WaitForSeconds(spawnInterval); // spawnInterval kadar bekle
        }
    }
}

using UnityEngine;

public class DubalarHareket : MonoBehaviour
{
    public float speed; // Hýz deðiþkeni
    public float speedIncreaseAmount; // Hýz artýþ miktarý, artýk public

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; // Hýzla sola doðru hareket et
    }
}

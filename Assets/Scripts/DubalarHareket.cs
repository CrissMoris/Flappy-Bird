using UnityEngine;

public class DubalarHareket : MonoBehaviour
{
    public float speed; // H�z de�i�keni
    public float speedIncreaseAmount; // H�z art�� miktar�, art�k public

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; // H�zla sola do�ru hareket et
    }
}

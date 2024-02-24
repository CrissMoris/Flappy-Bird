using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukariUcma : MonoBehaviour
{
    public bool isDead;
    public float velocity = 1f; // Declaring velocity as a public field

    public Rigidbody2D rb2D;
    public GameManager managerGame;
    public GameObject DeathScreen;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb2D.velocity = Vector2.up * velocity;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SkorAlaný")
        {
            managerGame.UpdateScore();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dusman")
        {
            isDead = true;
            Time.timeScale = 0;
            DeathScreen.SetActive(true);
        }
    }
}
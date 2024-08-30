using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MS : MonoBehaviour
{
    Rigidbody2D rb;
    int speed;
    float jumpForce = 20;
    private bool isGrounded;
    public Button jumpButton;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 3;

        
        if (jumpButton != null)
        {
            jumpButton.onClick.AddListener(Jump);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Pindah1")
        {
            SceneManager.LoadScene("Scene3");
        }
        if (col.tag == "Pindah2")
        {
            SceneManager.LoadScene("Scene2");
        }
    }

    void Update()
    {
        Move();
    }
    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    public void Move(){
                rb.velocity = new Vector2(0, 0);
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.1f);
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0, speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0, -speed);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(-speed, speed);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(speed, speed);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(speed, -speed);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(-speed, -speed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}

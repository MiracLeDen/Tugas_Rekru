using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MS : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public Animator animasi;
    public bool isLeft;
    public bool isGrounded;
    public GameObject fireball;
    public GameObject firepos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Pindah3"){
            SceneManager.LoadScene("Scene4");
        }
        if(col.tag == "Pindah1"){
            SceneManager.LoadScene("Scene3");
        }
        if(col.tag == "Pindah2"){
            SceneManager.LoadScene("Scene2");
        }
    }
    void Update()
    {
        Move();
        jump();
        Attack();
    }
    void Attack(){
        if(Input.GetMouseButtonDown(0)){
            StartCoroutine(DelayStrike());
        }
    }
    IEnumerator DelayStrike(){
        yield return new WaitForSeconds(0.2f);
        GameObject spawnedFire = (GameObject)Instantiate(fireball);
        spawnedFire.transform.position = firepos.transform.position;
    }
    void Move(){
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        
        if(moveInput!=0){animasi.SetBool("IsWalking",true);}
        else animasi.SetBool("IsWalking",false);

        if(moveInput > 0){
            transform.localScale = new Vector3(1,1,1);
            isLeft = false;
        }
        else if(moveInput < 0){
            transform.localScale = new Vector3(-1,1,1);
            isLeft = true;
        }
    }

    void jump(){
        if(isGrounded && Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.CompareTag("Ground")){
            isGrounded = true;
        }    
    }
    void OnCollisionExit2D(Collision2D collision){
        if(collision.collider.CompareTag("Ground")){
            isGrounded = true;
        }
}
}
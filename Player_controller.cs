using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_controller : MonoBehaviour{

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;
    public int maxHealth;
    public int currentHealth;



    public HealthBar healthBar;

    public GameObject deathEffect;
    public GameObject jumpEffect;

    void Start()
    {

        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }



    void FixedUpdate(){ // In fixed Update au loc toate modificarile care ne intereseaza sa fie influentate de fizica

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);// folosim doar pe axa y deoarece e 2d
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        float WorldXPos = Camera.main.ScreenToWorldPoint(pos).x;

        if (WorldXPos > transform.position.x)
        { // character it's your char game objectx
            if (facingRight == false)
            {

                Flip();

            }
        }
        else
        {
            if (facingRight == true)
            {

                Flip();

            }
        }
        // Facing left

    }

    void Update(){
        if(currentHealth <= 0) {
            Destroy(gameObject);
            
        }
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            Jump();
            Instantiate(jumpEffect,transform.position,Quaternion.identity);
        }
        else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            Jump();
            Instantiate(jumpEffect,transform.position,Quaternion.identity);

        }

    }

    void Flip()
    {

        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void takeDamage(int damage){

        FindObjectOfType<audioManager>().Play("PlayerHurt");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {   
            Die();
        }

    }
    void Jump()
    {
   
        FindObjectOfType<audioManager>().Play("Jump");


        rb.velocity = Vector2.up * jumpForce;
        if (extraJumps != 0)
        {
            extraJumps--;
        }
    }

    void Die(){
        //GameManager.instance.EndGame();
        Destroy(gameObject);
        SceneManager.LoadScene("main menu");
        Instantiate(deathEffect,transform.position,Quaternion.identity);
        

    }


}



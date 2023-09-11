using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public Animator animator;
    public HealthBar healthBar;
    public Timer timer;
    public TimeTimer timeTimer; //
    public GameObject speedBoost;
    public GameObject speedBuff;
    public GameObject jumpBoost;
    public GameObject jumpBuff;
    public GameObject transition;
    public Transition timeTransiton;
    public GameObject finishTransition;
    public FinishTransition finalTransiton;
    public GameObject canon;
    public GameObject diedTransition;
    public GameObject pauseMenu;
    public ScoreScript scoreScript; //



    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    private int maxHealth;
    private int currentHealth;
    bool facingRight = true;
    


    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        transform.position = new Vector3(-11, -5, 0);

        moveSpeed = 3f;
        jumpForce = 50f;
        isJumping = false;
        maxHealth = 100;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        timeTimer.Begin();

        speedBoost.SetActive(false);
        speedBuff.SetActive(false);
        jumpBoost.SetActive(false);
        jumpBuff.SetActive(false);
        transition.SetActive(false);
        diedTransition.SetActive(false);
        pauseMenu.SetActive(false);

        transition.SetActive(true);
        transform.position = new Vector3(-11, -5, 0);

        if(PlayerPrefs.GetInt("LoadGame") == 1)
        {
            LoadPlayer();
            PlayerPrefs.SetInt("LoadGame", 0);
            PlayerPrefs.Save();
        }

        timeTransiton.Begin(3);


    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        if (moveHorizontal < 0f && facingRight)
        {
            Flip();
        }
        else if (moveHorizontal > 0f && !facingRight)
        {
            Flip();
        }

        if (!timer.isTimerOn)
        {
            Initial();
        }

        if (!timeTransiton.isTimerOn)
        {
            transition.SetActive(false);
        }

      //  if (Input.GetKeyDown(KeyCode.Space))
      //  {
      //      TakeDamage(20);
      //  }

        if (currentHealth == 0)
        {
            diedTransition.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;

        }

    }

        void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        if (!isJumping && moveVertical > 0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }

        if (collision.gameObject.tag == "Enemies")
        {
            currentHealth -= 5;
            healthBar.SetHealth(currentHealth);
        }

       if(collision.gameObject.tag == "SuperiorEnemies" && collision == collision.gameObject.GetComponent<CircleCollider2D>())
        {
            currentHealth -= 15;
            healthBar.SetHealth(currentHealth);
        }

        if (collision.gameObject.tag == "SpeedBooster" && !timer.isTimerOn)
        {
            moveSpeed = 4f;
            Destroy(collision.gameObject);
            speedBoost.SetActive(true);
            StartCount();
        }

        if (collision.gameObject.tag == "HealthBooster")
        {
            currentHealth = 100;
            healthBar.SetHealth(currentHealth);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "JumpBooster" && !timer.isTimerOn)
        {
            jumpForce = 70f;
            Destroy(collision.gameObject);
            jumpBoost.SetActive(true);
            StartCount();
        }

        if (collision.gameObject.tag == "HealthBuff")
        {
            currentHealth -= 20; 
            healthBar.SetHealth(currentHealth);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "SpeedBuff" && !timer.isTimerOn)
        {
            moveSpeed = 1f;
            Destroy(collision.gameObject);
            speedBuff.SetActive(true);
            StartCount();
        }

        if (collision.gameObject.tag == "JumpBuff" && !timer.isTimerOn)
        {
            jumpForce = 1f;
            Destroy(collision.gameObject);
            jumpBuff.SetActive(true);
            StartCount();
        }

        if(collision.gameObject.tag == "Level2")
        {
            transition.SetActive(true);
            transform.position = new Vector3(-37, -74, 0);
            timeTransiton.Begin(3);
            currentHealth = 100;
            healthBar.SetHealth(currentHealth);
        }

        if (collision.gameObject.tag == "Level3")
        {
            transition.SetActive(true);
            transform.position = new Vector3(-86, -205, 0);
            timeTransiton.Begin(3);
            currentHealth = 100;
            healthBar.SetHealth(currentHealth);
        }

        if (collision.gameObject.tag == "Bomb")
        {
            currentHealth -= 5;
            healthBar.SetHealth(currentHealth);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Finish")
        {
            finalTransiton.FinalGame();
        }

        if(collision.gameObject.tag == "Waypoints")
        {
             Instantiate(canon, new Vector3(150, -1, 0), Quaternion.identity);
            collision.gameObject.tag = "Waypoints2";
           
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void Initial()
    {
        moveSpeed = 3f;
        jumpForce = 50f;
        speedBoost.SetActive(false);
        speedBuff.SetActive(false);
        jumpBoost.SetActive(false);
        jumpBuff.SetActive(false);
    }

    void StartCount()
    {
        timer.Begin(timer.Duration);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
      
    }

    public void FinishGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void SetHealth(int health)
    {
        currentHealth = health;
        healthBar.SetHealth(currentHealth);
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        SetHealth(data.health);
        scoreScript.SetScore(data.score);
        timeTimer.SetCurrentTime(data.time);

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

}

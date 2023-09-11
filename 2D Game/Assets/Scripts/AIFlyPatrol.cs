using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFlyPatrol : MonoBehaviour
{
    // Start is called before the first frame update

    public float walkSpeed;
    [SerializeField] private GameObject bomb;

    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;
    private bool mustAttack;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
  

    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }


    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = Physics2D.OverlapCircle(groundCheckPos.position, 1f, groundLayer);
          
        }

       
    }

    void Patrol()
    {
        if (mustTurn)
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    void SpawnBomb()
    {
        
            Instantiate(bomb, new Vector3(rb.position.x, rb.position.y, 0), Quaternion.identity);
      

     }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SpawnBomb();
        }
    }
}
